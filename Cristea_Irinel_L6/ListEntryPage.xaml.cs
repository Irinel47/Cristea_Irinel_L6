using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cristea_Irinel_L6.Data;
using Cristea_Irinel_L6.Models;

namespace Cristea_Irinel_L6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ListEntryPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetShopListsAsync();
        }
        async void OnShopListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new Models.ShopList()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as Models.ShopList
                });
            }
        }

        public ListEntryPage()
        {
            InitializeComponent();
        }
        
    }

    class listView
    {
        public static List<ShopList> ItemsSource { get; internal set; }
    }
}