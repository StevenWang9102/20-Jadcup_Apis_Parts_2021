namespace Jadcup.Services.Model.PoDetailModel
{
    public class AddPoDetailDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public short? RawMaterialId { get; set; }
        public string Comments { get; set; }
        
        public decimal? UnitPrice { get; set; }
    }
}