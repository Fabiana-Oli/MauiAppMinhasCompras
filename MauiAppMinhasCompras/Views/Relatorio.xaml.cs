using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    public Relatorio()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // ALTERADO: pega as datas escolhidas pelo usuário
            DateTime dataInicial = (DateTime)dtp_data_inicial.Date;
            DateTime dataFinal = (DateTime)dtp_data_final.Date;

            List<Produto> produtos = await App.Db.GetAll();

            // ALTERADO: filtra os produtos pelo período
            List<Produto> filtrados = produtos
                .Where(p => p.DataCadastro.Date >= dataInicial &&
                            p.DataCadastro.Date <= dataFinal)
                .ToList();

            // ALTERADO: mostra os produtos filtrados
            lst_relatorio.ItemsSource = filtrados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}