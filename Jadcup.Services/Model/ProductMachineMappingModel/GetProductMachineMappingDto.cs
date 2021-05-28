using Jadcup.Services.Model.ActionModel;
using Jadcup.Services.Model.BaseProductModel;
using Jadcup.Services.Model.MachineModel;

namespace Jadcup.Services.Model.ProductMachineMappingModel
{
    public class GetProductMachineMappingDto
    {
        public short MappingId { get; set; }
        public short? MachineId { get; set; }
        public short? BaseProductId { get; set; }
        public short? ActionId { get; set; }

        public GetActionDto Action { get; set; }
        public GetBaseProductDto3 BaseProduct { get; set; }
        public GetMachineDto Machine { get; set; }
    }
}