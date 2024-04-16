using System;
using System.Web.UI;
namespace SistemaVerduleria
{
    public partial class MantenimientoTipoProducto : Page
    {
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {
                string nombreProducto = txtNombreProducto.Text;
                string tipoProducto = ListaTipoProducto.SelectedValue.ToString();
                string tipoPrecio = ListaTipoPrecio.Text.ToString();
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal precio = Convert.ToDecimal(txtPrecio.Text);

                MantenimientoTipoProductoBLL tipoProductoBLL = new MantenimientoTipoProductoBLL();

                if (tipoProductoBLL.ValidaExistenciaProducto(nombreProducto))
                {
                    tipoProductoBLL.ActualizaTipoProducto(nombreProducto, tipoProducto, tipoPrecio, cantidad, precio);
                    LimpiaCampos();
                    MostrarAlerta("Producto Actualizado Exitosamente");
                }
                else
                {
                    tipoProductoBLL.InsertaTipoProducto(nombreProducto, tipoProducto, tipoPrecio, cantidad, precio);
                    LimpiaCampos();
                    MostrarAlerta("Se ha agregado correctamente un nuevo producto");
                }
            }
            else
            {
                MostrarAlerta("Debe completar todos los campos para poder almacenar la información");
            }
        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrEmpty(txtNombreProducto.Text) &&
                   !string.IsNullOrEmpty(txtNombreProducto.Text) &&
                   !string.IsNullOrEmpty(txtCantidad.Text) &&
                   ListaTipoPrecio.SelectedValue != "---Seleccione una Opción---" &&
                   ListaTipoProducto.SelectedValue != "---Seleccione una Opción---";
        }

        private void LimpiaCampos()
        {
            txtNombreProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            ListaTipoPrecio.SelectedValue = "---Seleccione una Opción---";
            ListaTipoProducto.SelectedValue = "---Seleccione una Opción---";
        }

        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "PopupScript", $"alert('{mensaje}');", true);
        }
    }
}
