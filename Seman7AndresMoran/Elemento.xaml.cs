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
    public partial class Elemento : ContentPage
    {

        private SQLiteAsyncConnection conn;
        public int Idseleccionado;
        IEnumerable<Estudiante> RUpdate;
        IEnumerable<Estudiante> RDelete;

        public Elemento(int id)
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteAsyncConnection>();
            Idseleccionado = id;
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databsaePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databsaePath);
                RUpdate = Update(db, Nombre.Text, Usuario.Text, Contraseña.Text, Idseleccionado);
                DisplayAlert("Alerta", "Se Actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }

        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databsaePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databsaePath);
                RDelete = Delete(db, Idseleccionado);
                DisplayAlert("Alerta", "Se elomino correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }

        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id= ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario=?, Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }
    }
}