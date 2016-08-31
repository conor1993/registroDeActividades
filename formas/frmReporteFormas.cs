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
    public partial class frmReporteFormas : Form
    {

        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;

        public frmReporteFormas()
        {
            InitializeComponent();
        }

        private void frmReporteFormas_Load(object sender, EventArgs e)
        {
            llenarCombos();
        }      

        private void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboModulo();
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboForma();
        }

        private void llenarCombos()
        {


            comboProyecto();

        }

        private void comboProyecto()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();

                DT = new DataSet();
                DT = CN.Ejecutar("select *  from CatProyecto");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
            }

            try
            {
                cmbProyecto.DisplayMember = "descripcion";
                cmbProyecto.ValueMember = "id";
                cmbProyecto.DataSource = DT.Tables[0].DefaultView;
                cmbProyecto.Text = "Seleccione una opción";
                cmbProyecto.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);

            }
        }

        private void comboModulo()
        {

            int id = (int)cmbProyecto.SelectedValue;
            DT = new DataSet();
            if (cmbProyecto.SelectedIndex != -1 && cmbProyecto.SelectedValue != null)
            {
                Conexion CN = new Conexion();
                try
                {

                    CN.Abrir();



                    DT = CN.Ejecutar("select * from CatModulos where idProyecto = " + id);
                    CN.Cerrar();

                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                }

                try
                {
                    cmbModulo.DisplayMember = "descripcion";
                    cmbModulo.ValueMember = "id";
                    cmbModulo.DataSource = DT.Tables[0].DefaultView;
                    cmbModulo.SelectedIndex = -1;
                    cmbModulo.Text = "Seleccione una opción";

                }
                catch (Exception ex)
                {

                    // MessageBox.Show(ex.Message);
                }

            }
        }

        private void comboForma()
        {
            Conexion CN = new Conexion();
            try
            {

                int id = (int)cmbModulo.SelectedValue;

                CN.Abrir();

                DT = new DataSet();
                DT = CN.Ejecutar("select CatFormas.Forma   from CatFormas join CatModulos on CatFormas.idModulo = CatModulos.id where CatModulos.id =" + id);
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
            }

            try
            {
                cmbForma.DataSource = null;
                cmbForma.DisplayMember = "Forma";
                cmbForma.ValueMember = "id";
                cmbForma.DataSource = DT.Tables[0].DefaultView;
                cmbForma.SelectedIndex = -1;
                cmbForma.Text = "Seleccione una opción";

            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
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
                String frm = cmbForma.Text;

                DT = CN.Ejecutar("select bd,tabla,sp,vista,funcion  from registroActividades where forma = '"+frm+"'");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                r.ReporteDeFormas Reporte = new r.ReporteDeFormas();
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

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void llenarGrid()
        {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                String frm = cmbForma.Text;

                DT = CN.Ejecutar("select bd,tabla,sp,vista,funcion  from registroActividades where forma = '"+frm+"'");
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
