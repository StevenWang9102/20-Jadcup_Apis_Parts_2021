namespace Jadcup.Services.Model.ProductModel
{
    public class UpdateProductDto
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? BaseProductId { get; set; }
        public ulong Plain { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public string Images { get; set; }
        public short? PlateTypeId { get; set; }
        public short? PackagingTypeId { get; set; }
        public short? MarginOfError { get; set; }
        public short? MinOrderQuantity { get; set; }
        public int? ProductMsl { get; set; }
        public int? SemiMsl { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short? PalletStackingId { get; set; }
        public string ProductCode { get; set; }        
    }
}