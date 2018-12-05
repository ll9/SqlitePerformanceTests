using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SqlitePerformanceTests.Models
{
    class Lichtpunkt
    {
        [Key]
        public int Id { get; set; }
        public string Ort { get; set; }
        public string Straße { get; set; }
        public int Hausnummer { get; set; }
    }
}
