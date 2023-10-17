using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required double Cost { get; set; }
        public required int RatingId { get; set; }
        public required int FormatId { get; set; }
        public required int DirectorId { get; set; }
        public required int InStkQty { get; set; }
        public string? ImagePath { get; set; }

        public string RatingDescription { get; set; }
        public string FormatDescription { get; set; }

        [DisplayName("Director")]
        public string DirectorFullName { get; set; }

    }
}
