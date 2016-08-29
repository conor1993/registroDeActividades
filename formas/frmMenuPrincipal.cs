using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using r = registroActividades.formas;

namespace registroActividades
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {


        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmProyectos proyectos = new r.frmProyectos();
            proyectos.Show();


        }

        private void moduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmModulo frm = new r.frmModulo();
            frm.Show();
        }

        private void formasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmFormas frm = new r.frmFormas();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmClientes frm = new r.frmClientes();
            frm.Show();
        }

        private void registroDeActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmRegistroActivadades frm = new r.frmRegistroActivadades();
            frm.Show();
        }

        private void actividadesDiariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmActividadesDiarias frm = new r.frmActividadesDiarias();
            frm.Show();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r.frmActividades frm = new r.frmActividades();
            frm.Show();
        }
    }
}
