namespace Jadcup.Services.Model.ProductMachineMappingModel
{
    public class AddProductMachineMappingDto
    {
        public short? MachineId { get; set; }
        public short? BaseProductId { get; set; }
        public short? ActionId { get; set; }
    }
}