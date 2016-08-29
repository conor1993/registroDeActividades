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
    public partial class frmactividadesDeldiacs : Form
    {

        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;
        public frmactividadesDeldiacs()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            



        }

        private void llenarGrid()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("SELECT distinct * FROM registroActividades WHERE inicio BETWEEN "+dtpFecInicio.Value +" and ");
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
    }
}
