using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using r = registroActividades.reportes;
using f = registroActividades.formas;

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

        private void crearReporte()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                String fecha = dtpFecInicio.Value.ToShortDateString();

                DT = CN.Ejecutar("SELECT  usuario,count(usuario) as reportes,CONVERT(VARCHAR(10), inicio, 108) AS inicio,CONVERT(VARCHAR(10), fin, 108) AS fin,CatProyecto.descripcion as proyecto FROM registroActividades join catproyecto on CatProyecto.id = registroActividades.idproyecto   WHERE CAST(inicio AS DATE ) = '" + fecha + "' group by usuario,inicio,fin,CatProyecto.descripcion ");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                String fecha = dtpFecInicio.Value.ToShortDateString();
                r.reporteDeRegistoActividades Reporte = new r.reporteDeRegistoActividades();
                Reporte.SetDataSource(DT.Tables[0]);
                Reporte.SetParameterValue("fecha", fecha);
                f.VisorReportes visor = new f.VisorReportes();
                visor.Text = "Listado de Asistencia";
                visor.Reporte = Reporte;
                visor.ShowDialog();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmActividadesDiarias_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            crearReporte();
        }
    }
}
