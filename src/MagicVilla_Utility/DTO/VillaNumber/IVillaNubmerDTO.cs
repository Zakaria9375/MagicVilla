﻿using MagicVilla_Utility.DTO.Villa;

namespace MagicVilla_Utility.DTO.VillaNumber
{
    public interface IVillaNubmerDTO
    {
        int Code { get; set; }
        int VillaID { get; set; }
        string SpecialDetails { get; set; }
        public VillaDTO Villa { get; set; }

    }
}
