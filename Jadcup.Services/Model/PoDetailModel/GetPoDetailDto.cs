using Jadcup.Services.Model.RawMaterialModel;

namespace Jadcup.Services.Model.PoDetailModel
{
    public class GetPoDetailDto
    {
        public int PoDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? PoId { get; set; }
        public short? RawMaterialId { get; set; }
        public ulong? Completed { get; set; }
        public string Comments { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? PackagingQty { get; set; }
        public bool OutSourceProd { get; set; }
        public GetRawMaterialDto RawMaterial { get; set; }
    }
}