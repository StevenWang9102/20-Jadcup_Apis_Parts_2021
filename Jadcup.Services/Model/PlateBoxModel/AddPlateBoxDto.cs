using System.Collections.Generic;

namespace Jadcup.Services.Model.PlateBoxModel
{
    public class AddPlateBoxDto
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public string RawMaterialBoxId { get; set; }

    }

    public class AddPlateBoxDto2
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int quantity { get; set; }
    }

    public class AddAndUpdatePlateBoxDto
    {
        public List<AddPlateBoxDto2> AddList { get; set; }
        public List<UpdatePlateBoxDto2> UpdateList { get; set; }
        public List<string> DeleteBoxIdList { get; set; }
    }
}