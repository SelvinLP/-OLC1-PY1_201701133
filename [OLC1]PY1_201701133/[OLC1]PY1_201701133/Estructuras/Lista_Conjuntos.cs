using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Lista_Conjuntos
    {
        private String Nombre;
        private String Contenido;
        private String Tipo_Conjunto;
        public Lista_Conjuntos(String nombre, String contenido,String Tipo_CJ)
        {
            this.Nombre = nombre;
            this.Contenido = contenido;
            this.Tipo_Conjunto = Tipo_CJ;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public String getContenido()
        {
            return Contenido;
        }
        public String getTipo_Conjunto() {
            return Tipo_Conjunto;
        }
    }
}
