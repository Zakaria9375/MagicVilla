using AutoMapper;
using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController(IMapper mapper, ILogger<VillaController> logger, IVillaService villaService) : BaseController(logger, mapper)
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

        #region Creating new villa
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Villa";
            ViewData["Action"] = "Create";
            return View("VillaForm", new VillaCreateDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VillaCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(dto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Error occurred while creating the villa.");

            }
            ViewData["Title"] = "Create Villa";
            ViewData["Action"] = "Create";
            return View("VillaForm", dto);
        }
        #endregion

        #region Updating an existing villa
        public async Task<IActionResult> Update(int id)
        {
            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                var villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
                ViewData["Title"] = "Edit Villa";
                ViewData["Action"] = "Update";
                ViewData["Id"] = id;
                return View("VillaForm", villaDTO);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, VillaUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(id, dto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Error occurred while updating the villa.");
            }
            ViewData["Title"] = "Edit Villa";
            ViewData["Action"] = "Update";
            return View("VillaForm", dto);
        }
        #endregion

        #region Delete Villa 
        public async  Task<IActionResult> Delete(int id)
        {
            var response = await _villaService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(villa);
            }
            
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var response = await _villaService.DeleteAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        #endregion
    }
}
