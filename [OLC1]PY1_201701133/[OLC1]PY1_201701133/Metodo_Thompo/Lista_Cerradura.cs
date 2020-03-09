using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Metodo_Thompo
{
    class Nodo_Transicion {
        public String Cont_Transicion;
        public int Pos_Transicion;
        public Nodo_Transicion(String Cont_T,int Pos_T) {
            this.Cont_Transicion = Cont_T;
            this.Pos_Transicion = Pos_T;
        }
    }
    class Lista_Cerradura
    {
        private int Nombre_Estado;
        public Boolean Estado=false;//ya esta insertado o no
        public List<int> Estados_Epsilon;
        public ArrayList Transiciones;
        public List<Nodo_Transicion> Transicion_Final;
        public Lista_Cerradura(int Nomb) {
            this.Nombre_Estado = Nomb;
            Estados_Epsilon = new List<int>();
            Transiciones = new ArrayList();
            Transicion_Final = new List<Nodo_Transicion>();
        }
        public int Get_Nombre_Estado() {
            return this.Nombre_Estado;
        }
        public void  Set_Contenido(int est)
        {
            Estados_Epsilon.Add(est);
        }
        public void Set_Transicion(String Cont_Trans,int Estado_Final) {
            //no insertar si ya existe
            Boolean bandera = false;
            for (int x=0;x<Transiciones.Count;x++) {
                if (((Nodo_Transicion)Transiciones[x]).Cont_Transicion.Equals(Cont_Trans) && ((Nodo_Transicion)Transiciones[x]).Pos_Transicion==Estado_Final) {
                    bandera = true;
                    break;
                }
            }
            if (!bandera) {
                Nodo_Transicion nuevo = new Nodo_Transicion(Cont_Trans, Estado_Final);
                Transiciones.Add(nuevo);
            }
            
        }
    }
}
