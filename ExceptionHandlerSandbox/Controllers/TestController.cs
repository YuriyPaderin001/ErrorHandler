using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YuraSoft.ExceptionHandler.Exceptions;

namespace YuraSoft.ErrorHandlerSandbox.Controllers
{
	[ApiController]
	[Route("api/v1/test")]
	public class TestController : ControllerBase
	{
		public TestController()
		{
		}

		[Route("ok")]
		public ActionResult Ok() => Ok("Ok");

		[Route("forbidden")]
		public ActionResult ThrowForbidden() => throw new ForbiddenException();

		[HttpGet]
		[Route("bad-request")]
		public ActionResult ThrowBadRequest([FromQuery][Range(1, 3)] int number, [BindRequired][FromQuery][MinLength(2)] int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] < 0)
				{
					ModelState.AddModelError($"{nameof(array)}[{i}]", "Value must be greater than 0");
				}
			}

			throw new BadRequestException(ModelState);
		}

		[Route("not-found")]
		public ActionResult ThrowNotFound() => throw new NotFoundException();

		[Route("exception")]
		public ActionResult ThrowException() => throw new Exception("exception");
	}
}
