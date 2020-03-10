using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using _OLC1_PY1_201701133.Estructuras;
using _OLC1_PY1_201701133.Reportes;

namespace _OLC1_PY1_201701133
{
    public partial class Form1 : Form
    {
        //creacion de lista tokens
        ArrayList Lista_Expresiones_R;
        ArrayList Lista_Conjuntos;
        //Analizador
        Analizador Analizadores;
        //controlador de Imagenes AFND
        int Posicion_AFND;
        public Form1()
        {
            InitializeComponent();

            Lista_Expresiones_R = new ArrayList();
            Lista_Conjuntos = new ArrayList();
            Lista_Expresiones_R = new ArrayList();
            Posicion_AFND = 0;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ABRIR ARCHIVO
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Dektop";
                openFileDialog.Filter = "re files (*.er)|*.er|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Dandole nombre a la pestaña
                    filePath = openFileDialog.FileName;
                    FileInfo info = new FileInfo(filePath);
                    

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    //Agregar a las pestañas
                    TabControl controlpestañas = this.tabControl1;
                    TabPage nuevapagina = new TabPage();
                    //modificar pesataña
                    nuevapagina.Text = info.Name;
                    controlpestañas.TabPages.Add(nuevapagina);
                    controlpestañas.Location = new Point(8, 27);
                    controlpestañas.Size = new Size(500, 400);

                    //agregamos canpo de texto
                    RichTextBox campo = new RichTextBox();
                    campo.Name = "rtb";
                    campo.WordWrap = false; campo.Multiline = true;
                    campo.Font = new Font("Arial", 10);
                    campo.Width = 495; campo.Height = 375;
                    nuevapagina.Controls.Add(campo);
                    campo.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
                    using (StreamReader reader = new StreamReader(fileStream))
                    {

                        fileContent = reader.ReadToEnd();
                        campo.Text += fileContent;
                    }
                }
            }

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void guardarcomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public void Guardar()
        {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Seleccione donde quiere guardar el Documento nuevo...";
            Guardar.Filter = "Archivo extencion er|*.er";
            Guardar.AddExtension = true;

            if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                StreamWriter escribir = new StreamWriter(Guardar.FileName);
                TabPage selectedTab = this.tabControl1.SelectedTab;
                RichTextBox selectedRtb = selectedTab.Controls.Find("rtb", true).First() as RichTextBox;
                escribir.Write(selectedRtb.Text);
                escribir.Close();
                MessageBox.Show("Guardado Correctamente");
            }
        }//fin guardar

        private void analisisLeicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Jtree
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("AFND");
            treeView1.Nodes.Add("AFD");
            //Seleccion de contenido del ritch actual
            TabPage selectedTab = this.tabControl1.SelectedTab;
            RichTextBox selectedRtb = selectedTab.Controls.Find("rtb", true).First() as RichTextBox;


            Analizadores = new Analizador();

            Analizadores.Scanner(selectedRtb.Text);
            //Analisar
            Analizadores.GetArrayLista_ER(Lista_Expresiones_R);
            Analizadores.GetArrayLista_CJ(Lista_Conjuntos);
            //Generadores de Thompson
            for (int no=0;no<Lista_Expresiones_R.Count;no++) {
                Metodo_Thompson Analizador_Thompson = new Metodo_Thompson();
                Analizador_Thompson.Analizar_Metodo(((Lista_ER)Lista_Expresiones_R[no]).getNombre(), ((Lista_ER)Lista_Expresiones_R[no]).getER());
                //agregar al Tree
                treeView1.Nodes[0].Nodes.Add("AFND"+((Lista_ER)Lista_Expresiones_R[no]).getNombre());
                treeView1.Nodes[1].Nodes.Add("AFD" + ((Lista_ER)Lista_Expresiones_R[no]).getNombre());
            }           

            //for (int i = 0; i < Lista_Conjuntos.Count; i++)
            //{
            //    Console.WriteLine("NOMBRE DEL CONJUNTO: " + ((Lista_Conjuntos)Lista_Conjuntos[i]).getNombre() + "\t CONTENIDO: " + ((Lista_Conjuntos)Lista_Conjuntos[i]).getContenido());
            //}
            //MessageBox.Show("Analisis Completado");

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Agregar a las pestañas
            TabControl controlpestañas = this.tabControl1;
            TabPage nuevapagina = new TabPage();
            //modificar pesataña
            nuevapagina.Text = "Nueva Pestaña";
            controlpestañas.TabPages.Add(nuevapagina);
            controlpestañas.Location = new Point(8, 27);
            controlpestañas.Size = new Size(500, 400);

            //agregamos canpo de texto
            RichTextBox campo = new RichTextBox();
            campo.Name = "rtb";
            campo.WordWrap = false; campo.Multiline = true;
            campo .Font = new Font("Arial", 10);
            campo.Width = 495; campo.Height = 375;
            nuevapagina.Controls.Add(campo);
            campo.ScrollBars = RichTextBoxScrollBars.ForcedBoth;

        }

        private void lexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boolean true significa reporte de tabla de tokens
            Analizadores.Graficar_Tabla_Tokens(true);
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boolean false significa reporte de tabla de errores en los tokens
            Analizadores.Graficar_Tabla_Tokens(false);
        }

        private void mostrarAFNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_Imagenes R_I = new Reporte_Imagenes();
            Posicion_AFND = 0;
            if (Lista_Expresiones_R.Count != 0)
            {
                Bitmap MyImage;
                MyImage = new Bitmap("AFND" + ((Lista_ER)Lista_Expresiones_R[Posicion_AFND]).getNombre() + ".png");
                R_I.pictureBox1.Image = (Image)MyImage;
                R_I.RecibirTamañoyLista(Lista_Expresiones_R.Count,Lista_Expresiones_R);
                R_I.AFND_AFD = 0;
                R_I.Show();
            }
            else
            {
                MessageBox.Show("No Hay Imagenes Cargadas");
            }
            
        }

        private void mostrarAFDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_Imagenes R_I = new Reporte_Imagenes();
            Posicion_AFND = 0;
            
            if (Lista_Expresiones_R.Count != 0)
            {
                Bitmap MyImage;
                MyImage = new Bitmap("AFD" + ((Lista_ER)Lista_Expresiones_R[Posicion_AFND]).getNombre() + ".png");
                R_I.pictureBox1.Image = (Image)MyImage;
                R_I.RecibirTamañoyLista(Lista_Expresiones_R.Count, Lista_Expresiones_R);
                R_I.AFND_AFD = 1;
                R_I.Show();
            }
            else
            {
                MessageBox.Show("No Hay Imagenes Cargadas");
            }

        }

        private void tablaTransicionesAFDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Lista_Expresiones_R.Count != 0)
            {
                Tabla_TransicionesAFD Tab_Tras = new Tabla_TransicionesAFD();
                Posicion_AFND = 0;
                Tab_Tras.webBrowser1.AllowWebBrowserDrop = false;
                String path = "Reporte_Transicion_"+ ((Lista_ER)Lista_Expresiones_R[0]).getNombre()+".html";
                Tab_Tras.webBrowser1.DocumentText = File.ReadAllText(path);
                Tab_Tras.RecibirTamañoyLista(Lista_Expresiones_R.Count, Lista_Expresiones_R);
                Tab_Tras.Show();
            }
            else
            {
                MessageBox.Show("No Hay Tablas Cargados");
            }
        }
    }
}

