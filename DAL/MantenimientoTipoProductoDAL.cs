using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MantenimientoTipoProductoDAL
    {
        private readonly DataBaseDAL db = new DataBaseDAL();

        public void InsertaTipoProducto(string nombre, string tipoProducto, string tipoPrecio, int cantidad, decimal precio)
        {
            SqlCommand comando = CrearComando("SP_RegistraTipoProducto");
            AgregarParametros(comando, nombre, tipoProducto, tipoPrecio, cantidad, precio);
            db.InsercionDatos(comando);
        }

        public void ActualizaTipoProducto(string nombre, string tipoProducto, string tipoPrecio, int cantidad, decimal precio)
        {
            SqlCommand comando = CrearComando("SP_ActualizaTipoProducto");
            AgregarParametros(comando, nombre, tipoProducto, tipoPrecio, cantidad, precio);
            db.InsercionDatos(comando);
        }

        public bool ValidaExistenciaProducto(string nombre)
        {
            SqlCommand comando = CrearComando("SP_ConsultaExistenciaProducto");
            comando.Parameters.AddWithValue("@Nombre", nombre);
            DataSet ds = db.LecturaDatos(comando, "[T_Productos]");
            return ds.Tables[0].Rows.Count > 0;
        }

        private SqlCommand CrearComando(string nombreSP)
        {
            SqlCommand comando = new SqlCommand(nombreSP);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }

        private void AgregarParametros(SqlCommand comando, string nombre, string tipoProducto, string tipoPrecio, int cantidad, decimal precio)
        {
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@TipoProducto", tipoProducto);
            comando.Parameters.AddWithValue("@TipoPrecio", tipoPrecio);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@Precio", precio);
        }
    }
}
