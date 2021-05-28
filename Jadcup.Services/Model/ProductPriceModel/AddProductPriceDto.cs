using System.ComponentModel.DataAnnotations;
using Jadcup.Services.Model.CustomerGroupModel;
namespace Jadcup.Services.Model.ProductPriceModel
{
    public class AddProductPriceDto
    {
        [Required(ErrorMessage = "Qty is required.")]        
        public int Quantiy { get; set; }
        [Required(ErrorMessage = "Price is required.")]                
        public decimal? Price { get; set; }
        public string ProductPriceId { get; set; }
        [Required(ErrorMessage = "BaseProduct is required.")]  
        public short? BaseProductId { get; set; }
        public string Description { get; set; }
        public short? Group1Id { get; set; }
 
    }
    public class GetProductPriceDto
    {
        public int Quantiy { get; set; }
        public decimal? Price { get; set; }
        public string ProductPriceId { get; set; }
        public short? BaseProductId { get; set; }
        public string Description { get; set; }
        public short? Group1Id { get; set; }
        public CustomerGroup1.GetGroup1Dto  Group1{ get; set; }                
    }    
}
