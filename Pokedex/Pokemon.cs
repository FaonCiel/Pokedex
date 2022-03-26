using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class Name
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Genus
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Description
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Stat
    {
        public string name { get; set; }
        public int stat { get; set; }
    }
   
      

    public class Pokemon
    {
        public int id { get; set; }
        public Name name { get; set; }
        public List<string> types { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public Genus genus { get; set; }
        public Description description { get; set; }
        public List<Stat> stats { get; set; }
        public int lastEdit { get; set; }
        public int gen { get; set; }

        public void getgen(int id)
        {
            if (this.id <= 151)
                this.gen = 1;
            else if (this.id >= 152 && this.id <= 251)
                this.gen =2;
            else if (this.id >= 252 && this.id <= 386)
                this.gen = 3;
            else if (this.id >= 387 && this.id <= 493)
                this.gen = 4;
            else if (this.id >= 494 && this.id <= 649)
                this.gen = 5;
            else if (this.id >= 650 && this.id <= 721)
                this.gen = 6;
            else if (this.id >= 722 && this.id <= 802)
                this.gen = 7;
            else if (this.id >= 803)
                this.gen = 8;
           

        }
    }

    
}
