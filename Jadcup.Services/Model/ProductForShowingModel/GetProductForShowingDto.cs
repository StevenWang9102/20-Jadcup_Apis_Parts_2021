using System.Collections.Generic;
using Jadcup.Common.Context;
using Jadcup.Services.Model.PackagingTypeModel;
using Jadcup.Services.Model.ProductModel;
using Jadcup.Services.Model.ProductPriceModel;

namespace Jadcup.Services.Model.ProductForShowingModel
{
    public class GetProductForShowingDto
    {
        public short BaseProductId { get; set; }
        public string BaseProductName { get; set; }
        public string ProductCode { get; set; }
        // public short? PackagingTypeId { get; set; }
        public string RawmaterialDesc { get; set; }

        public GetPackagingTypeDto PackagingType { get; set; }
        public string SampleImage { get; set; }
        public List<GetProductDtoImage> Product { get; set; }
        public List<GetProductPriceDto> ProductPrice { get; set; }    
    }
}