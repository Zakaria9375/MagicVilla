using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using AutoMapper;

namespace MagicVilla_Web.Controllers
{
    public class HomeController(IMapper mapper, ILogger<VillaController> logger, IVillaService villaService) : BaseController(logger, mapper)
    {
        private readonly IVillaService _villaService = villaService;
        #region List all villas
        public async Task<IActionResult> Index()
        {
            List<VillaDTO> list = [];
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
