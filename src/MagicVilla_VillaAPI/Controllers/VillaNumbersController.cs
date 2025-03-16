using AutoMapper;
using MagicVilla_Utility.DTO.VillaNumber;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/villaNumbers")]
    [ApiController]
    public class VillaNumbersController(IVillaRepository dbVilla, IVillaNumberRepository dbVillaNo, IMapper mapper, ILogger<VillaNumbersController> logger) : BaseController(logger, mapper)
    {
        private readonly IVillaNumberRepository _dbVillaNo = dbVillaNo;
        private readonly IVillaRepository _dbVilla = dbVilla;

        private async Task<bool> IsDuplicateVillaNumber<T>(T model) where T : IVillaNubmerDTO
        {
            var villas = await _dbVillaNo.GetAllAsync(v => v.Code == model.Code);
            return villas.Count >= 1;
        }

        private async Task<bool> IsVillaExist(int id)
        {
            var villa = await _dbVilla.GetAsync(v => v.Id == id);
            return villa == null;
        }

        #region Getting all VillaNumbers
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<List<VillaNumberDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVillaNumbers()
        {
            var villaNoList = await _dbVillaNo.GetAllAsync(includeProperties: "Villa");
            var villaNoDTOs = _mapper.Map<List<VillaNumberDTO>>(villaNoList);

            return Ok(SetApiResponse(true, HttpStatusCode.OK, [AppConstants.SuccessMessage], villaNoDTOs));
        }
        #endregion

        #region Getting VillaNumber by Code
        [HttpGet("{code:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetVillaNumber(int code)
        {
            if (code <= 0)
            {
                return BadRequest(SetApiResponse<VillaNumberDTO>(false, HttpStatusCode.BadRequest, [AppConstants.EnterValidVillaNumber]));
            }

            var villaNumber = await _dbVillaNo.GetAsync(v => v.Code == code, includeProperties: "Villa");
            if (villaNumber == null)
            {
                return NotFound(SetApiResponse<VillaNumberDTO>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.VillaNumberNotFound, code)]));
            }

            return Ok(SetApiResponse(true, HttpStatusCode.OK, [AppConstants.SuccessMessage], _mapper.Map<VillaNumberDTO>(villaNumber)));
        }
        #endregion

        #region Creating a VillaNumber
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            if (createDTO == null || !ModelState.IsValid)
            {
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            if (await IsDuplicateVillaNumber(createDTO))
            {
                ModelState.AddModelError(AppConstants.repeatedVillaNumber, AppConstants.RepeatedVillaNumber);
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            if (await IsVillaExist(createDTO.VillaID))
            {
                ModelState.AddModelError(AppConstants.villaDoesNotExist, string.Format(AppConstants.VillaNotFound, createDTO.VillaID));
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            var createdVillaNumber = _mapper.Map<VillaNumber>(createDTO);
            await _dbVillaNo.CreateAsync(createdVillaNumber);

            var villaNoDTO = _mapper.Map<VillaNumberDTO>(createdVillaNumber);
            return CreatedAtRoute("GetVillaNumber", new { code = villaNoDTO.Code },
                SetApiResponse(true, HttpStatusCode.Created, [AppConstants.SuccessMessage], villaNoDTO));
        }
        #endregion

        #region Updating a VillaNumber
        [HttpPut("{code:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<VillaNumberDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVillaNumber(int code, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            if (updateDTO == null)
            {
                return BadRequest(SetApiResponse<VillaNumberDTO>(false, HttpStatusCode.BadRequest, [AppConstants.InvalidVNData]));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            var villaNumber = await _dbVillaNo.GetAsync(v => v.Code == code);
            if (villaNumber == null)
            {
                return NotFound(SetApiResponse<VillaNumberDTO>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.EnterValidVillaNumber, code)]));
            }

            if (await IsDuplicateVillaNumber(updateDTO))
            {
                ModelState.AddModelError(AppConstants.repeatedVillaNumber, AppConstants.RepeatedVillaNumber);
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            if (await IsVillaExist(updateDTO.VillaID))
            {
                ModelState.AddModelError(AppConstants.villaDoesNotExist, string.Format(AppConstants.VillaNotFound, updateDTO.VillaID));
                return BadRequest(SetApiResponseFromModelState<VillaNumberDTO>(ModelState));
            }

            // Map the update onto the existing entity
            _mapper.Map(updateDTO, villaNumber);
            await _dbVillaNo.UpdateAsync(villaNumber);

            return Ok(SetApiResponse<VillaNumberDTO>(true, HttpStatusCode.NoContent, [AppConstants.SuccessMessage]));
        }
        #endregion

        #region Deleting a VillaNumber
        [HttpDelete("{code:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVillaNumber(int code)
        {
            if (code <= 0)
            {
                return BadRequest(SetApiResponse<object>(false, HttpStatusCode.BadRequest, [AppConstants.InvalidVNData]));
            }

            var villaNumber = await _dbVillaNo.GetAsync(v => v.Code == code, true);
            if (villaNumber == null)
            {
                return NotFound(SetApiResponse<object>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.VillaNumberNotFound, code)]));
            }

            await _dbVillaNo.DeleteAsync(villaNumber);
            return Ok(SetApiResponse<object>(true, HttpStatusCode.NoContent, [AppConstants.SuccessMessage]));
        }
        #endregion


    }
}
