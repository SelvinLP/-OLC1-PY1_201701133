using _OLC1_PY1_201701133.Metodo_Thompo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Nodo_Arbol
    {
        public String Indentificador;
        public Nodo_Arbol Izquierda;
        public Nodo_Arbol Derecha;
        //control de estados
        public int Primero;
        public int Ultimo;
        public Nodo_Arbol(String Id)
        {
            this.Indentificador = Id;
        }

    }
    class Metodo_Thompson
    {
        //definicion de listas
        ArrayList Lista_ExpRegular;
        ArrayList L_Transiciones;
        String Nombre_ER;
        //Arbol
        Nodo_Arbol Raiz;
        //control de estados
        int Control_Est = 0;
        public Metodo_Thompson() {
            L_Transiciones = new ArrayList();
        }

        public void Analizar_Metodo(String nm,ArrayList tem) {
            Control_Est = 0;
            this.Lista_ExpRegular = tem;
            this.Nombre_ER = nm;
            //llamamos al metodo del arbol
            //Console.WriteLine("----NUEVO ARBOL-----");
            Nodo_Arbol nuevo = new Nodo_Arbol(Lista_ExpRegular[0].ToString());
            Raiz = nuevo;
            for (int cant=1;cant<Lista_ExpRegular.Count;cant++) {
                nuevo = new Nodo_Arbol(Lista_ExpRegular[cant].ToString());
                Insertar_Arbol(false, this.Raiz,nuevo);
            }

            //creamos los estados
            Creacion_Estados(this.Raiz);
            //asignacion de estaodos
            Asigancion_Estados(this.Raiz);
            //Graficar_AFND();
            //imprimimos en consola el arbol
            Console.WriteLine("RECORRIDO");
            RecorridoInorden(this.Raiz);
            Console.WriteLine("TRANSICIONES");
            for (int i = 0; i < L_Transiciones.Count; i++)
            {
                Console.WriteLine("Primero:"+ ((Lista_Transiciones)L_Transiciones[i]).Get_Primero()+"   Siguiente:"+ ((Lista_Transiciones)L_Transiciones[i]).Get_Siguiente()+"  ID:"+ ((Lista_Transiciones)L_Transiciones[i]).Get_IdCambio());
            }
        }

        //creacion de arbol
        public Boolean Insertar_Arbol(Boolean bandera,Nodo_Arbol rz,Nodo_Arbol nuevo) {

            if (rz.Izquierda != null)
            {
                bandera = Insertar_Arbol(bandera, rz.Izquierda, nuevo);
            }
            if (!bandera)
            {
                //miramos si se debe insertar porque si sigue cadena ya no puede tener hijos
                if (rz.Indentificador.Equals("+") || rz.Indentificador.Equals("*") || rz.Indentificador.Equals("|") || rz.Indentificador.Equals("?") || rz.Indentificador.Equals("."))
                {
                    //comprobamos si es nodo final hio
                    if (rz.Izquierda == null && rz.Derecha == null)
                    {
                        rz.Izquierda = nuevo;
                        bandera = true;
                    }
                    else if ((rz.Indentificador.Equals("+") || rz.Indentificador.Equals("*") || rz.Indentificador.Equals("?")) && rz.Izquierda == null)
                    {
                        //insertamos izquierda
                        rz.Izquierda = nuevo;
                        bandera = true;
                    }
                    else if (rz.Indentificador.Equals("|") || rz.Indentificador.Equals("."))
                    {
                        if (rz.Izquierda != null && rz.Derecha == null)
                        {
                            //insertamos derecha
                            rz.Derecha = nuevo;
                            bandera = true;
                        }
                    }
                }

            }
            if (rz.Derecha != null)
            {
                bandera = Insertar_Arbol(bandera, rz.Derecha, nuevo);
            }
            return bandera;
        }

        public void Creacion_Estados(Nodo_Arbol rz) {
            if (rz.Izquierda != null)
            {
                Creacion_Estados(rz.Izquierda);
            }
            if (rz.Derecha != null)
            {
                Creacion_Estados(rz.Derecha);
            }
            //Validaciones
            if (rz.Izquierda == null && rz.Derecha == null)
            {
                rz.Primero = Control_Est;
                Control_Est++;
                rz.Ultimo = Control_Est;
                Control_Est++;
            }else if (rz.Indentificador.Equals("."))
            {
                rz.Derecha.Primero = rz.Izquierda.Ultimo;
                rz.Primero = rz.Izquierda.Primero;
                rz.Ultimo = rz.Derecha.Ultimo;
            }else if (rz.Indentificador.Equals("|") || rz.Indentificador.Equals("*") || rz.Indentificador.Equals("?") || rz.Indentificador.Equals("+"))
            {
                rz.Primero = Control_Est;
                Control_Est++;
                rz.Ultimo = Control_Est;
                Control_Est++;
            }


        }

        public void Asigancion_Estados(Nodo_Arbol rz) {
            if (rz.Izquierda != null)
            {
               Asigancion_Estados(rz.Izquierda);
            }
            if (rz.Derecha != null)
            {
               Asigancion_Estados(rz.Derecha);
            }

            //validaciones
            if (rz.Izquierda == null && rz.Derecha == null)
            {
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Ultimo, rz.Indentificador);
                L_Transiciones.Add(nuevo);
            }
            else if (rz.Indentificador.Equals("|"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε");
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Primero, rz.Derecha.Primero, "ε");
                //ultimos
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε");
                Lista_Transiciones nuevo4 = new Lista_Transiciones(rz.Derecha.Ultimo, rz.Ultimo, "ε");
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);
                L_Transiciones.Add(nuevo4);
            }
            else if (rz.Indentificador.Equals("*"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε");
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Izquierda.Primero, "ε");

                //ultimo
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Primero, rz.Ultimo, "ε");
                Lista_Transiciones nuevo4 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε");
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);
                L_Transiciones.Add(nuevo4);
            }
            else if (rz.Indentificador.Equals("?"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε");

                //ultimo
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Primero, rz.Ultimo, "ε");
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε");
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);

            }
            else if (rz.Indentificador.Equals("+"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε");
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Izquierda.Primero, "ε");
                //ultimo
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε");
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);
            }
        }

        public void RecorridoInorden(Nodo_Arbol rz)
        {
            Console.WriteLine(rz.Indentificador + "\t Primero:" + rz.Primero + "\t Ultimo:" + rz.Ultimo);
            if (rz.Izquierda != null)
            {
                RecorridoInorden(rz.Izquierda);
            }
            if (rz.Derecha != null)
            {
                RecorridoInorden(rz.Derecha);
            }
        }

        public void Graficar_AFND() {
            String CadenaImprimir = "digraph AFD { " + '\n';
            CadenaImprimir += "graph [label=\"AFND: \", labelloc=t, fontsize=20]; ";
            CadenaImprimir += "rankdir=LR;";
            CadenaImprimir += "edge [color=blue];";
            CadenaImprimir += "node [color = mediumseagreen];";
            //creacion de nodos
            for (int  i=0;i<Control_Est-1;i++) {
                CadenaImprimir += "\"S" +i+ "\"" + "[ label= ]" + '\n';
            }
            //creacion de transiciones
            for (int i = 0; i < L_Transiciones.Count; i++)
            {
                CadenaImprimir += "\"S" +((Lista_Transiciones)L_Transiciones[i]).Get_Primero()+ "\"" + "->\"S" + ((Lista_Transiciones)L_Transiciones[i]).Get_Siguiente() + "\"" + "[label=\"" + ((Lista_Transiciones)L_Transiciones[i]).Get_IdCambio() + "\"];" + '\n';
            }
            //CadenaImprimir += "secret_node [style=invis];\n";
            //CadenaImprimir += "secret_node -> S0 [label=\"inicio\"];";
            CadenaImprimir += '\n' + "}";

            //creacion del .dot
            string path = @"AFND.dot";
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(CadenaImprimir);
                    fs.Write(info, 0, info.Length);
                }
                //Process.Start(path);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
