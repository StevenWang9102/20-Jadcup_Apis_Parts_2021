using System;
using Jadcup.Services.Model.BoxModel;
using Jadcup.Services.Model.PlateModel;
using Jadcup.Services.Model.RawMaterialBoxModel;

namespace Jadcup.Services.Model.PlateBoxModel
{
    public class GetPlateBoxDto
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int PlateBoxId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string RawMaterialBoxId { get; set; }

        public GetBoxDto2 Box { get; set; }
        public GetRawMaterialBoxDto RawMaterialBox { get; set; }        
        public GetPlateDto Plate { get; set; }
    }
    public class GetPlateBoxDto2
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int PlateBoxId { get; set; }
        public ulong? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string RawMaterialBoxId { get; set; }

        public GetBoxDto2 Box { get; set; }
        public GetRawMaterialBoxDto RawMaterialBox { get; set; }        

    }    
}