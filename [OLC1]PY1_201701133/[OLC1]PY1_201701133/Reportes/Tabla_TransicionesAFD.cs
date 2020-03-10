using _OLC1_PY1_201701133.Estructuras;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_PY1_201701133.Reportes
{
    public partial class Tabla_TransicionesAFD : Form
    {
        int tamañomaximo = 0;
        int pos = 0;
        ArrayList EXP_R;
        public Tabla_TransicionesAFD()
        {
            InitializeComponent();
            EXP_R = new ArrayList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //siguiente
            pos++;
            if (pos < tamañomaximo)
            {
                String path= "Reporte_Transicion_" + ((Lista_ER)EXP_R[pos]).getNombre() + ".html";
                this.webBrowser1.DocumentText = File.ReadAllText(path);
            }
            else
            {
                pos--;
            }
        }
        public void RecibirTamañoyLista(int a, ArrayList tem)
        {
            EXP_R = tem;
            tamañomaximo = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //anterior
            pos--;
            if (pos >=0)
            {
                String path = "Reporte_Transicion_" + ((Lista_ER)EXP_R[pos]).getNombre() + ".html";
                this.webBrowser1.DocumentText = File.ReadAllText(path);
            }
            else
            {
                pos++;
            }
        }
    }
}
