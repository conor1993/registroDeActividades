namespace registroActividades.formas
{
    partial class frmActividadesDiarias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataformas = new System.Windows.Forms.DataGridView();
            this.dtpFecInicio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataformas)).BeginInit();
            this.SuspendLayout();
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
            this.dataformas.Location = new System.Drawing.Point(12, 119);
            this.dataformas.MultiSelect = false;
            this.dataformas.Name = "dataformas";
            this.dataformas.ReadOnly = true;
            this.dataformas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataformas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataformas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataformas.Size = new System.Drawing.Size(527, 183);
            this.dataformas.TabIndex = 27;
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicio.Location = new System.Drawing.Point(12, 40);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(161, 21);
            this.dtpFecInicio.TabIndex = 28;
            this.dtpFecInicio.ValueChanged += new System.EventHandler(this.dtpFecInicio_ValueChanged);
            // 
            // frmActividadesDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 314);
            this.Controls.Add(this.dtpFecInicio);
            this.Controls.Add(this.dataformas);
            this.Name = "frmActividadesDiarias";
            this.Text = "Actividades Diarias";
            this.Load += new System.EventHandler(this.frmActividadesDiarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataformas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dataformas;
        private System.Windows.Forms.DateTimePicker dtpFecInicio;
    }
}