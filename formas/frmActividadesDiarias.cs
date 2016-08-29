using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace registroActividades.formas
{
    public partial class frmActividadesDiarias : Form
    {


        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;

        public frmActividadesDiarias()
        {
            InitializeComponent();
        }

  
        private void llenarGrid()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                String fecha = dtpFecInicio.Value.ToShortDateString();

                DT = CN.Ejecutar("SELECT  usuario,count(usuario) as reportes FROM registroActividades  WHERE CAST(inicio AS DATE ) = '" + fecha + "' group by usuario");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                dataformas.DataSource = dtwDatos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtpFecInicio_ValueChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void frmActividadesDiarias_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
