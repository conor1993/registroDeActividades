using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using r = registroActividades.formas;
namespace registroActividades.formas
{
    public partial class frminicio : Form
    {
        public frminicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (cmbusuario.Text.Trim() == "") return;
          
            usuario.nombre = cmbusuario.Text;
            frmMenu fr = new frmMenu();
            

            this.Hide();
            fr.ShowDialog();
            this.Close(); 
         
        }
    }
}
