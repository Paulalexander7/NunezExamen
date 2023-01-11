using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NunezExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(String usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
        }
        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtMonto.Text) < 1)
                {
                    DisplayAlert("Error", "Ingrese un monto mayor o igual 1", "Cerrar");
                }
                if (Convert.ToDouble(txtMonto.Text) > 4000)
                {
                    DisplayAlert("Error", "Inngrese un monto menor o igual a 4000", "Cerrar");
                }

            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                double montoInicial = Convert.ToDouble(txtMonto.Text);
                double Pago = ((4000 - montoInicial) / 5) +(4000 * 0.05);
                double pagoTotal = Pago * 5 + montoInicial;
                
                txtPago.Text = Pago.ToString();
                txtPagoTotal.Text = pagoTotal.ToString();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.ToString(), "Cerrar");

            }


        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Resumen(lblUsuario.Text, txtNombre.Text, txtPago.Text));
        }
    }
}