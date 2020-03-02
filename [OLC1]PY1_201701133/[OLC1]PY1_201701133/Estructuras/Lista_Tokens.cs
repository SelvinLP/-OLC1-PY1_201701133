using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Lista_Tokens
    {
        private int ID;
        private String Lexema;
        private String Descripcion;
        private int Fila;
        private int Columna;

        public Lista_Tokens(int id, String lexema, String descripcion, int fila, int columna) {
            this.ID = id;
            this.Lexema = lexema;
            this.Descripcion = descripcion;
            this.Fila = fila;
            this.Columna = columna;
        }
        //metodos de acceso
        public int getID()
        {
            return ID;
        }
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
