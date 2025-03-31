using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Se a tela est� exibindo um produto, esse c�digo pega os dados do produto j� carregado
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                //Mant�m o mesmo ID do produto original (ou seja, est� sendo atualizado, n�o criado)
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Categoria = txt_categoria.Text,
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            //Chama um m�todo ass�ncrono que atualiza o produto no banco de dados
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            //Depois de atualizar o produto, o usu�rio � levado de volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}