using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Lista_LexemaE
    {
        private String Nombre;
        private String Contenido;
        public Lista_LexemaE(String nombre, String contenido)
        {
            this.Nombre = nombre;
            this.Contenido = contenido;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public String getContenido()
        {
            return Contenido;
        }
    }
}
