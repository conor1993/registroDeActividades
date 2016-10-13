using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using registroActividades.clases;

namespace registroActividades.formas
{
    public partial class frmRegistroActivadades : Form
    {
      
        ArrayList tb,sp,fun,vista;
        DataSet DT, DTs;
        DataTable DS;
        bool selecciono;
        String nombre;

        public frmRegistroActivadades()
        {
            InitializeComponent();
        }

        #region eventos

        private void frmRegistroActivadades_Load(object sender, EventArgs e)
        {
            llenarcombos();
 
           
        }

        private void cmbBd_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarcombosBaseDatos();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {


            if (!validar())
                return;
            int idAct;

            #region tablas
            tb = new ArrayList();
            foreach (DataGridViewRow row in dataTablas.Rows)
            {
                DataGridViewCheckBoxCell ck = row.Cells["Selecionar"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(ck.Value) && row.Cells[2].Value == null)
                {
                    nombre = row.Cells["nombre0"].Value.ToString();
                    guardarObjetos(nombre, "tabla");
                    tb.Add(nombre);
                }

            }
            #endregion

            #region sp
            sp = new ArrayList();
            foreach (DataGridViewRow row in dataSp.Rows)
            {
                DataGridViewCheckBoxCell ck = row.Cells["Selecion"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(ck.Value) && row.Cells[2].Value == null)
                {
                    nombre = row.Cells["nombre2"].Value.ToString();
                    guardarObjetos(nombre, "procedimiento almacenado");
                    sp.Add(nombre);
                }

            }
            #endregion

            #region vista
            vista = new ArrayList();
            foreach (DataGridViewRow row in dataVista.Rows)
            {
                DataGridViewCheckBoxCell ck = row.Cells["seleccion"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(ck.Value) && row.Cells[2].Value == null)
                {
                    nombre = row.Cells["nombre3"].Value.ToString();
                    guardarObjetos(nombre, "vista");
                    vista.Add(nombre);
                }

            }
            #endregion

            #region funciones
            fun = new ArrayList();
            foreach (DataGridViewRow row in dataFunciones.Rows)
            {
                DataGridViewCheckBoxCell ck = row.Cells["seleccion2"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(ck.Value) && row.Cells[2].Value == null)
                {
                    nombre = row.Cells["nombre4"].Value.ToString();
                    guardarObjetos(nombre, "funcion");
                    fun.Add(nombre);
                }

            }

            #endregion

            #region guardarRegistroAct

            idAct = guardarRegistroActv();
            #endregion

            if (cmbProyecto.SelectedIndex != -1 && cmbModulo.SelectedIndex != -1 && cmbForma.SelectedIndex != -1)
            {
                #region GuardarDetalleActividad
                int idproyecto = (int)cmbProyecto.SelectedValue;
                int idModulo = (int)cmbModulo.SelectedValue;


                #region recorrer tabla
                if (tb.Count > 0)
                {

                    for (int i = 0; i < tb.Count; i++)
                    {

                        GuardarDetalle(idAct, idproyecto, idModulo, cmbForma.Text, tb[i].ToString());
                    }
                }
                #endregion

                #region recorrer sp
                if (sp.Count > 0)
                {
                    for (int i = 0; i < sp.Count; i++)
                    {
                        GuardarDetalle(idAct, idproyecto, idModulo, cmbForma.Text, sp[i].ToString());
                    }
                }
                #endregion

                #region recorrer vista
                if (vista.Count > 0)
                {
                    for (int i = 0; i < vista.Count; i++)
                    {
                        GuardarDetalle(idAct, idproyecto, idModulo, cmbForma.Text, vista[i].ToString());
                    }
                }
                #endregion

                #region recorrer sp
                if (fun.Count > 0)
                {
                    for (int i = 0; i < fun.Count; i++)
                    {
                        GuardarDetalle(idAct, idproyecto, idModulo, cmbForma.Text, fun[i].ToString());
                    }
                }
                #endregion
                #endregion
            }

            limpiarCampos();

            

        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboForma();
            }
            catch (Exception ex) { }
        }

        private void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboModulo();
            }
            catch (Exception ex) { }
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBd.Text = "< Seleccione una BD... >";

            int pro = 0, mod = 0, formz;
            DTs = new DataSet();
            Conexion CN = new Conexion();

            try
            {

                CN.Abrir();
                if (cmbProyecto.SelectedIndex != -1 && cmbModulo.SelectedIndex != -1)
                {
                    try { pro = Convert.ToInt32(cmbProyecto.SelectedValue); }
                    catch (Exception ex) { pro = 0; }
                    try { mod = Convert.ToInt32(cmbModulo.SelectedValue); }
                    catch (Exception ex) { mod = 0; }

                }


                DTs = CN.Ejecutar("select objetos.nombre, tipodeObjeto.nombre, detalleActividad.bd from detalleActividad " +
                                   " join objetos on Objetos.id = detalleActividad.idObjeto " +
                                   " join tipodeObjeto on tipodeObjeto.id = Objetos.idTipo " +
                                   " where  idProyecto = '" + pro + "' and idModulo = '" + mod + "' and idforma = '" + cmbForma.Text + "' ");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                if (DTs.Tables[0].Rows.Count > 0)
                {
                    cmbBd.Text = DTs.Tables[0].Rows[0].ItemArray[2].ToString();

                    for (int i = 0; i < DTs.Tables[0].Rows.Count; i++)
                    {

                        switch (DTs.Tables[0].Rows[i].ItemArray[1].ToString())
                        {
                            case "tabla":

                                foreach (DataGridViewRow row in dataTablas.Rows)
                                {
                                    if (row.Cells["Nombre0"].Value.ToString().Trim() == DTs.Tables[0].Rows[i].ItemArray[0].ToString())
                                    {
                                        row.Cells[1].Value = true;
                                        row.Cells[2].Value = 1;
                                    }
                                }

                                break;
                            case "vista":
                                foreach (DataGridViewRow row in dataVista.Rows)
                                {
                                    if (row.Cells["nombre3"].Value.ToString().Trim() == DTs.Tables[0].Rows[i].ItemArray[0].ToString())
                                    {
                                        row.Cells[1].Value = true;
                                        row.Cells[2].Value = 1;
                                    }
                                }
                                break;
                            case "funcion":
                                foreach (DataGridViewRow row in dataFunciones.Rows)
                                {
                                    if (row.Cells["nombre4"].Value.ToString().Trim() == DTs.Tables[0].Rows[i].ItemArray[0].ToString())
                                    {
                                        row.Cells[1].Value = true;
                                        row.Cells[2].Value = 1;
                                    }
                                }
                                break;
                            case "procedimiento almacenado":
                                foreach (DataGridViewRow row in dataSp.Rows)
                                {
                                    if (row.Cells["nombre2"].Value.ToString().Trim() == DTs.Tables[0].Rows[i].ItemArray[0].ToString())
                                    {
                                        row.Cells[1].Value = true;
                                        row.Cells[2].Value = 1;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }

                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region metodos
        private void llenarcombos()
        {
            try
            {
                comboClientes();
                comboActividad();
                comboProyectos();
                comboBaseDatos();
            }catch(Exception ex){}
        }

        private void comboActividad()
        {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select * from catActividades");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                txtActividad.DisplayMember = "nombre";
                txtActividad.ValueMember = "id";
                txtActividad.DataSource = DT.Tables[0].DefaultView;
                txtActividad.SelectedIndex = -1;
                txtActividad.Text = "Seleccione una opción";

               

             
                 int tamaño = DT.Tables[0].Rows.Count;
               string[] autores = new String[tamaño];
               for (int i = 0; i < tamaño;i++)
               {
                   autores[i] = DT.Tables[0].Rows[i].ItemArray[1].ToString();
                
               }

               txtActividad.AutoCompleteCustomSource.AddRange(autores.ToArray());
                txtActividad.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtActividad.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboModulo()
        {
            int id = (int)cmbProyecto.SelectedValue;
            DT = new DataSet();
            if(cmbProyecto.SelectedIndex != -1 && cmbProyecto.SelectedValue != null){
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();

               

                DT = CN.Ejecutar("select * from CatModulos where idProyecto = " +id);
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

        }

        private void comboForma()
        {
            Conexion CN = new Conexion();
            try
            {
                
                int id = (int)cmbModulo.SelectedValue;

                CN.Abrir();

                DT = new DataSet();
                DT = CN.Ejecutar("select CatFormas.Forma   from CatFormas join CatModulos on CatFormas.idModulo = CatModulos.id where CatModulos.id ="+id);
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

        private void comboProyectos()
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

              //MessageBox.Show(ex.Message);

            }

        }

        private void comboClientes() {


                    Conexion CN = new Conexion();
                    try
                    {

                        CN.Abrir();

                        DT = new DataSet();
                        DT = CN.Ejecutar("select * from CatClientes");
                        CN.Cerrar();

                    }
                    catch (Exception ex)
                    {

                      // MessageBox.Show(ex.Message);
                    }

                    try
                    {
                        cmbCliente.DisplayMember = "nombre";
                        cmbCliente.ValueMember = "id";
                        cmbCliente.DataSource = DT.Tables[0].DefaultView;
                        cmbCliente.SelectedIndex = -1;
                        cmbCliente.Text = "Seleccione una opción";
                    }
                    catch (Exception ex)
                    {

                       // MessageBox.Show(ex.Message);
                    }
              
        }

        private void comboBaseDatos() {
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

        private void llenarcombosBaseDatos()
        {

            String nombreBd = cmbBd.Text;

            Conexion CN = new Conexion();

            #region "llena las tablas"
            
            try
            {
                if ((int)cmbBd.SelectedValue != 0)
                {
                    CN.Abrir();

                    DT = new DataSet();
                    DT = CN.Ejecutar("use " + nombreBd + " " +
                                     "SELECT  ROW_NUMBER() OVER (ORDER BY TABLE_NAME) AS Row,TABLE_NAME AS nombre FROM INFORMATION_SCHEMA.TABLES order by TABLE_NAME ");
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
                    
                    dataTablas.DataSource = null;
                    dataTablas.AutoGenerateColumns = false;
                    dataTablas.DataSource = DT.Tables[0].DefaultView;
                 
                }
                else
                {
                    dataTablas.DataSource = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
              
            #endregion

            #region "llena los store"
            try
            {
               
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

                    dataSp.DataSource = null;
                    dataSp.AutoGenerateColumns = false;
                    dataSp.DataSource = DT.Tables[0].DefaultView; ;

                }
                else
                {
                    dataSp.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            #endregion

            #region "llena los vistas"
            try
            {

                if ((int)cmbBd.SelectedValue != 0)
                {
                    CN.Abrir();

                    DT = new DataSet();
                    DT = CN.Ejecutar("use " + nombreBd + " " +
                                     "  select object_id,name as nombre from sys.Views order by name ");
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
                    dataVista.DataSource = null;
                    dataVista.AutoGenerateColumns = false;
                    dataVista.DataSource = DT.Tables[0].DefaultView;
                    
                }
                else
                {
                    dataVista.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            #endregion

            #region "llena funciones"
            try
            {

                if ((int)cmbBd.SelectedValue != 0)
                {
                    CN.Abrir();

                    DT = new DataSet();
                    DT = CN.Ejecutar("use " + nombreBd + " " +
                                     "  select object_id, name as nombre  from sys.all_objects where type in ('FN','IF') and schema_id = 1 order by 2 ");
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
                    dataFunciones.DataSource = null;
                    dataFunciones.AutoGenerateColumns = false;
                    dataFunciones.DataSource = DT.Tables[0].DefaultView;

                }
                else
                {
                    dataFunciones.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            #endregion

        }
        
        private bool validar()
        {
            bool validado = true;
            String Mensaje = "";

            if (cmbProyecto.SelectedIndex == -1)
            {
                Mensaje = Mensaje + "   * No se ha capturado el proyecto.\n";
            }

            if (cmbCliente.SelectedIndex == -1)
            {
                Mensaje = Mensaje + "   * No se ha capturado el cliente.\n";
            }
          


            if (Mensaje != "")
            {
                Mensaje = "Antes de guardar debe corregir lo siguiente:\n\n" + Mensaje;
                validado = false;
                MessageBox.Show(Mensaje, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validado;
        }

        private void limpiarCampos()
        {
            cmbProyecto.Text = "Seleccione una opción";
            txtVersion.Text="";
            chkProgramacion.Checked =false;
            chkOtro.Checked= false;
            txtDescripcion.Text = "";
            txtUbicacion.Text ="";
            cmbCliente.Text = "Seleccione una opción";
            txtMetodo.Text = "";
            nupEstado.Value =0;
            cmbModulo.Text = "Seleccione una opción";
            cmbForma.Text ="";
            txtClase.Text = "";
            txtTipo.Text = "";
            txtActividad.Text ="";
            cmbBd.Text ="< Seleccione una BD... >";
       
            
            //cmbTablas.Text = "Seleccione una opción";
            //cmbTablas.DataSource = null;
            //cmbStore.DataSource = null;
            //cmbVistas.DataSource = null;
            //cmbFunciones.DataSource = null;
           
          

        }

        private void  guardarObjetos(String nombre,String  tipo) {
           
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GuardarObjeto";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("nombre", nombre));
                    command.Parameters.Add(new SqlParameter("tipo", tipo));

                   
                   try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                         
                        
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

        private int guardarRegistroActv()
        {
            

            int idAct =0;
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {
                 

                 int     idproyecto    =  (int)cmbProyecto.SelectedValue;
                 String  version       =  txtVersion.Text;
                 bool    programacion  =  chkProgramacion.Checked;
                 bool    otro          =  chkOtro.Checked;
                 String  descripcion   =  txtDescripcion.Text;
                 String  ubicacion     =  txtUbicacion.Text;
                 int     idcliente     = (int)cmbCliente.SelectedValue;
                 String  metodo        =  txtMetodo.Text;
                 int estado = (int)nupEstado.Value;

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GuardarRegistroActividad";
                    command.CommandType = CommandType.StoredProcedure;

		            command.Parameters.Add(new SqlParameter("idproyecto",idproyecto));
		            command.Parameters.Add(new SqlParameter("version", version));
		            command.Parameters.Add(new SqlParameter("programacion",programacion));
		            command.Parameters.Add(new SqlParameter("otro", otro));
		            command.Parameters.Add(new SqlParameter("descripcion", descripcion));
		            command.Parameters.Add(new SqlParameter("ubicacion", ubicacion));
		            command.Parameters.Add(new SqlParameter("idcliente", idcliente));
		            command.Parameters.Add(new SqlParameter("inicio", dtpFecInicio.Value));
		            command.Parameters.Add(new SqlParameter("fin", dtpFecFin.Value));
                    command.Parameters.Add(new SqlParameter("metodo", metodo));

                    command.Parameters.Add(new SqlParameter("estado", estado));
                     if (cmbModulo.SelectedIndex != -1 && cmbModulo.SelectedValue != null)
                     {   
                         command.Parameters.Add(new SqlParameter("idmodulo",(int)cmbModulo.SelectedValue));
                     }
                     else
                     {
                         command.Parameters.AddWithValue("@idmodulo", DBNull.Value);
                     }
		            
		                if (cmbForma.SelectedIndex != -1 && cmbForma.SelectedValue != null)
                     {
                         command.Parameters.AddWithValue("@forma", cmbForma.Text);
                     }
                     else
                     {
                         command.Parameters.AddWithValue("@forma", DBNull.Value);
                     }
		            command.Parameters.Add(new SqlParameter("clase",txtClase.Text ));
		            command.Parameters.Add(new SqlParameter("tipo", txtTipo.Text));
                    command.Parameters.Add(new SqlParameter("usuario", usuario.nombre));
                    command.Parameters.Add(new SqlParameter("idTipoActividad", (int)txtActividad.SelectedValue));

                    command.Parameters.Add(new SqlParameter("idActividad", SqlDbType.Int, 4));
                    command.Parameters["idActividad"].Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        Bitacora bit = new Bitacora(Con.ObtenerConexionString(),"JUAN");
                        bit.recorrerForma(this,2);
                        //agregar cambio a bitacora -----------------
                      
                        //-------------------------------------------

                        idAct = int.Parse(command.Parameters["idActividad"].Value.ToString());
                        MessageBox.Show("La actividad ha sido guardada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                        comboActividad();
                        

                    }

                }
            }
            return idAct;
        }

        private void GuardarDetalle(int idAct, int idproyecto, int idModulo, string idForma, String p)
        {
            
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {


         

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GuardarDetalleActividad";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("idActividad", idAct));
                    command.Parameters.Add(new SqlParameter("idProyecto", idproyecto));
                    command.Parameters.Add(new SqlParameter("idmodulo", idModulo));
                    command.Parameters.Add(new SqlParameter("forma", cmbForma.Text));
                    command.Parameters.Add(new SqlParameter("idObjeto", p));
                    command.Parameters.Add(new SqlParameter("bd", cmbBd.Text));

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                       
                    }
                    catch (SqlException ex)
                    {
                        
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
             

                    }

                }
            }

        }
        #endregion







    }
}
