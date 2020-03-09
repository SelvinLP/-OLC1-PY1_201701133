﻿using _OLC1_PY1_201701133.Metodo_Thompo;
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
        ArrayList L_Cerradura;
        List<String> NodoHijos;
        //Nombre de ER
        String Nombre_ER;
        //Arbol
        Nodo_Arbol Raiz;
        //control de estados
        int Control_Est = 0;
        //Cerradura
        int NumeroEstadoAFD = 0;
        public Metodo_Thompson() {
            L_Transiciones = new ArrayList();
            L_Cerradura = new ArrayList();
            NodoHijos = new List<String>();
        }

        public void Analizar_Metodo(String nm, ArrayList tem) {
            Control_Est = 0;
            this.Lista_ExpRegular = tem;
            this.Nombre_ER = nm;
            //llamamos al metodo del arbol
            Nodo_Arbol nuevo = new Nodo_Arbol(Lista_ExpRegular[0].ToString());
            Raiz = nuevo;
            for (int cant = 1; cant < Lista_ExpRegular.Count; cant++) {
                nuevo = new Nodo_Arbol(Lista_ExpRegular[cant].ToString());
                Insertar_Arbol(false, this.Raiz, nuevo);
            }
            //creamos los estados
            Creacion_Estados(this.Raiz);
            NodoHijos = NodoHijos.Distinct().ToList();
            //asignacion de estaodos
            Asigancion_Estados(this.Raiz);
            Graficar_AFND();

            //Analisis de cerradura
            Analisis_Cerradura(this.Raiz.Primero);
            Graficar_AFD();
            Console.WriteLine("TRANSICICIONES AFD");
            for (int i = 0; i < L_Cerradura.Count; i++)
            {
                Console.Write("S"+((Lista_Cerradura)L_Cerradura[i]).Get_Nombre_Estado()+": ");
                List<int> prueba = ((Lista_Cerradura)L_Cerradura[i]).Estados_Epsilon;
                foreach (int s in prueba) {
                    Console.Write(" "+s);
                }
                Console.WriteLine();
                Console.WriteLine("Direcciones");
                ArrayList pruebaA = ((Lista_Cerradura)L_Cerradura[i]).Transiciones;
                for (int x=0;x<pruebaA.Count;x++) {
                    Console.WriteLine("Contenido: "+((Nodo_Transicion)pruebaA[x]).Cont_Transicion+"Hacia: "+ ((Nodo_Transicion)pruebaA[x]).Pos_Transicion);
                }
                    
            }
        }

        //creacion de arbol
        public Boolean Insertar_Arbol(Boolean bandera, Nodo_Arbol rz, Nodo_Arbol nuevo) {

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
                //agregamos a lista de nodos hijos
                NodoHijos.Add(rz.Indentificador);
            } else if (rz.Indentificador.Equals("."))
            {
                rz.Primero = rz.Izquierda.Primero;
                rz.Ultimo = rz.Derecha.Ultimo;
                //cambios
                rz.Derecha.Primero = rz.Izquierda.Ultimo;
                //asignamos valor que cambiaremos
                int nueva_pos = rz.Izquierda.Ultimo;
                //validacion
                rz = rz.Derecha;
                while (rz != null)
                {
                    if (rz.Indentificador.Equals("."))
                    {
                        rz.Primero = nueva_pos;
                        rz = rz.Izquierda;
                    }
                    else
                    {
                        rz.Primero = nueva_pos;
                        break;

                    }
                }
            }
            else if (rz.Indentificador.Equals("|") || rz.Indentificador.Equals("*") || rz.Indentificador.Equals("?") || rz.Indentificador.Equals("+"))
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
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Ultimo, rz.Indentificador, 0);
                L_Transiciones.Add(nuevo);
            }
            else if (rz.Indentificador.Equals("|"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε", 0);
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Primero, rz.Derecha.Primero, "ε", 0);
                //ultimos
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε", 0);
                Lista_Transiciones nuevo4 = new Lista_Transiciones(rz.Derecha.Ultimo, rz.Ultimo, "ε", 0);
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);
                L_Transiciones.Add(nuevo4);
            }
            else if (rz.Indentificador.Equals("*"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε", 0);
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Izquierda.Primero, rz.Izquierda.Ultimo, "ε", 1);

                //ultimo
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Primero, rz.Ultimo, "ε", 0);
                Lista_Transiciones nuevo4 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε", 0);
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);
                L_Transiciones.Add(nuevo4);
            }
            else if (rz.Indentificador.Equals("?"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε", 0);

                //ultimo
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Primero, rz.Ultimo, "ε", 0);
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε", 0);
                L_Transiciones.Add(nuevo);
                L_Transiciones.Add(nuevo2);
                L_Transiciones.Add(nuevo3);

            }
            else if (rz.Indentificador.Equals("+"))
            {
                //iniciales
                Lista_Transiciones nuevo = new Lista_Transiciones(rz.Primero, rz.Izquierda.Primero, "ε", 0);
                Lista_Transiciones nuevo2 = new Lista_Transiciones(rz.Izquierda.Primero, rz.Izquierda.Ultimo, "ε", 1);
                //ultimo
                Lista_Transiciones nuevo3 = new Lista_Transiciones(rz.Izquierda.Ultimo, rz.Ultimo, "ε", 0);
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
            String CadenaImprimir = "digraph AFND { " + '\n';
            CadenaImprimir += "graph [label=\"AFND: " + Nombre_ER + "\", labelloc=t, fontsize=20];\n";
            CadenaImprimir += "rankdir=LR;\n";
            CadenaImprimir += "edge [color=blue];\n";
            CadenaImprimir += "node [color = mediumseagreen];\n";
            //creacion de nodos
            for (int x = 0; x < Control_Est - 1; x++) {
                for (int i = 0; i < L_Transiciones.Count; i++)
                {
                    if (((Lista_Transiciones)L_Transiciones[i]).Get_Primero() == x || ((Lista_Transiciones)L_Transiciones[i]).Get_Siguiente() == x)
                    {
                        //crea el nodo solosi hay una transicion con ella
                        CadenaImprimir += "\"S" + x + "\"" + "[ label=S" + x + " ]" + '\n';
                        break;
                    }
                }
            }

            //creacion de transiciones
            for (int i = 0; i < L_Transiciones.Count; i++)
            {
                String direccion = "";
                if (((Lista_Transiciones)L_Transiciones[i]).Get_Direccion() == 1) {
                    direccion = ",dir=back";
                }
                string tem = ((Lista_Transiciones)L_Transiciones[i]).Get_IdCambio();
                tem = tem.Replace("\"", "\\\"");
                CadenaImprimir += "\"S" + ((Lista_Transiciones)L_Transiciones[i]).Get_Primero() + "\"" + "->\"S" + ((Lista_Transiciones)L_Transiciones[i]).Get_Siguiente() + "\"" + "[label=\"" + tem + "\" " + direccion + "];" + '\n';
            }

            CadenaImprimir += '\n' + "}";

            //creacion del .dot
            string path = @"AFND" + Nombre_ER + ".dot";
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
            String comando = "dot -Tpng AFND" + Nombre_ER + ".dot -o AFND" + Nombre_ER + ".png";
            EjecutarComandoCMD(comando);
        }

        public void Analisis_Cerradura(int Inicio) {
            //primera iteracion
            Lista_Cerradura nuevo_C = new Lista_Cerradura(NumeroEstadoAFD);
            nuevo_C.Set_Contenido(Inicio);
            Creacion_EstadoAFD(Inicio, nuevo_C);
            L_Cerradura.Add(nuevo_C);
            NumeroEstadoAFD++;

            int Ciclo_Nuevos_Estados = 1;
            while (Ciclo_Nuevos_Estados >=1)
            {
                //ir (A,a)=posicicones y asignar estado
                #region buscar
                ArrayList Ultima_Insertada = null;
                Lista_Cerradura Ultima_Faltante = null;
                for (int buscar = 0; buscar < L_Cerradura.Count; buscar++)
                {
                    if (((Lista_Cerradura)L_Cerradura[buscar]).Estado.Equals(false))
                    {
                        //ulimo insertado
                        Ultima_Faltante = ((Lista_Cerradura)L_Cerradura[buscar]);
                        Ultima_Insertada = ((Lista_Cerradura)L_Cerradura[buscar]).Transiciones;
                        break;
                    }
                }
                #endregion

                if (Ultima_Faltante == null)
                {
                    //termina el metodo
                }
                else {
                    //el metodo sigue.    Recorremos los hijos
                    foreach (string hijos in NodoHijos)
                    {
                        Lista_Cerradura nuevo_C_ciclo = new Lista_Cerradura(NumeroEstadoAFD);
                        for (int x = 0; x < Ultima_Insertada.Count; x++)
                        {
                            if (((Nodo_Transicion)Ultima_Insertada[x]).Cont_Transicion.Equals(hijos))
                            {
                                nuevo_C_ciclo.Set_Contenido(((Nodo_Transicion)Ultima_Insertada[x]).Pos_Transicion);
                                Creacion_EstadoAFD(((Nodo_Transicion)Ultima_Insertada[x]).Pos_Transicion, nuevo_C_ciclo);
                                
                            }
                        }

                        //Comprobando si el estado ya existe (se valida su lista de epsilon)
                        Boolean bandera = false;
                        for (int posicion_L = 0; posicion_L < L_Cerradura.Count; posicion_L++)
                        {
                            //quitamos repetidos de la lista y la ordenamos
                            List<int> L_buscada = ((Lista_Cerradura)L_Cerradura[posicion_L]).Estados_Epsilon.Distinct().ToList();
                            ((Lista_Cerradura)L_Cerradura[posicion_L]).Estados_Epsilon= ((Lista_Cerradura)L_Cerradura[posicion_L]).Estados_Epsilon.Distinct().ToList();
                            L_buscada.Sort();

                            List<int> L_Nueva = nuevo_C_ciclo.Estados_Epsilon.Distinct().ToList();
                            nuevo_C_ciclo.Estados_Epsilon = nuevo_C_ciclo.Estados_Epsilon.Distinct().ToList();
                            L_Nueva.Sort();
                            if (L_buscada.SequenceEqual(L_Nueva))
                            {
                                //ya se encuentra insertada
                                Nodo_Transicion Nodo_Nuevo = new Nodo_Transicion(hijos, ((Lista_Cerradura)L_Cerradura[posicion_L]).Get_Nombre_Estado());
                                Ultima_Faltante.Transicion_Final.Add(Nodo_Nuevo);
                                bandera = true;
                                break;
                            }
                        }

                        //Insertamos
                        if (!bandera)
                        {
                            if (nuevo_C_ciclo.Estados_Epsilon.Count == 0)
                            {
                                //no insertar
                            }
                            else
                            {
                                Nodo_Transicion Nodo_Nuevo = new Nodo_Transicion(hijos,NumeroEstadoAFD);
                                Ultima_Faltante.Transicion_Final.Add(Nodo_Nuevo);
                                L_Cerradura.Add(nuevo_C_ciclo);
                                NumeroEstadoAFD++;
                                Ciclo_Nuevos_Estados++;
                            }
                        }

                        
                    }
                    Ultima_Faltante.Estado = true;
                }
                

                //fin ciclio
                Ciclo_Nuevos_Estados--;
            }

        }

        public void Creacion_EstadoAFD(int Estado, Lista_Cerradura nuevo) {
            //primer analisis encontramos las transiciones a epsilon desde el estado inicial
            for (int posicion = 0; posicion < L_Transiciones.Count; posicion++)
            {
                //comproamos si tiene una transicion a epsion en caso de que lo tengo llamamos al metodo pero con la nueva pos
                if (((Lista_Transiciones)L_Transiciones[posicion]).Get_Primero() == Estado && ((Lista_Transiciones)L_Transiciones[posicion]).Get_IdCambio().Equals("ε") && ((Lista_Transiciones)L_Transiciones[posicion]).Get_Direccion() == 0)
                {
                    //Creamos nuevo Estado
                    nuevo.Set_Contenido(((Lista_Transiciones)L_Transiciones[posicion]).Get_Siguiente());
                    Creacion_EstadoAFD(((Lista_Transiciones)L_Transiciones[posicion]).Get_Siguiente(), nuevo);
                }
                else if (!((Lista_Transiciones)L_Transiciones[posicion]).Get_Siguiente().Equals(null))
                {
                    if (((Lista_Transiciones)L_Transiciones[posicion]).Get_Siguiente() == Estado && ((Lista_Transiciones)L_Transiciones[posicion]).Get_IdCambio().Equals("ε") && ((Lista_Transiciones)L_Transiciones[posicion]).Get_Direccion() == 1)
                    {
                        //lo mismo que el de arria pero con direccion contraria
                        nuevo.Set_Contenido(((Lista_Transiciones)L_Transiciones[posicion]).Get_Primero());
                        Creacion_EstadoAFD(((Lista_Transiciones)L_Transiciones[posicion]).Get_Primero(), nuevo);
                    }
                    if (((Lista_Transiciones)L_Transiciones[posicion]).Get_Primero() == Estado && !((Lista_Transiciones)L_Transiciones[posicion]).Get_IdCambio().Equals("ε"))
                    {
                        //llenamos hacia donde va 
                        nuevo.Set_Transicion(((Lista_Transiciones)L_Transiciones[posicion]).Get_IdCambio(), ((Lista_Transiciones)L_Transiciones[posicion]).Get_Siguiente());
                    }

                }

            }
        }

        public void Graficar_AFD() {
            String CadenaImprimir = "digraph AFD { " + '\n';
            CadenaImprimir += "graph [label=\"AFD: " + Nombre_ER + "\", labelloc=t, fontsize=20];\n";
            CadenaImprimir += "rankdir=LR;\n";
            CadenaImprimir += "edge [color=blue];\n";
            CadenaImprimir += "node [color = mediumseagreen];\n";
            //creacion de nodos
            for (int i = 0; i < L_Cerradura.Count; i++)
            {
                CadenaImprimir += "\"S" + ((Lista_Cerradura)L_Cerradura[i]).Get_Nombre_Estado() + "\"" + "[ label=S" + ((Lista_Cerradura)L_Cerradura[i]).Get_Nombre_Estado() + " ]" + '\n';
                foreach (int s in ((Lista_Cerradura)L_Cerradura[i]).Estados_Epsilon)
                {
                    if (s==Raiz.Ultimo) {
                        //es estado de aceptacion
                        CadenaImprimir += "\"S" + ((Lista_Cerradura)L_Cerradura[i]).Get_Nombre_Estado() + "\"" + "[peripheries=2]";
                        break;
                    }
                }
            }
            //estados de aceptacion
            CadenaImprimir += "secret_node [style=invis]; \n secret_node->\"S0\"[label = \"inicio\"]; \n";
            //creacion de transiciones
            for (int i = 0; i < L_Cerradura.Count; i++)
            {
                
                for (int x=0;x<((Lista_Cerradura)L_Cerradura[i]).Transicion_Final.Count;x++ ) {
                    //los separo por identificador comparo luego verifico hacia donde va
                    CadenaImprimir += "\"S" + ((Lista_Cerradura)L_Cerradura[i]).Get_Nombre_Estado() + "\"" + "->\"S";
                    Nodo_Transicion Nodo_T = ((Lista_Cerradura)L_Cerradura[i]).Transicion_Final[x];
                    string tem = Nodo_T.Cont_Transicion;
                    tem = tem.Replace("\"", "\\\"");
                    CadenaImprimir += Nodo_T.Pos_Transicion + "\"" + "[label=\"" +tem + "\" ];" + '\n';
                }

            }

            CadenaImprimir += '\n' + "}";

            //creacion del .dot
            string path = @"AFD" + Nombre_ER + ".dot";
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
            String comando = "dot -Tpng AFD" + Nombre_ER + ".dot -o AFD" + Nombre_ER + ".png";
            EjecutarComandoCMD(comando);
        }

        public void EjecutarComandoCMD(String comando) {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);

            ////No Funciona(La ventana sigue apareciendo)
            procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra
            procStartInfo.CreateNoWindow = true;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
    }
}
