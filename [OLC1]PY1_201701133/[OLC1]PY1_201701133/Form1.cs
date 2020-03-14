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
using _OLC1_PY1_201701133.Analizador_Lexema;

namespace _OLC1_PY1_201701133
{
    public partial class Form1 : Form
    {
        //creacion de lista tokens
        ArrayList Lista_Expresiones_R;
        ArrayList Lista_Conjuntos;
        List<String[,]> Lista_Tabla_Transiciones;
        List<Lista_XML> Lista_Datos_XML;
        //Analizador
        Analizador Analizadores;
        //controlador de Imagenes AFND
        int Posicion_AFND;
        public Form1()
        {
            InitializeComponent();

            Lista_Expresiones_R = new ArrayList();
            Lista_Conjuntos = new ArrayList();
            Lista_Tabla_Transiciones = new List<String[,]>();
            Lista_Datos_XML = new List<Lista_XML>();

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
                    controlpestañas.Size = new Size(550, 400);

                    //agregamos canpo de texto
                    RichTextBox campo = new RichTextBox();
                    campo.Name = "rtb";
                    campo.WordWrap = false; campo.Multiline = true;
                    campo.Font = new Font("Arial", 11);
                    campo.Width = 545; campo.Height = 375;
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
            treeView1.Nodes.Add("TABLA_TRANSICIONES");
            //Seleccion de contenido del ritch actual
            TabPage selectedTab = this.tabControl1.SelectedTab;
            RichTextBox selectedRtb = selectedTab.Controls.Find("rtb", true).First() as RichTextBox;


            Analizadores = new Analizador();

            Analizadores.Scanner(selectedRtb.Text);
            //Analisar
            Analizadores.GetArrayLista_ER(Lista_Expresiones_R);
            Analizadores.GetArrayLista_CJ(Lista_Conjuntos);
            //Generadores de Thompson
            #region thompson
            Lista_Tabla_Transiciones.Clear();
            for (int no = 0; no < Lista_Expresiones_R.Count; no++)
            {
                Metodo_Thompson Analizador_Thompson = new Metodo_Thompson();
                Analizador_Thompson.Analizar_Metodo(((Lista_ER)Lista_Expresiones_R[no]).getNombre(), ((Lista_ER)Lista_Expresiones_R[no]).getER());

                ((Lista_ER)Lista_Expresiones_R[no]).L_Estados_Aceptacion.Clear();
                ((Lista_ER)Lista_Expresiones_R[no]).L_Estados_Aceptacion = Analizador_Thompson.Estados_Aceptacion();
                Lista_Tabla_Transiciones.Add(Analizador_Thompson.Get_Tabla_Transiciones());
                //agregar al Tree
                treeView1.Nodes[0].Nodes.Add("AFND_" + ((Lista_ER)Lista_Expresiones_R[no]).getNombre());
                treeView1.Nodes[1].Nodes.Add("AFD_" + ((Lista_ER)Lista_Expresiones_R[no]).getNombre());
                treeView1.Nodes[2].Nodes.Add("TABLA_" + ((Lista_ER)Lista_Expresiones_R[no]).getNombre());
            }
            #endregion


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
            campo.Font = new Font("Arial", 11);
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
                R_I.RecibirTamañoyLista(Lista_Expresiones_R.Count, Lista_Expresiones_R);
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
                String path = "Reporte_Transicion_" + ((Lista_ER)Lista_Expresiones_R[0]).getNombre() + ".html";
                Tab_Tras.webBrowser1.DocumentText = File.ReadAllText(path);
                Tab_Tras.RecibirTamañoyLista(Lista_Expresiones_R.Count, Lista_Expresiones_R);
                Tab_Tras.Show();
            }
            else
            {
                MessageBox.Show("No Hay Tablas Cargados");
            }
        }

        private void analisisDeLexemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Analisar lexemas
            ArrayList Lexemas = Analizadores.GetArrayLista_ExpE();
            Lista_Datos_XML.Clear();
            richTextBox1.Clear();
            Lista_Datos_XML.Clear();
            //comprobamos con que expresion regular se debe analizar
            for (int pos_nombre = 0; pos_nombre < Lista_Expresiones_R.Count; pos_nombre++)
            {
                String Nombre_ER = ((Lista_ER)Lista_Expresiones_R[pos_nombre]).getNombre();
                for (int pos_nombre_lex = 0; pos_nombre_lex < Lexemas.Count; pos_nombre_lex++)
                {
                    String Nombre_Lex = ((Lista_LexemaE)Lexemas[pos_nombre_lex]).getNombre();
                    if (Nombre_Lex.Equals(Nombre_ER))
                    {
                        //se mandan a analizar
                        Analizador_Lexema_Entrada Metodo_Analizador_LexE = new Analizador_Lexema_Entrada(((Lista_LexemaE)Lexemas[pos_nombre_lex]).getContenido(), Lista_Tabla_Transiciones[pos_nombre], Lista_Conjuntos);
                        Metodo_Analizador_LexE.NombreXML = Nombre_ER;
                        Boolean bandera=Metodo_Analizador_LexE.Analizar_Lexema_Entrada();

                        //verificamos si se encuentra en estado de aceptacion
                        int Estado_F = Metodo_Analizador_LexE.Get_Estado_Final();
                        Boolean Es_Estado = false;
                        foreach (int Est_F in ((Lista_ER)Lista_Expresiones_R[pos_nombre]).L_Estados_Aceptacion)
                        {
                            if (Estado_F == Est_F) {
                                Es_Estado = true;
                            }
                        }
                        
                        //Agregar resultado a Richtextox
                        String Contenido = richTextBox1.Text;
                        Contenido += "--------------------------------------------------------------------------------------------------------------------------------------"+'\n';
                        Contenido += "Expresion Regular: " + Nombre_ER+'\n';
                        Contenido += "Lexema De Entrada: " + ((Lista_LexemaE)Lexemas[pos_nombre_lex]).getContenido() + '\n';
                        if (!Es_Estado)
                        {
                            Contenido += "Reconocio Tokens: " + bandera + "\nLlego A Estado De Aceptacion Con Estado "+Estado_F+": " + false+"\n";
                            bandera = false;

                        }
                        else { Contenido += "Reconocio Tokens: " + bandera + "\nLlego D Estado De Aceptacion Con Estado " + Estado_F + ": " + true +"\n"; }
                        Contenido += "CUMPLE EL LEXEMA  " + bandera+"\n";
                        richTextBox1.Text = Contenido;

                        //TOKENS XML
                        String contXML = Metodo_Analizador_LexE.EscribirXML();
                        Lista_XML nuevo = new Lista_XML(Nombre_ER, ((Lista_LexemaE)Lexemas[pos_nombre_lex]).getContenido(), contXML,false);
                        Lista_Datos_XML.Add(nuevo);
                        //ERRORES XML
                        String contXML_Error = Metodo_Analizador_LexE.EscribirXML_Errores();
                        Lista_XML nuevo2 = new Lista_XML(Nombre_ER, ((Lista_LexemaE)Lexemas[pos_nombre_lex]).getContenido(), contXML_Error, true);
                        Lista_Datos_XML.Add(nuevo2);
                    }
                }
            }
        }

        private void reporteXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_XML R_XML = new Reporte_XML();

            if (Lista_Datos_XML.Count != 0)
            {
                R_XML.Tipo = false;
                foreach (Lista_XML x in Lista_Datos_XML)
                {
                    R_XML.Set_Lista(x.Nombre, x.Contenido, x.ContenidoXML,x.Tipo);
                }
                
                R_XML.PrimerDato();
                R_XML.Show();
            }
            else
            {
                MessageBox.Show("No Hay Reportes XML");

            }
        }

        private void reporteErroresXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte_XML R_XML = new Reporte_XML();

            if (Lista_Datos_XML.Count != 0)
            {
                R_XML.Tipo = true;
                foreach (Lista_XML x in Lista_Datos_XML)
                {
                    R_XML.Set_Lista(x.Nombre, x.Contenido, x.ContenidoXML, x.Tipo);
                }

                R_XML.PrimerDato();
                R_XML.Show();
            }
            else
            {
                MessageBox.Show("No Hay Reportes XML");

            }
        }
    }
}

