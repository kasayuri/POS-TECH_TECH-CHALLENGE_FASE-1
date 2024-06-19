namespace CadastroNumeros.Interfaces
{
    public interface IBancoDados
    {
        int Inserir<T>();
        object Retornar(int id);
    }
}
