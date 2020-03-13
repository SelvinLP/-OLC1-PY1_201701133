using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Analizador_Lexema
{
    class Lista_XML
    {
        public String Nombre {get;set;}
        public String Contenido { get; set; }
        public String ContenidoXML { get; set; }
        public Boolean Tipo { get; set; } //false es token y true error
        public Lista_XML(String nomb,String Cont,String ContXML,Boolean tp) {
            this.Nombre = nomb;
            this.Contenido = Cont;
            this.ContenidoXML = ContXML;
            this.Tipo = tp;
        }
    }
}
