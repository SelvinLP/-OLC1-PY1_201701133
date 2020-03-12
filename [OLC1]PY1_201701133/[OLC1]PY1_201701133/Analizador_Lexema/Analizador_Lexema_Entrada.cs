using _OLC1_PY1_201701133.Estructuras;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _OLC1_PY1_201701133.Analizador_Lexema
{
    class Analizador_Lexema_Entrada
    {
        public String Cadena_Lexema;
        String[,] Tabla_Transiciones;
        int NumerodeEncabezados;
        ArrayList Conjuntos;
        //Nombre del Documento
        public String NombreXML;
        //Lista de tokens reconocidos
        List<Tokens_Reconocidos> Lista_Tokens_Rec;
        public Analizador_Lexema_Entrada(String Cadena, String[,] Tabla_Trans,ArrayList Conj)
        {
            this.Cadena_Lexema = Cadena;
            this.Tabla_Transiciones = Tabla_Trans;
            this.NumerodeEncabezados = 0;
            this.Conjuntos = Conj;
            this.Lista_Tokens_Rec = new List<Tokens_Reconocidos>();
        }

        public void Calculo_Numero_Hijos() {
            for (int i = 0; i < 49; i++)
            {
                if (Tabla_Transiciones[0, i + 1] == null)
                {
                    // No comparamos estados 
                    this.NumerodeEncabezados = i + 1;
                }
            }
        }

        public Boolean Analizar_Lexema_Entrada()
        {
            Calculo_Numero_Hijos();
            Boolean bandera = true;
            int Estado = 1;
            for (int pos = 0; pos < Cadena_Lexema.Length; pos++)
            {
                //variable para ver si inserto en cualquiera de los casos
                int Insertado = 0;
                //1 si
                //0 no

                //validaciones
                Console.WriteLine("Nuevo");
                for (int x = 0; x < NumerodeEncabezados; x++)
                {

                    if (Tabla_Transiciones[Estado,x+1] == null)
                    {
                        // No comparamos estados 
                    }
                    else
                    {
                        //comparamos si pertenece o tiene una transicion a alguno de estos casos
                        char var = Tabla_Transiciones[0,x+1][0];
                        String tem = Tabla_Transiciones[0, x + 1];
                        String Nombre = "";
                        //arreglamos la cadena quitando {} y ""
                        for (int i = 0; i < tem.Length; i++)
                        {
                            if ((i == 0 && tem[i] == (char)34) || (i == (tem.Length - 1) && tem[i] == (char)34))
                            {
                                //quita comillas
                            }
                            else {
                                if ((i == 0 && tem[i] == (char)123) || (i == (tem.Length - 1) && tem[i] == (char)125))
                                {
                                    //quitamos llaves de conjuntos {}
                                }
                                else { Nombre += tem[i]; }
                            }
                            
                        }
                        #region Cadena
                        //Cadena
                        if (var == (char)34)
                        {
                            String cad = Cadena_Lexema[pos].ToString();
                            for (int con = 1; con < Nombre.Length; con++)
                            {
                                pos++;
                                try
                                {
                                    cad += Cadena_Lexema[con].ToString();
                                }
                                catch {
                                }
                                
                            }
                            Console.WriteLine("---" + cad + "---");
                            if (cad.Equals(Nombre))
                            {
                                Console.WriteLine("--ESTADO_CADENA_CORRECTA ");
                                Estado = int.Parse(Tabla_Transiciones[Estado, x + 1])+1;
                                Console.WriteLine("PASO AL ESTADO ->"+Estado);
                                //SE INSERTA
                                Insertado = 1;
                                break;

                            }
                            else
                            {
                                Console.WriteLine("--ESTADO_CADENA_INCORRECTA POR: " + Nombre + "--");
                                pos = pos - (Nombre.Length - 1);
                                //NO INSERTA
                                Insertado = 0;
                            }
                        }
                        #endregion


                        //Conjunto
                        int tipo_Conjunto = 0;
                        if (var == (char)123)
                        {
                            #region busqueda conjunto
                            //identificamos y obtenemos el nodo de la lista de conjuntos
                            String Encontrado = "";
                            for (int ListC = 0; ListC < Conjuntos.Count; ListC++)
                            {
                                if (((Lista_Conjuntos)Conjuntos[ListC]).getNombre().Equals(Nombre))
                                {
                                    Console.WriteLine("VALIDANDO CON CONJUNTO: " + Nombre);
                                    Encontrado = ((Lista_Conjuntos)Conjuntos[ListC]).getContenido();
                                    if (((Lista_Conjuntos)Conjuntos[ListC]).getTipo_Conjunto().Equals("Rango")) {
                                        tipo_Conjunto = 1;
                                    }
                                    Console.WriteLine("CONTENIDO DEL CONJNTO: " + Encontrado);
                                }
                            }
                            #endregion

                            #region ConjuntoRango
                            //L~D
                            if (tipo_Conjunto == 1)
                            {
                                Console.WriteLine("Entro a tipo rango");
                                int a = 0;
                                int b = 0;
                                int valor = 0;
                                int regreso_sencillo = 0;
                                if (Encontrado.Length > 3)
                                {
                                    Console.WriteLine("mayor a 3");
                                    //rango de numeros
                                    String a1 = "";
                                    String b1 = "";
                                    String v1 = "";
                                    int camb = 0;
                                    for (int t = 0; t < Encontrado.Length; t++)
                                    {
                                        //asignaos valores a los rangos
                                        if (Encontrado[t] == (char)126)
                                        {
                                            camb = 1;
                                            t++;
                                        }
                                        if (camb == 0)
                                        {
                                            a1 += Encontrado[t];
                                        }
                                        else { b1 += Encontrado[t]; }
                                    }
                                    
                                    //encontrar valor
                                    while (true)
                                    {
                                        if (Cadena_Lexema.Length>(pos + 1) )
                                        {
                                            if (Char.IsDigit(Cadena_Lexema[pos + 1]))
                                            {
                                                pos++;
                                                regreso_sencillo++;
                                                v1 += Cadena_Lexema[pos];
                                            }
                                            else { break;}
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                    //dando valores
                                    try
                                    {
                                        a = int.Parse(a1);
                                        Console.WriteLine("Primero: " + a);
                                        b = int.Parse(b1);
                                        Console.WriteLine("Segundo: " + b);
                                        valor = int.Parse(v1);
                                        Console.WriteLine("Valor: " + valor);
                                    }
                                    catch (Exception e) { }
                                    
                                }
                                else
                                {
                                    a = (int)Encontrado[0];
                                    b = (int)Encontrado[2];
                                    valor = (int)Cadena_Lexema[pos];
                                }
                                Console.WriteLine(Cadena_Lexema[pos] + "----Rango");
                                if (valor >= a && valor <= b)
                                {
                                    //cumple
                                    Console.WriteLine("--ESTADO_CADENA_CORRECTA ");
                                    Estado = int.Parse(Tabla_Transiciones[Estado, x + 1])+1;
                                    Console.WriteLine("PASO AL ESTADO ->" + Estado);
                                    Insertado = 1;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("-No valido Conjunto Rango");
                                    pos -= regreso_sencillo;
                                    regreso_sencillo = 0;
                                    Insertado = 0;
                                }
                            }
                            #endregion
                            else
                            {
                                //conjunto por comas {,,,}
                                Console.WriteLine("Validacion con conjunto de Comas");
                                Console.WriteLine(Cadena_Lexema[pos]);
                                String v = Cadena_Lexema[pos].ToString();
                                String[] valores = Encontrado.Split(',');
                                int enc = 0;
                                //comproacion de espacio en el conjunto
                                int espacio = 0;
                                for (int esp = 1; esp < Encontrado.Length; esp++)
                                {
                                    //comprobamos si hay espacio
                                    if ((Encontrado[esp - 1] == (char)44) && (Encontrado[esp] == (char)32))
                                    {
                                        espacio = 1;
                                    }
                                }
                                if (espacio == 1)
                                {
                                    //agrego espacio
                                    if (Cadena_Lexema[pos] == (char)32)
                                    {
                                        enc = 1;
                                    }
                                }
                                foreach(String it in valores)
                                {
                                    Console.WriteLine("---------------" + it);
                                    if (it.Equals(v))
                                    {
                                        enc = 1;
                                    }
                                }

                                Console.WriteLine(Cadena_Lexema[pos] + "----CONJUNTO CONMA");
                                if (enc == 1)
                                {
                                    Console.WriteLine("-valido Conjunto-");
                                    //cumple
                                    Console.WriteLine("--ESTADO_CADENA_CORRECTA ");
                                    Estado = int.Parse(Tabla_Transiciones[Estado, x + 1]) + 1;
                                    Console.WriteLine("PASO AL ESTADO ->" + Estado);
                                    Insertado = 1;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("-No valido Conjunto-");
                                    Insertado = 0;
                                }
                            }





                        }//fin conjuntos




                    }
                }
                //Console.WriteLine(pos+"--"+token);
                //validamos si se inserto de lo contrario
                if (Insertado == 0)
                {
                    bandera = false;
                }






            }

            return bandera;
        }

        public void EscribirXML(String Nombre,String Valor, int Fila, int Columna) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration Declaracionxml = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement raiz = doc.DocumentElement;
            doc.InsertBefore(Declaracionxml, raiz);

            //elementos
            XmlElement elemento1 = doc.CreateElement(string.Empty, "Lista_Tokens", string.Empty);
            doc.AppendChild(elemento1);

            XmlElement element2 = doc.CreateElement(string.Empty, "Token", string.Empty);
            elemento1.AppendChild(element2);

            doc.Save("Tokens_"+NombreXML+".xml");
        }
    }
}

