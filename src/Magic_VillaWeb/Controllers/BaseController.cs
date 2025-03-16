using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
    public class BaseController(ILogger<BaseController> logger, IMapper mapper) : Controller
    {
        protected readonly ILogger<BaseController> _logger = logger;
        protected readonly IMapper _mapper = mapper;
    }
}
