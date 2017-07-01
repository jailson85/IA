using AppRouletteNetFlix.Model;
using AppRouletteNetFlix.Service;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppRouletteNetFlix
{
    public partial class MoviesPage : ContentPage
    {
        MovieService servico = new MovieService();
        public MoviesPage()
        {
            InitializeComponent();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //verifica a quantidade de caracteres digitados
            if (e.NewTextValue.Length > 5)
            {
                List<Movie> filmes = await servico.LocalizaFilmesPorAtor(e.NewTextValue);

                if (filmes == null || filmes.Count == 0)
                {
                    //esconde o listview e exibe o label
                    //exibe a mensagem no label
                    lvwMovies.IsVisible = false;
                    lblmsg.IsVisible = true;
                    lblmsg.Text = "Não foi possível retornar a lista de filmes";
                    lblmsg.TextColor = Color.Red;
                }
                else
                {
                    //exibe o listview e esconde o label 
                    //exibe a lista de filmes
                    lvwMovies.IsVisible = true;
                    lblmsg.IsVisible = false;
                    lvwMovies.ItemsSource = filmes;
                }
            }
            else
            {
                //esconde o listview e exibe o label coma mensagem
                lvwMovies.IsVisible = false;
                lblmsg.IsVisible = true;
                lblmsg.Text = "Digite pelo menos 6 caracteres.";
            }
        }

        private async void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //obtem o item selecionado
            var filme = e.SelectedItem as Movie;

            //deseleciona o item do listview
            lvwMovies.SelectedItem = null;

            //chama a pagina MovieDetailsPage
            await Navigation.PushAsync(new MovieDetailsPage(filme));
        }
    }
}
