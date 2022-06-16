using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTheoryGenerator2._0
{
    public class Key
    {
        public string key { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string N3 { get; set; }
        public string N4 { get; set; }
        public string N5 { get; set; }
        public string N6 { get; set; }
        public string N7 { get; set; }

        public Key() { }

        public Key(string _key, string _N1, string _N2, string _N3, string _N4, string _N5, string _N6, string _N7)
        {
            this.key = _key;
            this.N1 = _N1;
            this.N2 = _N2;
            this.N3 = _N3;
            this.N4 = _N4;
            this.N5 = _N5;
            this.N6 = _N6;
            this.N7 = _N7;
        }
    }
}
