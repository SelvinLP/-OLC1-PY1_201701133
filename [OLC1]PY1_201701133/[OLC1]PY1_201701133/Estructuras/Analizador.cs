using _OLC1_PY1_201701133.Reportes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201701133.Estructuras
{
    class Analizador
    {
        ArrayList Lista_T;
        ArrayList Lista_T_Error;
        public Analizador() {
            Lista_T = new ArrayList();
            Lista_T_Error = new ArrayList();
        }
        public void Scanner(String Contenido) {
            Lista_T.Clear();
            Lista_T_Error.Clear();
            char Caracter = ' ';
            int Estado = 0;
            int Fila = 0;
            int Columna = 1;
            String Lexema = "";
            String Cadena_Archivo = Contenido;
            for (int i = 0; i < Cadena_Archivo.Length; i++)
            {
                Caracter = Cadena_Archivo[i];
                switch (Estado)
                {
                    case 0:

                        if (Caracter == (char)33)
                        {
                            Lista_T.Add(new Lista_Tokens(6, Caracter.ToString(), "Signo de Admiracion", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)34)
                        {
                            Lista_T.Add(new Lista_Tokens(7, Caracter.ToString(), "Comillas Dobles", Fila, Columna));
                            Estado = 7;
                            Columna++;
                        }
                        else if (Caracter == (char)35)
                        {
                            Lista_T.Add(new Lista_Tokens(8, Caracter.ToString(), "Numeral", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)36)
                        {
                            Lista_T.Add(new Lista_Tokens(9, Caracter.ToString(), "Simbolo Peso", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)37)
                        {
                            Lista_T.Add(new Lista_Tokens(10, Caracter.ToString(), "Porcentaje", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)38)
                        {
                            Lista_T.Add(new Lista_Tokens(11, Caracter.ToString(), "Ampersand", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)39)
                        {
                            Lista_T.Add(new Lista_Tokens(12, Caracter.ToString(), "Comilla Simple", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)40)
                        {
                            Lista_T.Add(new Lista_Tokens(13, Caracter.ToString(), "Parentesis Izquierdo", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)41)
                        {
                            Lista_T.Add(new Lista_Tokens(14, Caracter.ToString(), "Parentesis Derecho", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)42)
                        {
                            Lista_T.Add(new Lista_Tokens(15, Caracter.ToString(), "Asterisco", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)43)
                        {
                            Lista_T.Add(new Lista_Tokens(16, Caracter.ToString(), "Signo Mas", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)44)
                        {
                            Lista_T.Add(new Lista_Tokens(17, Caracter.ToString(), "Coma", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)45)
                        {
                            Lista_T.Add(new Lista_Tokens(18, Caracter.ToString(), "Signo Menos", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)46)
                        {
                            Lista_T.Add(new Lista_Tokens(19, Caracter.ToString(), "Punto", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)47)
                        {
                            Lista_T.Add(new Lista_Tokens(20, Caracter.ToString(), "Barra Inclinada", Fila, Columna));
                            Estado = 3;
                            Columna++;
                        }
                        else if (Caracter == (char)58)
                        {
                            Lista_T.Add(new Lista_Tokens(21, Caracter.ToString(), "Dos Puntos", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)59)
                        {
                            Lista_T.Add(new Lista_Tokens(22, Caracter.ToString(), "Punto y Coma", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)60)
                        {
                            Lista_T.Add(new Lista_Tokens(23, Caracter.ToString(), "Menor Que", Fila, Columna));
                            Estado = 5;
                            Columna++;
                        }
                        else if (Caracter == (char)61)
                        {
                            Lista_T.Add(new Lista_Tokens(24, Caracter.ToString(), "Igual Que", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)62)
                        {
                            Lista_T.Add(new Lista_Tokens(25, Caracter.ToString(), "Mayor Que", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)63)
                        {
                            Lista_T.Add(new Lista_Tokens(26, Caracter.ToString(), "Interrogacion", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)64)
                        {
                            Lista_T.Add(new Lista_Tokens(27, Caracter.ToString(), "Arroba", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)91)
                        {
                            Lista_T.Add(new Lista_Tokens(28, Caracter.ToString(), "Corchete Izquierdo", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)92)
                        {
                            Lista_T.Add(new Lista_Tokens(29, Caracter.ToString(), "Barra Invertida", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)93)
                        {
                            Lista_T.Add(new Lista_Tokens(30, Caracter.ToString(), "Corchete Derecho", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)94)
                        {
                            Lista_T.Add(new Lista_Tokens(31, Caracter.ToString(), "Acento Circunflejo", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)95)
                        {
                            Lista_T.Add(new Lista_Tokens(32, Caracter.ToString(), "Barra Baja", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)96)
                        {
                            Lista_T.Add(new Lista_Tokens(33, Caracter.ToString(), "Acento Grave", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)123)
                        {
                            Lista_T.Add(new Lista_Tokens(34, Caracter.ToString(), "Llave Izquierda", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)124)
                        {
                            Lista_T.Add(new Lista_Tokens(35, Caracter.ToString(), "Barra Vetical", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)125)
                        {
                            Lista_T.Add(new Lista_Tokens(36, Caracter.ToString(), "Corchete Derecho", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Caracter == (char)126)
                        {
                            Lista_T.Add(new Lista_Tokens(37, Caracter.ToString(), "Tilde", Fila, Columna));
                            Estado = 0;
                            Columna++;
                        }
                        else if (Char.IsLetter(Caracter))
                        {
                            //Verifica si es Letra
                            Lexema += Caracter;
                            Estado = 1;
                        }
                        else if (Char.IsDigit(Caracter))
                        {
                            //Verifica si es Digito
                            Lexema += Caracter;
                            Estado = 2;
                        }
                        else if (Caracter == '\n')
                        {
                            //salto de linea
                            Columna = 1;
                            Fila++;
                            Estado = 0;
                        }
                        else if (Caracter == ' ' | Caracter == '\t' | Caracter == '\b' | Caracter == '\r' | Caracter == '\f')
                        {
                            //Espacios en blanco
                        }
                        else
                        {
                            //Errores Lexicos
                            Lista_T_Error.Add(new Lista_Tokens(0, Caracter.ToString(), "Error Lexico", Fila, Columna));
                            Lexema = "";
                            Estado = 0;
                        }


                        break;
                    case 1:
                        //Verificar si es Letra
                        if (Char.IsLetter(Caracter))
                        {
                            Lexema += Caracter;
                            Estado = 1;
                        }
                        else if (Char.IsDigit(Caracter))
                        {
                            //Verifica si es Digito
                            Lexema += Caracter;
                            Estado = 1;
                        }
                        else if (Caracter == (char)95)
                        {
                            Lexema += Caracter;
                            Estado = 1;
                        }
                        else
                        {

                            if (Lexema.Equals("CONJ"))
                            {
                                Lista_T.Add(new Lista_Tokens(3, Lexema, "Palabra Reservada", Fila, Columna));
                            }
                            else
                            {
                                Lista_T.Add(new Lista_Tokens(5, Lexema, "Identificador", Fila, Columna));
                            }
                            Columna++;
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }

                        break;
                    case 2:
                        //Verifica si es Digito
                        if (Char.IsDigit(Caracter))
                        {
                            Lexema += Caracter;
                            Estado = 2;
                        }
                        else
                        {
                            Lista_T.Add(new Lista_Tokens(38, Lexema, "Digito", Fila, Columna));
                            Columna++;
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        break;
                    case 3:
                        //Verifica si es Comentario de una linea
                        if (Caracter == (char)47)
                        {
                            Lista_T.Add(new Lista_Tokens(20, Caracter.ToString(), "Barra Inclinada", Fila, Columna));
                            Estado = 4;
                            Columna++;
                        }
                        else
                        {
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        break;
                    case 4:
                        //Verifica si es Comentario de una linea acepta lo que sea hasta salto de linea
                        if (Caracter != '\n')
                        {
                            Lexema += Caracter;
                            Estado = 4;
                        }
                        else
                        {
                            Lista_T.Add(new Lista_Tokens(1, Lexema, "Comentario de Linea", Fila, Columna));
                            Columna++;
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        break;
                    case 5:
                        //Comentario Multilinea
                        if (Caracter == (char)33)
                        {
                            Lista_T.Add(new Lista_Tokens(6, Caracter.ToString(), "Signo de Admiracion", Fila, Columna));
                            Estado = 6;
                            Columna++;
                        }
                        else
                        {
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        break;
                    case 6:
                        //Comentario Multilinea acepta hasta el signo de admiracion
                        if (Caracter != (char)33)
                        {
                            Lexema += Caracter;
                            Estado = 6;
                        }
                        else
                        {
                            Lista_T.Add(new Lista_Tokens(2, Lexema, "Comentario Multilinea", Fila, Columna));
                            Columna++;
                            Lexema = "";
                            Estado = 0;
                            i--;
                        }
                        break;
                    case 7:
                        //Comentario Multilinea acepta hasta comilla dobles
                        if (Caracter != (char)34)
                        {
                            Lexema += Caracter;
                            Estado = 7;
                        }
                        else
                        {
                            Lista_T.Add(new Lista_Tokens(4, Lexema, "Lexema de Entrada", Fila, Columna));
                            Columna++;
                            Lexema = "";
                            Estado = 0;
                            //aceptamos las comillas
                            Lista_T.Add(new Lista_Tokens(7, Caracter.ToString(), "Comillas Dobles", Fila, Columna));
                            Columna++;
                        }
                        break;

                }

                //Console.WriteLine(Caracter);
            }

                
        }

        public ArrayList Get_Lista_T() {
            return Lista_T;
        }

        public ArrayList Get_Lista_T_Error() {
            return Lista_T_Error;
        }

        public void Graficar_Tabla_Tokens(Boolean Tokens_o_Error) {

            String Nombre = "";
            String Nombre_Reporte = "";
            if (Tokens_o_Error)
            {
                //Son Tokens
                Nombre += "TABLA DE TOKENS";
            }
            else
            {
                //Errores
                Nombre += "TABLA DE ERRORES";
            }

            String CadenaImprimir = "<html>" + "<body>" + "<h1 align='center'>" + Nombre + "</h1></br>" + "<table cellpadding='10' border = '1' align='center'>" + '\n';

            CadenaImprimir += " <tr><td><b>No.</b></td><td><b>Id</b></td><td><b>Lexema</b></td><td><b>Descripcion</b></td><td><b>Fila</b></td><td><b>Columna</b></td></tr>" + '\n';
            if (Tokens_o_Error)
            {
                for (int i = 0; i < Lista_T.Count; i++)
                {
                    CadenaImprimir += "<tr><td>" + i + "</td>" + "<td>" + ((Lista_Tokens)Lista_T[i]).getID() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T[i]).getLexema() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T[i]).getDescripcion() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T[i]).getFila() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T[i]).getColumna() + "</td></tr>" + '\n';
                }
            }
            else
            {
                Nombre_Reporte = "Errores";
                for (int i = 0; i < Lista_T_Error.Count; i++)
                {
                    CadenaImprimir += "<tr><td>" + i + "</td>" + "<td>" + ((Lista_Tokens)Lista_T_Error[i]).getID() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T_Error[i]).getLexema() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T_Error[i]).getDescripcion() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T_Error[i]).getFila() + "</td>" + "<td>" + ((Lista_Tokens)Lista_T_Error[i]).getColumna() + "</td></tr>" + '\n';
                }
            }

            CadenaImprimir += "</table></body></html>";

            //Creacion del HTML
            string path = @"Reporte_Lexico"+Nombre_Reporte+".html";
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(CadenaImprimir);
                    fs.Write(info, 0, info.Length);
                }
                //Process.Start(path);
                Tabla_Tokens TR = new Tabla_Tokens();
                TR.webBrowser1.AllowWebBrowserDrop = false;
                TR.webBrowser1.DocumentText = File.ReadAllText(path);
                TR.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

    }
}
