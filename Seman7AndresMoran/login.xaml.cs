using Seman7AndresMoran.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seman7AndresMoran
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        public login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<SQLiteAsyncConnection>();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "uisrael.db3");
                var db = new SQLiteConnection(path);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_Where(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "Cerrar");
                }


            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());

        }

        public static IEnumerable<Estudiante> select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("select * fron Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);
        }
    }
}