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
        string Id_Cambio;
        public Lista_Transiciones(int p,int sig, String Id_Cambi) {
            this.primero = p;
            this.siguiente = sig;
            this.Id_Cambio = Id_Cambi;
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

    }
}
