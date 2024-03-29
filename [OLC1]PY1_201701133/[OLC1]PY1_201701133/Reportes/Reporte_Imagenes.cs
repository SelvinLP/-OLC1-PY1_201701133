﻿using _OLC1_PY1_201701133.Estructuras;
using System;
using System.Collections;
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
    public partial class Reporte_Imagenes : Form
    {
        public int AFND_AFD;//0 si es anfd y 1 si es afd
        int tamañomaximo = 0;
        int pos = 0;
        ArrayList EXP_R;
        public Reporte_Imagenes()
        {
            InitializeComponent();
            EXP_R = new ArrayList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //siguiente
            pos++;
            if (pos<tamañomaximo) {
                pictureBox1.Image = null;
                Bitmap MyImage;
                String AFD_O_AFND;
                if (AFND_AFD == 0)
                {
                    AFD_O_AFND = "AFND";
                }
                else {
                    AFD_O_AFND = "AFD";
                }
                MyImage = new Bitmap(AFD_O_AFND + ((Lista_ER)EXP_R[pos]).getNombre() + ".png");
                pictureBox1.Image = (Image)MyImage;
            }else
            {
                pos--;
            }
        }
        public void RecibirTamañoyLista(int a,ArrayList tem)
        {
            EXP_R = tem;
            tamañomaximo = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Anterior
            pos--;
            if (pos >= 0)
            {
                pictureBox1.Image = null;
                Bitmap MyImage;
                String AFD_O_AFND;
                if (AFND_AFD == 0)
                {
                    AFD_O_AFND = "AFND";
                }
                else
                {
                    AFD_O_AFND = "AFD";
                }
                MyImage = new Bitmap(AFD_O_AFND + ((Lista_ER)EXP_R[pos]).getNombre() + ".png");
                pictureBox1.Image = (Image)MyImage;
            }
            else {
                pos++;
            }
        }
    }
}
