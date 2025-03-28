﻿using MagicVilla_Utility.DTO.VillaNumber;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(int id, VillaNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
