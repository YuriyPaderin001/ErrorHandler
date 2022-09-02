using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

using YuraSoft.ExceptionHandler.Middleware;

namespace YuraSoft.ExceptionHandler.Unit.Tests
{
	public class ErrorHandlerMiddlewareTests
	{
		[Fact]
		public async Task InvokeAsync_ShouldBeOk_WhenRequestDelegateWriteResponseWithBody()
		{
			// Arrange

			const int content = 2022;

			RequestDelegate requestDelegate = async httpContext =>
			{
				httpContext.Response.StatusCode = StatusCodes.Status201Created;
				await httpContext.Response.WriteAsync(content.ToString());
			};

			Mock<IExceptionHandler> errorHandlerMock = new Mock<IExceptionHandler>();
			errorHandlerMock.Setup(m => m.HandleException(null, null)).Returns(Task.CompletedTask);

			ExceptionHandlerMiddleware errorHandlerMiddleware = new ExceptionHandlerMiddleware(requestDelegate, errorHandlerMock.Object);

			Mock<HttpContext> httpContextMock = new Mock<HttpContext>();

			// Act

			await errorHandlerMiddleware.InvokeAsync(httpContextMock.Object);

			// Assert

			Assert.Equal(StatusCodes.Status201Created, httpContextMock.Object.Response.StatusCode);
			Assert.NotEqual(0, httpContextMock.Object.Response.Body.Length);

			byte[] contentBytes = new byte[httpContextMock.Object.Response.Body.Length];
			await httpContextMock.Object.Response.Body.ReadAsync(contentBytes);

			string contentJson = Encoding.Default.GetString(contentBytes);
			int responseContent = int.Parse(contentJson);

			Assert.True(int.TryParse(contentJson, out int resposneContent));
			Assert.Equal(content, responseContent);
		}
	}
}
