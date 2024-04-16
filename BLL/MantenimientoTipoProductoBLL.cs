using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;


public class MantenimientoTipoProductoBLL
{
    private readonly MantenimientoTipoProductoDAL tipoProductoDAL = new MantenimientoTipoProductoDAL();

    public void InsertaTipoProducto(string nombre, string tipoProducto, string tipoPrecio, int cantidad, decimal precio)
    {
        tipoProductoDAL.InsertaTipoProducto(nombre, tipoProducto, tipoPrecio, cantidad, precio);
    }

    public void ActualizaTipoProducto(string nombre, string tipoProducto, string tipoPrecio, int cantidad, decimal precio)
    {
        tipoProductoDAL.ActualizaTipoProducto(nombre, tipoProducto, tipoPrecio, cantidad, precio);
    }

    public bool ValidaExistenciaProducto(string nombre)
    {
        return tipoProductoDAL.ValidaExistenciaProducto(nombre);
    }
}
