using System;
using System.Collections.Generic;
using System.Text;
using Jadcup.Services.Model.ShelfModel;

namespace Jadcup.Services.Model.ZoneModel
{
    public class GetZoneDto
    {
        public sbyte ZoneId { get; set; }
        public string ZoneCode { get; set; }
    }

    public class GetZoneDto2
    {
        public sbyte ZoneId { get; set; }
        public string ZoneCode { get; set; }

        public List<GetShelfDto2> Shelf { get; set; }
    }
}
