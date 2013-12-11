using System.Collections.Generic;

namespace IntranetGLM2013.Models
{

    public enum LunchItemCategory : int
    {
        Bebidas = 1
        , Entradas = 2
        , Proteinas = 3
        , Carbohidratos = 4
        , Vegetales = 5
        , Postres = 6
        , Especiales = 7
    }

    public class LunchItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public LunchItemCategory Category { get; set; }
        public bool Status { get; set; }
        //public List<DailyLunch> DailyLunches { get; set; }
    }

}