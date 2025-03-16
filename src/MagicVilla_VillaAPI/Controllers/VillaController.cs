using AutoMapper;
using MagicVilla_Utility.DTO.Villa;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/villas")]
    [ApiController]
    public class VillaController(IVillaRepository dbVilla, IMapper mapper, ILogger<VillaController> logger) : BaseController(logger, mapper)
    {

        private readonly IVillaRepository _dbVilla = dbVilla;

        private async Task<bool> IsDuplicateName(string name, int? id = null)
        {
            var villas = await _dbVilla.GetAsync(v => v.Name.ToLower() == name.ToLower() && v.Id != id);
            return villas != null;
        }

        #region Getting all villas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<List<VillaDTO>>))]
        public async Task<IActionResult> GetVillas()
        {
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            var result = _mapper.Map<List<VillaDTO>>(villaList);
            return Ok(SetApiResponse(true, HttpStatusCode.OK, [AppConstants.SuccessMessage], result));
        }
        #endregion

        #region Getting villa by Id
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<VillaDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(APIResponse<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(APIResponse<object>))]
        public async Task<IActionResult> GetVillaByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest(SetApiResponse<object>(false, HttpStatusCode.BadRequest, [AppConstants.EnterValidID]));
            }
            var villa = await _dbVilla.GetAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound(SetApiResponse<object>(false, HttpStatusCode.NotFound
                    , [string.Format(AppConstants.VillaNotFound, id)]));
            }
            return Ok(SetApiResponse(true, HttpStatusCode.OK, [AppConstants.SuccessMessage], _mapper.Map<VillaDTO>(villa)));
        }
        #endregion

        #region Creating a Villa
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(APIResponse<object>))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(APIResponse<VillaDTO>))]
        public async Task<IActionResult> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (await IsDuplicateName(createDTO.Name))
            {

                ModelState.AddModelError(AppConstants.repeatedName, AppConstants.RepeatedNames);
                return BadRequest(SetApiResponseFromModelState<object>(ModelState));
            }
            Villa createdVilla = _mapper.Map<Villa>(createDTO);
            await _dbVilla.CreateAsync(createdVilla);
            var villaDTO = _mapper.Map<VillaDTO>(createdVilla);
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, SetApiResponse(true, HttpStatusCode.Created, result: villaDTO));
        }
        #endregion

        #region Updating a Villa
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(APIResponse<VillaUpdateDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if (id <= 0 || updateDTO == null)
            {
                return BadRequest(SetApiResponse<object>(false, HttpStatusCode.BadRequest, [AppConstants.InvalidData]));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(SetApiResponseFromModelState<object>(ModelState));
            }

            var villa = await _dbVilla.GetAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound(SetApiResponse<object>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.EnterValidID, id)]));
            }

            if (await IsDuplicateName(updateDTO.Name, id))
            {
                ModelState.AddModelError(AppConstants.repeatedName, AppConstants.RepeatedNames);
                return BadRequest(SetApiResponseFromModelState<object>(ModelState));
            }

            _mapper.Map(updateDTO, villa);
            await _dbVilla.UpdateAsync(villa);
            return Ok(SetApiResponse<VillaUpdateDTO>(true, HttpStatusCode.OK, result: updateDTO));
        }
        #endregion

        #region Updating a Villa Partially
        [HttpPatch("{id:int}", Name = "UpdateVillaPartially")]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(APIResponse<VillaUpdateDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVillaPartially(int id, [FromBody] JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id <= 0)
            {
                return BadRequest(SetApiResponse<object>(false, HttpStatusCode.BadRequest, [AppConstants.InvalidData]));
            }

            var villa = await _dbVilla.GetAsync(v => v.Id == id, true);
            if (villa == null)
            {
                return NotFound(SetApiResponse<object>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.EnterValidID, id)]));
            }

            // Convert entity to DTO for patching
            var villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
            patchDTO.ApplyTo(villaDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(SetApiResponseFromModelState<object>(ModelState));
            }

            if (await IsDuplicateName(villaDTO.Name, id))
            {
                ModelState.AddModelError(AppConstants.repeatedName, AppConstants.RepeatedNames);
                return BadRequest(SetApiResponseFromModelState<object>(ModelState));
            }

            // Map updated DTO back to entity and update
            _mapper.Map(villaDTO, villa);
            await _dbVilla.UpdateAsync(villa);

            return Ok(SetApiResponse<VillaUpdateDTO>(true, HttpStatusCode.OK, result: villaDTO));
        }
        #endregion

        #region Deleting a Villa
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(APIResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id <= 0)
            {
                return BadRequest(SetApiResponse<object>(false, HttpStatusCode.BadRequest, [AppConstants.InvalidData]));
            }

            var villa = await _dbVilla.GetAsync(v => v.Id == id, true);
            if (villa == null)
            {
                return NotFound(SetApiResponse<object>(false, HttpStatusCode.NotFound, [string.Format(AppConstants.VillaNotFound, id)]));
            }

            await _dbVilla.DeleteAsync(villa);

            return Ok(SetApiResponse<object>(true, HttpStatusCode.NoContent, [$"Villa with ID {id} has been deleted"]));
        }
        #endregion
    }
}
