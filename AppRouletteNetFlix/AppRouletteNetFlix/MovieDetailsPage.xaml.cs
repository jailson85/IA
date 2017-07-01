using AppRouletteNetFlix.Model;
using AppRouletteNetFlix.Service;
using System;
using Xamarin.Forms;

namespace AppRouletteNetFlix
{
    public partial class MovieDetailsPage : ContentPage
    {
        MovieService service = new MovieService();

        public MovieDetailsPage(Movie filme)
        {
            //verifica se o objeto é null 
            //lança a exceção
            if (filme == null)
                throw new ArgumentNullException(nameof(filme));

            InitializeComponent();
            //vincula o filme ao BindingContext 
            //para fazer o databinding na view
            BindingContext = filme;
        }
    }
}
