namespace registroActividades.formas
{
    partial class frmReporteFormas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteFormas));
            this.cmbForma = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.cmbProyecto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataformas = new System.Windows.Forms.DataGridView();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataformas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbForma
            // 
            this.cmbForma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbForma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbForma.BackColor = System.Drawing.Color.White;
            this.cmbForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbForma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbForma.FormattingEnabled = true;
            this.cmbForma.Location = new System.Drawing.Point(141, 106);
            this.cmbForma.Name = "cmbForma";
            this.cmbForma.Size = new System.Drawing.Size(275, 24);
            this.cmbForma.TabIndex = 1;
            this.cmbForma.SelectedIndexChanged += new System.EventHandler(this.cmbForma_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(32, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Formas:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbGuardar,
            this.toolStripButton3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbModulo
            // 
            this.cmbModulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModulo.BackColor = System.Drawing.Color.White;
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(141, 76);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(275, 24);
            this.cmbModulo.TabIndex = 14;
            this.cmbModulo.SelectedIndexChanged += new System.EventHandler(this.cmbModulo_SelectedIndexChanged);
            // 
            // cmbProyecto
            // 
            this.cmbProyecto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProyecto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProyecto.BackColor = System.Drawing.Color.White;
            this.cmbProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProyecto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProyecto.FormattingEnabled = true;
            this.cmbProyecto.Location = new System.Drawing.Point(141, 46);
            this.cmbProyecto.Name = "cmbProyecto";
            this.cmbProyecto.Size = new System.Drawing.Size(275, 24);
            this.cmbProyecto.TabIndex = 15;
            this.cmbProyecto.SelectedIndexChanged += new System.EventHandler(this.cmbProyecto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Proyecto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Modulo:";
            // 
            // dataformas
            // 
            this.dataformas.AllowUserToAddRows = false;
            this.dataformas.AllowUserToDeleteRows = false;
            this.dataformas.AllowUserToOrderColumns = true;
            this.dataformas.AllowUserToResizeRows = false;
            this.dataformas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataformas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataformas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataformas.Location = new System.Drawing.Point(12, 177);
            this.dataformas.MultiSelect = false;
            this.dataformas.Name = "dataformas";
            this.dataformas.ReadOnly = true;
            this.dataformas.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataformas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataformas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataformas.Size = new System.Drawing.Size(704, 170);
            this.dataformas.TabIndex = 28;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::registroActividades.Properties.Resources.guardar;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(23, 22);
            this.tsbGuardar.Text = "toolStripButton2";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::registroActividades.Properties.Resources.Borrar;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // frmReporteFormas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 359);
            this.Controls.Add(this.dataformas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProyecto);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbForma);
            this.Name = "frmReporteFormas";
            this.Text = "Reporte De Formas";
            this.Load += new System.EventHandler(this.frmReporteFormas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataformas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbForma;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.ComboBox cmbProyecto;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView dataformas;
    }
}