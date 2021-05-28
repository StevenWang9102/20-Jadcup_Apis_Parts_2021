using Jadcup.Services.Model.BaseProductModel;
using Jadcup.Services.Model.CustomerModel;
using Jadcup.Services.Model.PackagingTypeModel;
using Jadcup.Services.Model.PalletStackingModel;
using Jadcup.Services.Model.PlateTypeModel;
using Jadcup.Services.Model.StockModel;

namespace Jadcup.Services.Model.ProductModel
{
    public class GetProductDto
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
        public GetStockDto ProductStock { get; set; }
        public GetStockDto SemiStock { get; set; }
        public decimal? MinPrice { get; set; }
        public ulong? Manufactured { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short PalletStackingId { get; set; }
        public string ProductCode { get; set; }

        public GetBaseProductDto BaseProduct { get; set; }
        public GetCustomerDto2 Customer { get; set; }
        public GetPlateTypeDto PlateType { get; set; }
        public GetPalletStackingDto PalletStacking { get; set; }

    }

    public class GetProductDto2 
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
        public ulong? Active { get; set; }
        public int? ProductMsl { get; set; }
        public int? SemiMsl { get; set; }
        public ulong? Manufactured { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short PalletStackingId { get; set; }
        public string ProductCode { get; set; }        
    }

    public class GetProductDto3 
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? BaseProductId { get; set; }
        public ulong Plain { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public string Images { get; set; }
        public short? PlateTypeId { get; set; }
        public short? MarginOfError { get; set; }
        public short? MinOrderQuantity { get; set; }
        public int? ProductMsl { get; set; }
        public int? SemiMsl { get; set; }
        public decimal? MinPrice { get; set; }
        public ulong? Manufactured { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short PalletStackingId { get; set; }
        public string ProductCode { get; set; }

        public GetPalletStackingDto PalletStacking { get; set; }
        public GetBaseProductDto3 BaseProduct { get; set; }
        public GetCustomerDto2 Customer { get; set; }
    }
    public class GetProductDto4 
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? BaseProductId { get; set; }
        public ulong Plain { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public string Images { get; set; }
        public short? PlateTypeId { get; set; }
        public short? MarginOfError { get; set; }
        public short? MinOrderQuantity { get; set; }
        public int? ProductMsl { get; set; }
        public int? SemiMsl { get; set; }
        public decimal? MinPrice { get; set; }
        public ulong? Manufactured { get; set; }
        public sbyte LogoType { get; set; }
        public string LogoUrl { get; set; }
        public short PalletStackingId { get; set; }
        public string ProductCode { get; set; }
        public GetBaseProductDto3 BaseProduct { get; set; }
        
    }

    public class GetProductDtoImage
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public string Images { get; set; }
    }
}