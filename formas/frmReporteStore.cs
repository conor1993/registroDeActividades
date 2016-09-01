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
    public partial class frmReporteStore : Form
    {
        DataSet DT, DTs;
        DataTable DS;
        DataSet dtsDtaos;
        DataView dtwDatos;
        public frmReporteStore()
        {
            InitializeComponent();
        }

        private void frmReporteStore_Load(object sender, EventArgs e)
        {
            comboBaseDeDatos();
        }

        private void cmbBd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboStore();
     
            }catch(Exception ex){
               // MessageBox.Show(ex.Message);
            }
        }

        private void llenarGrid()
        {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                String frm = cmbStore.Text;

                DT = CN.Ejecutar("select detalleActividad.idforma,objetos.nombre, detalleActividad.bd from detalleActividad "
                             +" join objetos on Objetos.id = detalleActividad.idObjeto " 
                             +" join tipodeObjeto on tipodeObjeto.id = Objetos.idTipo "
                             +" where tipodeObjeto.nombre = 'procedimiento almacenado' and objetos.nombre  = '" + frm + "'");
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

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            crearReporte();
        }

        private void crearReporte()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                String frm = cmbStore.Text;

                DT = CN.Ejecutar("select detalleActividad.idforma as forma,objetos.nombre as tipo, detalleActividad.bd from detalleActividad "
                             + " join objetos on Objetos.id = detalleActividad.idObjeto "
                             + " join tipodeObjeto on tipodeObjeto.id = Objetos.idTipo "
                             + " where tipodeObjeto.nombre = 'procedimiento almacenado' and objetos.nombre  = '" + frm + "'");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                r.reporteStore Reporte = new r.reporteStore();
                Reporte.SetDataSource(DT.Tables[0]);
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

        private void comboBaseDeDatos()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();

                DT = new DataSet();
                DT = CN.Ejecutar("SELECT name, database_id, create_date FROM sys.databases where name not in('master','model','msdb','tempdb')  union SELECT '< Seleccione una BD... >',0,'1900-01-01' order by name; ");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
            }

            try
            {
                cmbBd.DisplayMember = "name";
                cmbBd.ValueMember = "database_id";
                cmbBd.DataSource = DT.Tables[0].DefaultView;
                cmbBd.Text = "Seleccione una opción";


            }
            catch (Exception ex)
            {

                //  MessageBox.Show(ex.Message);
            }

        }

        private void comboStore()
        {
            try
            {
                String nombreBd = cmbBd.Text;

                Conexion CN = new Conexion();
                if ((int)cmbBd.SelectedValue != 0)
                {
                    CN.Abrir();

                    DT = new DataSet();
                    DT = CN.Ejecutar("use " + nombreBd + " " +
                                     " select object_id,name as nombre from sys.procedures order by name ");
                    CN.Cerrar();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                if ((int)cmbBd.SelectedValue != 0)
                {

                    cmbStore.DisplayMember = "nombre";
                    cmbStore.ValueMember = "database_id";
                    cmbStore.DataSource = DT.Tables[0].DefaultView;
                    cmbStore.Text = "Seleccione una opción";

                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }

        private void cmbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

    }
}
