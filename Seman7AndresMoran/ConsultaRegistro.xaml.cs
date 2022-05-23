using Seman7AndresMoran.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Seman7AndresMoran
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;


        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var ResulRegistros = await conn.Table<Estudiante>().ToArrayAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(ResulRegistros);
            ListaUsuarios.ItemsSource = _TablaEstudiante;
            base.OnAppearing();

        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int id = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(id));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}