using Seman7AndresMoran.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seman7AndresMoran
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection conn;

        public Registro()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasena = Contrasenia.Text };
            conn.InsertAsync(DatosRegistro);
            LimpiarFormulario();

        }

        void LimpiarFormulario()
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contrasenia.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "OK");

        }
    }
}