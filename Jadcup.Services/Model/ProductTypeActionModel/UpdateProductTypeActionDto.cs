namespace Jadcup.Services.Model.ProductTypeActionModel
{
    public class UpdateProductTypeActionDto
    {
        public short ProductTypeActionId { get; set; }
        public short? ProductTypeId { get; set; }
        public short? ActionId { get; set; }
        public int? OrderTypeId { get; set; }
        public sbyte? SequenceNo { get; set; }

    }
}