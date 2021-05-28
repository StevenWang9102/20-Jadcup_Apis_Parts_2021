namespace Jadcup.Services.Model.ProductTypeActionModel
{
    public class AddProductTypeActionDto
    {
        public short? ProductTypeId { get; set; }
        public short? ActionId { get; set; }
        public int? OrderTypeId { get; set; }
        public sbyte? SequenceNo { get; set; }

    }
}