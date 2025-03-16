using AutoMapper;
using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    public class BaseController(ILogger<BaseController> logger, IMapper mapper) : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger = logger;
        protected readonly IMapper _mapper = mapper;

        protected APIResponse<T> SetApiResponse<T>(bool isSuccess = true, HttpStatusCode statusCode = HttpStatusCode.OK, List<string>? messages = null, T? result = default)
        {
            return new APIResponse<T>(statusCode, isSuccess, result, messages);
        }

        protected APIResponse<T> SetApiResponseFromModelState<T>(ModelStateDictionary modelState, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var messages = modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return new APIResponse<T>(statusCode, false, default, messages);
        }
    }
}
