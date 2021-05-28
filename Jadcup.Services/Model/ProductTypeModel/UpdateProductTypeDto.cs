namespace Jadcup.Services.Model.ProductTypeModel
{
    public class UpdateProductTypeDto
    {
        public short ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public short? SleeveQty { get; set; }
        public short? SleevePkt { get; set; }
    }
}