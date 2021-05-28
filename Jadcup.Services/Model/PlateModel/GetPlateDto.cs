using System;
using System.Collections.Generic;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.PlateTypeModel;
using Jadcup.Services.Model.RawMaterialBoxModel;
using Jadcup.Services.Model.ShelfPlateModel;
using Jadcup.Services.Model.TempZoneModel;
using Jadcup.Services.Model.PlateBoxModel;

namespace Jadcup.Services.Model.PlateModel
{
    public class GetPlateDto
    {
        public short PlateId { get; set; }
        public string PlateCode { get; set; }
        public short? PlateTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ulong? Package { get; set; }

        public GetPlateTypeDto PlateType { get; set; }

        public GetShelfPlateDto Shelf { get; set; }
        public GetTempZoneDto2 TmpZone { get; set; } 
        public List<GetPlateBoxDto2> PlateBox { get; set; }               
    }

    public class GetPlateDto2
    {
        public short PlateId { get; set; }
        public string PlateCode { get; set; }
        public short? PlateTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public GetPlateTypeDto PlateType { get; set; }
        public List<GetBoxDto2> Box { get; set; }
        public List<GetRawMaterialBoxDto> RawMaterialBox { get; set; }
    }
}