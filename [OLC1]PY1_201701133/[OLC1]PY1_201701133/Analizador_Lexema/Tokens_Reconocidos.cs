using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Analizador_Lexema
{
    class Tokens_Reconocidos
    {
        private String Lexema;
        private String Descripcion;
        private int Fila;
        private int Columna;
        List<Lista_XML> ListaXML;
        public Tokens_Reconocidos(String lexema, String descripcion, int fila, int columna)
        {
            this.Lexema = lexema;
            this.Descripcion = descripcion;
            this.Fila = fila;
            this.Columna = columna;
            ListaXML = new List<Lista_XML>();
        }
        //metodos de acceso
        public String getLexema()
        {
            return Lexema;
        }
        public String getDescripcion()
        {
            return Descripcion;
        }
        public int getFila()
        {
            return Fila;
        }
        public int getColumna()
        {
            return Columna;
        }
    }
}
