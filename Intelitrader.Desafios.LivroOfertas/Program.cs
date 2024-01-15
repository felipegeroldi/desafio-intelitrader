namespace Intellitrader.Desafios.LivroOfertas;

public class Program
{
    static LivroOfertas _livroOfertas = new LivroOfertas();

    public static void Main(string[] args)
    {
        CarregarDadosCmdLine();

        Console.WriteLine("\nResumo do Livro:");
        _livroOfertas.ExibirDados();
    }

    public static void CarregarDadosCmdLine()
    {
        Console.Write("Digite a quantidade de mensagens a serem processadas: ");
        string input = Console.ReadLine()!;
        try
        {
            int quantidadeMensagens = int.Parse(input);
            string[] mensagens = new string[quantidadeMensagens];
            for(int i=0; i<quantidadeMensagens; i++)
            {
                mensagens[i] = Console.ReadLine()!;
            }

            _livroOfertas.Processar(mensagens);
        } catch {
            Console.WriteLine("Ocorreu um erro ao processar os dados");
        }
    }
}