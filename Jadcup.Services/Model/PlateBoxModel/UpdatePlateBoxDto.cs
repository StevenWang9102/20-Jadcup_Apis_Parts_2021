namespace Jadcup.Services.Model.PlateBoxModel
{
    public class UpdatePlateBoxDto
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int PlateBoxId { get; set; }
        public string RawMaterialBoxId { get; set; }
    }

    public class UpdatePlateBoxDto2
    {
        public short? PlateId { get; set; }
        public string BoxId { get; set; }
        public int quantity { get; set; }
    }
}