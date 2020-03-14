using _OLC1_PY1_201701133.Analizador_Lexema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_PY1_201701133.Reportes
{
    public partial class Reporte_XML : Form
    {
        List<Lista_XML> Lista_Dato_XML;
        public int posicion = 0;
        public bool Tipo;
        public Reporte_XML()
        {
            InitializeComponent();
            Lista_Dato_XML = new List<Lista_XML>();
            
        }
        public void Set_Lista(String nm,String cont,String cont_XML, Boolean tp) {
            if (tp == Tipo) {
                Lista_XML nuevo = new Lista_XML(nm, cont, cont_XML, tp);
                Lista_Dato_XML.Add(nuevo);
            }
            
        }
        public void PrimerDato() {
            
            String Contenido = "\n\n";
            Contenido += "\t EXPRESION REGULAR:  "+Lista_Dato_XML[0].Nombre+"\n";
            Contenido += "\t LEXEMA DE ENTRADA:  " + Lista_Dato_XML[0].Contenido+"\n";
            Contenido += "\t CONTENIDO XML \n\n";
            Contenido += Lista_Dato_XML[0].ContenidoXML;
            this.richTextBox1.Text = Contenido;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Anterior
            posicion--;
            if (posicion >=0)
            {
                this.richTextBox1.Clear();
                String Contenido = "\n\n";
                Contenido += "\t EXPRESION REGULAR:  " + Lista_Dato_XML[posicion].Nombre + "\n";
                Contenido += "\t LEXEMA DE ENTRADA:  " + Lista_Dato_XML[posicion].Contenido + "\n";
                Contenido += "\t CONTENIDO XML \n\n";
                Contenido += Lista_Dato_XML[posicion].ContenidoXML;
                this.richTextBox1.Text = Contenido;
            }
            else
            {
                posicion++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //siguiente
            posicion++;
            if (posicion < Lista_Dato_XML.Count)
            {
                this.richTextBox1.Clear();
                String Contenido = "\n\n";
                Contenido += "\t EXPRESION REGULAR:  " + Lista_Dato_XML[posicion].Nombre + "\n";
                Contenido += "\t LEXEMA DE ENTRADA:  " + Lista_Dato_XML[posicion].Contenido + "\n";
                Contenido += "\t CONTENIDO XML \n\n";
                Contenido += Lista_Dato_XML[posicion].ContenidoXML;
                this.richTextBox1.Text = Contenido;
            }
            else {
                posicion--;
            }
        }
    }
}
