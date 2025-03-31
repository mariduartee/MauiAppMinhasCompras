using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            //Validação da propriedade Descricao
            get => _descricao; 
            set
            {
              //Se o valor for igual a nulo, lançamos uma exceção, impedindo que a propriedade fique sem valor
                if(value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }
                _descricao = value;
            } 
        }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco;  }
        public string Categoria { get; set; }
    }
}
