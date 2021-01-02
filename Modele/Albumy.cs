using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuzykaAlbumy.Modele
{
    public class Albumy
    {
        public int ID { get; set; }
        public string nazwaAlbumu { get; set; }
        public string wykonawca { get; set; }
        [DataType(DataType.Date)]
        public DateTime dataWydania { get; set; }
        public string gatunekMuzyczny { get; set; }
        public string wersjaAlbumu { get; set; }
        [DataType(DataType.Date)]
        public DateTime dataZakupu { get; set; }
        public decimal cena { get; set; }
    }
}
