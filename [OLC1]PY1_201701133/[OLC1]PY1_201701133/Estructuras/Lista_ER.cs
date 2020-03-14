using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Lista_ER
    {
        private String Nombre;
        private ArrayList ExpresionRegular;
        public List<int> L_Estados_Aceptacion;
        public Lista_ER(String nombre)
        {
            this.Nombre = nombre;
            ExpresionRegular = new ArrayList();
            this.L_Estados_Aceptacion = new List<int>();
        }
        //Metodos de Acceso
        public String getNombre()
        {
            return Nombre;
        }
        public ArrayList getER()
        {
            return ExpresionRegular;
        }
        public void setER(String Datos)
        {
            ExpresionRegular.Add(Datos);
        }
    }
}
