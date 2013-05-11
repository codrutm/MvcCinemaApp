using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebsite.Models
{
    public class ProgramModel
    {
        public int ProgramId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    }
}