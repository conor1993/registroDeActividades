using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace registroActividades.formas
{
    public partial class frmFormas : Form
    {

        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;

        public frmFormas()
        {
            InitializeComponent();
        }


        private void frmFormas_Load(object sender, EventArgs e)
        {
            llenarcombo();
            llenarGrid();
        }

        private void llenarGrid()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select Forma , Nombre, descripcion as modulo from CatFormas inner join CatModulos on CatFormas.idModulo = CatModulos.id");
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

        private void llenarcombo()
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

                //MessageBox.Show(ex.Message);
            }

            try
            {
                cmbProyecto.DisplayMember = "descripcion";
                cmbProyecto.ValueMember = "id";
                cmbProyecto.DataSource = DT.Tables[0].DefaultView;
                cmbProyecto.SelectedIndex = -1;
                cmbProyecto.Text = "Seleccione una opción";
            }
            catch (Exception ex)
            {

                //  MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;

            int id = (int)cmbModulo.SelectedValue;

     
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GuardarForma";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("forma", txtForma.Text));
                    command.Parameters.Add(new SqlParameter("nombre", txtnombre.Text));
                    command.Parameters.Add(new SqlParameter("modulo", id));



                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();

                        //agregar bitacora
                        txtnombre.Text = "";
                        txtForma.Text = "";
                        cmbProyecto.SelectedIndex = -1;
                        cmbProyecto.Text = "Seleccione una opción";
                        dataformas.DataSource = null;
                        llenarGrid();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();

                    }

                }
            }


        }

        private void buscar(String id)
        {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select Forma , Nombre, CatModulos.id,CatModulos.idproyecto from CatFormas join CatModulos on CatFormas.idModulo = CatModulos.id where CatFormas.Forma ='" + id + "'");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                txtForma.Text = DT.Tables[0].Rows[0].ItemArray[0].ToString();
                txtnombre.Text = DT.Tables[0].Rows[0].ItemArray[1].ToString();
                cmbProyecto.SelectedValue = int.Parse(DT.Tables[0].Rows[0].ItemArray[3].ToString());
                cmbModulo.SelectedValue = int.Parse(DT.Tables[0].Rows[0].ItemArray[2].ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataformas_DoubleClick(object sender, EventArgs e)
        {
            if (dataformas.SelectedRows.Count > 0)
            {
                String id = dataformas.SelectedRows[0].Cells[0].Value.ToString();
                buscar(id);
            }
        }

        private bool Validar()
        {
            Boolean Validado = true;
            String Mensaje = "";



            if (txtForma.Text.Trim() == "")
                Mensaje = Mensaje + "   * No se ha capturado el campo forma.\n";

            if (txtnombre.Text.Trim() == "")
                Mensaje = Mensaje + "   * No se ha capturado el campo nombre.\n";

            if (cmbModulo.SelectedIndex == -1)
                Mensaje = Mensaje + "   * No se ha capturado el Acampo modulo.\n";




            if (Mensaje != "")
            {
                Validado = false;
                Mensaje = "Antes de guardar debe corregir lo siguiente:\n\n" + Mensaje;
                MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Validado;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            LIMPIAR();
        }

        private void LIMPIAR()
        {   
            
            txtnombre.Text = "";
            txtForma.Text = "";
            cmbProyecto.SelectedIndex = -1;
            cmbProyecto.Text = "Seleccione una opción";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "BorrarForma";
                    command.CommandType = CommandType.StoredProcedure;

                    

                    command.Parameters.Add(new SqlParameter("id", txtForma.Text));

                    command.Parameters.Add(new SqlParameter("Error", SqlDbType.Int, 4));
                    command.Parameters["Error"].Direction = ParameterDirection.Output;

                    command.Parameters.Add(new SqlParameter("borro", SqlDbType.Int, 4));
                    command.Parameters["borro"].Direction = ParameterDirection.Output;



                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        if (int.Parse(command.Parameters["borro"].Value.ToString()) > 0)
                            MessageBox.Show("lA forma no  ha sido borrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LIMPIAR();
                        dataformas.DataSource = null;
                        llenarGrid();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();

                    }

                }
            }
           
        }

        private void llenarModulo() {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();
                int id=0;
                try { id = (int)cmbProyecto.SelectedValue; }
                catch (Exception ex) { }
                DT = CN.Ejecutar("select *  from CatModulos where idproyecto  = "+id);
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

                MessageBox.Show(ex.Message);
            }
        
        
        }

        private void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarModulo();
        }
    }
}
