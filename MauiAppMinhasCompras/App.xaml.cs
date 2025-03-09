using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // O campo _db é estático, o que significa que ele pertence à classe, e não a uma instância específica dela.
        static SQLiteDataBaseHelper _db;
        public static SQLiteDataBaseHelper Db
        {
            get
            {
                // Verifica se a instância de _db ainda não foi criada
                if (_db == null)
                {
                    // Gera o caminho do arquivo do banco de dados
                    string path = Path.Combine(
                    /* Retorna o caminho para a pasta de dados locais da aplicação, que é um diretório usado para armazenar 
dados persistentes da aplicação*/
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        // Este é o nome do arquivo do banco de dados SQLite. O arquivo será criado ou aberto nesse local
                        "banco_sqlite_compras.db3");
                    /* Cria uma nova instância da classe SQLiteDatabaseHelper, passando o caminho do banco de dados. 
                     * Esse é o ponto onde o banco de dados é inicializado. 
                    A instância criada será armazenada na variável _db*/
                    _db = new SQLiteDataBaseHelper(path);
                }
                // Após a criação da instância (ou caso ela já exista), o método retorna a instância de _db
                return _db;
            }
        }
        /* Quando a aplicação precisar acessar o banco de dados, ela chama a propriedade Db:  
        SQLiteDatabaseHelper db = App.Db;
        O getter da propriedade Db verifica se a instância de _db já foi criada:  
Se não foi criada(primeira vez), ele cria a instância e a inicializa com o caminho do banco de dados.*/
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
