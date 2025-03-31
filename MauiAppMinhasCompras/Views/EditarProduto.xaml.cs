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
            //Se a tela está exibindo um produto, esse código pega os dados do produto já carregado
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                //Mantém o mesmo ID do produto original (ou seja, está sendo atualizado, não criado)
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Categoria = txt_categoria.Text,
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            //Chama um método assíncrono que atualiza o produto no banco de dados
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            //Depois de atualizar o produto, o usuário é levado de volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}