using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Metodo_Thompo
{
    class Lista_Transiciones
    {
        int primero;
        int siguiente;
        int direccion;
        string Id_Cambio;
        public Lista_Transiciones(int p, int sig, String Id_Cambi, int dir) {
            this.primero = p;
            this.siguiente = sig;
            this.Id_Cambio = Id_Cambi;
            this.direccion = dir;
        }
        public int Get_Primero()
        {
            return this.primero;
        }
        public int Get_Siguiente() {
            return this.siguiente;
        }
        public String Get_IdCambio() {
            return this.Id_Cambio;
        }
        public int Get_Direccion()
        {
            return this.direccion;
        }

    }
}
