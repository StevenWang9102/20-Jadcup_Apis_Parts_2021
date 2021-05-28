using Jadcup.Services.Model.ActionModel;
using Jadcup.Services.Model.OrderTypeModel;

namespace Jadcup.Services.Model.ProductTypeActionModel
{
    public class GetProductTypeActionDto
    {
        public short ProductTypeActionId { get; set; }
        public short? ProductTypeId { get; set; }
        public short? ActionId { get; set; }
        public int? OrderTypeId { get; set; }
        public sbyte? SequenceNo { get; set; }

        public GetActionDto Action { get; set; }
        public GetOrderTypeDto OrderType { get; set; }
    }
}
