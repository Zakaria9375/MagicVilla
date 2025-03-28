﻿using AutoMapper;
using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Utility.DTO.VillaNumber;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController(IMapper mapper, ILogger<VillaNumberController> logger, IVillaNumberService villaNumberService, IVillaService villaService) : BaseController(logger, mapper)
    {
        private readonly IVillaNumberService _villaNumberService = villaNumberService;
        private readonly IVillaService _villaService = villaService;

        private static string GetFirstErrMessage(APIResponse response)
        {
            return response.Messages.FirstOrDefault() ?? "Error occurred while updating the villa.";
        }

        private static IEnumerable<SelectListItem> GetVillaList(APIResponse response, int VillaID)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                    Selected = (i.Id == VillaID)
                });
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<SelectListItem>();
            }

        }

        #region List all villa numbers
        public async Task<IActionResult> Index()
        {
            List<VillaNumberDTO> list = [];
            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        #endregion

        #region Creating new villa
        public async Task<IActionResult> Create()
        {
            var vm = new VillaNumberVM<VillaNumberCreateDTO>();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess && response.Result is not null)
            {
                vm.VillaList = GetVillaList(response, vm.VillaNumber.VillaID);
            }
            return View("Create", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VillaNumberVM<VillaNumberCreateDTO> model)
        {

            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", GetFirstErrMessage(response));
            }
            var villaResponse = await _villaService.GetAllAsync<APIResponse>();
            if (villaResponse != null && villaResponse.IsSuccess && villaResponse.Result is not null)
            {
                model.VillaList = GetVillaList(villaResponse, model.VillaNumber.VillaID);
            }
            return View("Create", model);
        }
        #endregion

        #region Updating an existing villa
        public async Task<IActionResult> Update(int Code)
        {
            var vm = new VillaNumberVM<VillaNumberUpdateDTO>();
            var villas = await _villaService.GetAllAsync<APIResponse>();
            if (villas != null && villas.IsSuccess && villas.Result is not null)
            {
                vm.VillaList = GetVillaList(villas, vm.VillaNumber.VillaID);
            }
            else
            {
                ModelState.AddModelError("", GetFirstErrMessage(villas));
                return NotFound();
            }
            var villaNumber = await _villaNumberService.GetAsync<APIResponse>(Code);
            if (villaNumber == null || !villaNumber.IsSuccess || villaNumber.Result is null)
            {
                ModelState.AddModelError("", "Villa Number not found.");
                return NotFound();
            }

            var deserializedVillaNumber = villaNumber.Result as VillaNumberDTO
    ?? JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(villaNumber.Result));
            vm.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(deserializedVillaNumber);
            ViewData["Code"] = Code;
            return View("Update", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Code, VillaNumberVM<VillaNumberUpdateDTO> model)
        {
            var response = await _villaNumberService.UpdateAsync<APIResponse>(Code, model.VillaNumber);

            if (ModelState.IsValid)
            {
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", GetFirstErrMessage(response));
            }

            var villaResponse = await _villaService.GetAllAsync<APIResponse>();
            if (villaResponse != null && villaResponse.IsSuccess && villaResponse.Result is not null)
            {
                model.VillaList = GetVillaList(villaResponse, model.VillaNumber.VillaID);
            }
            return View("Update", model);
        }
        #endregion

        #region Delete Villa 
        public async Task<IActionResult> Delete(int Code)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(Code);
            if (response != null && response.IsSuccess && response.Result is not null)
            {
                var villaNumber = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                return View(villaNumber);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(int Code)
        {
            var response = await _villaNumberService.DeleteAsync<APIResponse>(Code);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        #endregion
    }
}
