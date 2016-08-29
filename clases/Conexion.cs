using System.Data;

using System.Data.SqlClient;

using System.Data.Common;

/* Creamos la Clase */

class Conexion

{

private SqlConnection Con; // Obj Conexion
string DtsConection = "";
public Conexion()

{

; // Contendra los Datos las Conexion.

/* Para trabajar con el servidor SQLExpress de la maquina */

//string DtsConection = “Data Source=.\SQLEXPRESS;Initial Catalog=NOMBRE_BD; ” + “Integrated Security=True;”;

/* Para trabajar con Archivo de BD (.mdf), si que este montado en SQLExpress */

//DtsConection = “Server=.\SQLExpress;AttachDbFilename=C:\Direccion\NOMBRE.mdf; Database=NOMBRE;

/* Para trabajar con un servidor remoto Ya sea una Base de datos Remota o en Caso de WEB SITE cuando la pongamos en el Host */

/* Necesitamos la IP del Servidor de BD, el puerto generalmente es 1533, Usuario y Password lo proporciona el Hostring */

DtsConection = "Data Source=INTEGRASRV3; Database=RegistroActividades; User ID=sa; Password=int3gr@;";

Con = new SqlConnection(DtsConection);

}

public void Abrir() // Metodo para Abrir la Conexion

{

Con.Open();

}

public string ObtenerConexionString()
{
    return DtsConection;
}

public void Cerrar() // Metodo para Cerrar la Conexion

{

Con.Close();

}

public DataSet Ejecutar(string Comando) // Metodo para Ejecutar Comandos

{

SqlDataAdapter CMD = new SqlDataAdapter(Comando, Con); // Creamos un DataAdapter con el Comando y la Conexion

DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo

CMD.Fill(DS); // Ejecutamos el Comando en la Tabla

return DS; // Regresamos el DataSet

}


} // Fin de la Clase