using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class JD_Commodity_001
    {
        public int Id { get; set; }

        public long? ProductId { get; set; }

        public int? CategoryId { get; set; }

        public string Title { get; set; }

        public decimal? Price { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? UpDateTime { get; set; }
    }
}
