using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        //propriedade para armaenar a conexão com o SQLite
        readonly SQLiteAsyncConnection _conn;
        //construtor da classe (construtor sempre é chamado quando o objeto é instanciado)
        public SQLiteDataBaseHelper (string patch) 
        {
            //campo conn vai receber um novo objeto que vai ser uma conexão com o arquivo de texto que está
            //no caminho do patch e a classe SQLite vai faer a operação de leitura e escrita
            _conn = new SQLiteAsyncConnection(patch);
            //através do CreateTable, o SQLite vai criar uma tabela se ela ainda não existir
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert (Produto p) 
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update (Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }
        public Task<int> Delete (int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
