using Newtonsoft.Json;
using PRODUIT.Data;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PRODUIT
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetProductAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(priceEntry.Text) && !string.IsNullOrWhiteSpace(quantityEntry.Text))
            {
                await App.Database.SavePersonAsync(new Produit
                {
                    Name = nameEntry.Text,
                    Price = int.Parse(priceEntry.Text),
                    quantity = int.Parse(quantityEntry.Text)

                });

                nameEntry.Text = priceEntry.Text = quantityEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetProductAsync();
            }
        }


        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idEntry.Text))
            {
                //Get Person

                var produit = await App.Database.GetItemAsync(Convert.ToInt32(idEntry.Text));
                if (produit != null)
                {
                    //Delete Person
                    await App.Database.DeleteItemAsync(produit);
                    idEntry.Text = string.Empty;
                    await DisplayAlert("Success", "produit Deleted", "OK");
                    collectionView.ItemsSource = await App.Database.GetProductAsync();

                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter produit id", "OK");
            }
        }




    }
}
