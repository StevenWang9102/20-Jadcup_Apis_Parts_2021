using System.ComponentModel.DataAnnotations;

namespace Jadcup.Services.Model.ProductModel
{
    public class AddProductDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Base Product Id is required.")]
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
    public class AddOutSourceProdDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Code is required.")]
        public string ProductCode { get; set; }
        
        [Required(ErrorMessage = "Product Type is required.")]
        public short? ProductTypeId { get; set; }
        // [Required(ErrorMessage = "Alarm stock Limit Level is required.")]
        public short? PackagingTypeId { get; set; }
        public decimal AlermLimit { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public short? MinOrderQuantity { get; set; }
    }    
}