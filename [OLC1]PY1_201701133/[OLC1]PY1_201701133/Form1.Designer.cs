﻿namespace _OLC1_PY1_201701133
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarcomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NuevaPestaña = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rehacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.seleccionartodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisLeicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisDeLexemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarAFNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarAFDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaTransicionesAFDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteErroresXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.reporteTotalLexemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.analisisToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.toolStripSeparator,
            this.guardarToolStripMenuItem,
            this.guardarcomoToolStripMenuItem,
            this.toolStripSeparator1,
            this.NuevaPestaña,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarcomoToolStripMenuItem
            // 
            this.guardarcomoToolStripMenuItem.Name = "guardarcomoToolStripMenuItem";
            this.guardarcomoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.guardarcomoToolStripMenuItem.Text = "G&uardar como";
            this.guardarcomoToolStripMenuItem.Click += new System.EventHandler(this.guardarcomoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // NuevaPestaña
            // 
            this.NuevaPestaña.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuevaPestaña.Name = "NuevaPestaña";
            this.NuevaPestaña.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.NuevaPestaña.ShowShortcutKeys = false;
            this.NuevaPestaña.Size = new System.Drawing.Size(156, 22);
            this.NuevaPestaña.Text = "&Nuevo";
            this.NuevaPestaña.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.rehacerToolStripMenuItem,
            this.toolStripSeparator3,
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.toolStripSeparator4,
            this.seleccionartodoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deshacerToolStripMenuItem.Text = "&Deshacer";
            // 
            // rehacerToolStripMenuItem
            // 
            this.rehacerToolStripMenuItem.Name = "rehacerToolStripMenuItem";
            this.rehacerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.rehacerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.rehacerToolStripMenuItem.Text = "&Rehacer";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cortarToolStripMenuItem.Image")));
            this.cortarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cortarToolStripMenuItem.Text = "Cor&tar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copiarToolStripMenuItem.Image")));
            this.copiarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.copiarToolStripMenuItem.Text = "&Copiar";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pegarToolStripMenuItem.Image")));
            this.pegarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pegarToolStripMenuItem.Text = "&Pegar";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // seleccionartodoToolStripMenuItem
            // 
            this.seleccionartodoToolStripMenuItem.Name = "seleccionartodoToolStripMenuItem";
            this.seleccionartodoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seleccionartodoToolStripMenuItem.Text = "&Seleccionar todo";
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analisisLeicoToolStripMenuItem,
            this.analisisDeLexemaToolStripMenuItem});
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.analisisToolStripMenuItem.Text = "&Analisis";
            // 
            // analisisLeicoToolStripMenuItem
            // 
            this.analisisLeicoToolStripMenuItem.Name = "analisisLeicoToolStripMenuItem";
            this.analisisLeicoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.analisisLeicoToolStripMenuItem.Text = "&Analisis Lexico";
            this.analisisLeicoToolStripMenuItem.Click += new System.EventHandler(this.analisisLeicoToolStripMenuItem_Click);
            // 
            // analisisDeLexemaToolStripMenuItem
            // 
            this.analisisDeLexemaToolStripMenuItem.Name = "analisisDeLexemaToolStripMenuItem";
            this.analisisDeLexemaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.analisisDeLexemaToolStripMenuItem.Text = "Analisis de &Lexema";
            this.analisisDeLexemaToolStripMenuItem.Click += new System.EventHandler(this.analisisDeLexemaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicoToolStripMenuItem,
            this.erroresToolStripMenuItem,
            this.mostrarAFNDToolStripMenuItem,
            this.mostrarAFDToolStripMenuItem,
            this.tablaTransicionesAFDToolStripMenuItem,
            this.reporteXMLToolStripMenuItem,
            this.reporteErroresXMLToolStripMenuItem,
            this.reporteTotalLexemasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "&Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // lexicoToolStripMenuItem
            // 
            this.lexicoToolStripMenuItem.Name = "lexicoToolStripMenuItem";
            this.lexicoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.lexicoToolStripMenuItem.Text = "&Reporte &Lexico";
            this.lexicoToolStripMenuItem.Click += new System.EventHandler(this.lexicoToolStripMenuItem_Click);
            // 
            // erroresToolStripMenuItem
            // 
            this.erroresToolStripMenuItem.Name = "erroresToolStripMenuItem";
            this.erroresToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.erroresToolStripMenuItem.Text = "&Reporte &Errores";
            this.erroresToolStripMenuItem.Click += new System.EventHandler(this.erroresToolStripMenuItem_Click);
            // 
            // mostrarAFNDToolStripMenuItem
            // 
            this.mostrarAFNDToolStripMenuItem.Name = "mostrarAFNDToolStripMenuItem";
            this.mostrarAFNDToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.mostrarAFNDToolStripMenuItem.Text = "Mostrar &AFND";
            this.mostrarAFNDToolStripMenuItem.Click += new System.EventHandler(this.mostrarAFNDToolStripMenuItem_Click);
            // 
            // mostrarAFDToolStripMenuItem
            // 
            this.mostrarAFDToolStripMenuItem.Name = "mostrarAFDToolStripMenuItem";
            this.mostrarAFDToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.mostrarAFDToolStripMenuItem.Text = "Mostrar &AFD";
            this.mostrarAFDToolStripMenuItem.Click += new System.EventHandler(this.mostrarAFDToolStripMenuItem_Click);
            // 
            // tablaTransicionesAFDToolStripMenuItem
            // 
            this.tablaTransicionesAFDToolStripMenuItem.Name = "tablaTransicionesAFDToolStripMenuItem";
            this.tablaTransicionesAFDToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.tablaTransicionesAFDToolStripMenuItem.Text = "Tabla &Transiciones AFD";
            this.tablaTransicionesAFDToolStripMenuItem.Click += new System.EventHandler(this.tablaTransicionesAFDToolStripMenuItem_Click);
            // 
            // reporteXMLToolStripMenuItem
            // 
            this.reporteXMLToolStripMenuItem.Name = "reporteXMLToolStripMenuItem";
            this.reporteXMLToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.reporteXMLToolStripMenuItem.Text = "Reporte &XML";
            this.reporteXMLToolStripMenuItem.Click += new System.EventHandler(this.reporteXMLToolStripMenuItem_Click);
            // 
            // reporteErroresXMLToolStripMenuItem
            // 
            this.reporteErroresXMLToolStripMenuItem.Name = "reporteErroresXMLToolStripMenuItem";
            this.reporteErroresXMLToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.reporteErroresXMLToolStripMenuItem.Text = "Reporte Errores &XML";
            this.reporteErroresXMLToolStripMenuItem.Click += new System.EventHandler(this.reporteErroresXMLToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 333);
            this.tabControl1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(557, 47);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(171, 379);
            this.treeView1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 432);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(745, 152);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // reporteTotalLexemasToolStripMenuItem
            // 
            this.reporteTotalLexemasToolStripMenuItem.Name = "reporteTotalLexemasToolStripMenuItem";
            this.reporteTotalLexemasToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.reporteTotalLexemasToolStripMenuItem.Text = "Reporte &Total Lexemas";
            this.reporteTotalLexemasToolStripMenuItem.Click += new System.EventHandler(this.reporteTotalLexemasToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(752, 596);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(25, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto1_201701133";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarcomoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem NuevaPestaña;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rehacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem seleccionartodoToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lexicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisLeicoToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem mostrarAFNDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarAFDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaTransicionesAFDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisDeLexemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteErroresXMLToolStripMenuItem;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem reporteTotalLexemasToolStripMenuItem;
    }
}

