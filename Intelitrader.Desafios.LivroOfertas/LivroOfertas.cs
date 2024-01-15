

namespace Intellitrader.Desafios.LivroOfertas;

internal class LivroOfertas {
    public EntradaLivro? Inicio { get; set; }

    internal void Processar(string[] mensagens)
    {
        foreach(var entradaDados in mensagens)
        {
            string[] dados = entradaDados.Split(',');
            EAcaoLivros acao = Enum.Parse<EAcaoLivros>(dados[1]);

            if(acao == EAcaoLivros.Inserir)
                InserirEntrada(dados);
            else if (acao == EAcaoLivros.Modificar)
                ModificarEntrada(dados);
            else if (acao == EAcaoLivros.Deletar)
                DeletarEntrada(dados);
        }
    }

    private void DeletarEntrada(string[] dados)
    {
        EntradaLivro? entrada = BuscarEntradaPorCodigo(dados[0]);
        if(entrada is not null)
        {
            if(entrada.Anterior != null)
                entrada.Anterior.Proximo = entrada.Proximo;

            if(entrada.Proximo != null)
                entrada.Proximo.Anterior = entrada.Anterior;
        }
        else
        {
            Console.WriteLine($"Entrada de código {dados[0]} não encontrada para remoção.");
        }
    }

    private void InserirEntrada(string[] dados)
    {
        try
        {
            EntradaLivro? entradaExistente = BuscarEntradaPorCodigo(dados[0]);
            if(entradaExistente is not null)
            {
                Console.WriteLine($"Entrada de codigo {dados[0]} já existe");
                return;
            }
            
            var novaEntrada = new EntradaLivro
            {
                Codigo = int.Parse(dados[0]),
                Valor = double.Parse(dados[2]),
                Quantidade = int.Parse(dados[3]),
            };

            if(Inicio == null)
                Inicio = novaEntrada;
            else
            {
                // Navega até a ultima entrada para adicionar uma nova
                EntradaLivro? ultimaEntrada = Inicio;
                while(ultimaEntrada.Proximo != null)
                    ultimaEntrada = ultimaEntrada.Proximo;

                novaEntrada.Anterior = ultimaEntrada;
                ultimaEntrada.Proximo = novaEntrada;
            }
        } catch 
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar a entrada de código {dados[0]}.");
        }
    }

    private void ModificarEntrada(string[] dados)
    {
        EntradaLivro? entrada = BuscarEntradaPorCodigo(dados[0]);
        if(entrada is not null)
        {
            entrada.Valor = double.Parse(dados[2]);
            entrada.Quantidade = int.Parse(dados[3]);
        }
        else
        {
            Console.WriteLine($"Entrada de código {dados[0]} não encontrada para modificação.");
        }
    }

    private EntradaLivro? BuscarEntradaPorCodigo(string codigo)
        => BuscarEntradaPorCodigo(int.Parse(codigo));

    private EntradaLivro? BuscarEntradaPorCodigo(int codigo)
    {
        EntradaLivro? entrada = Inicio;
        while(entrada != null && entrada.Codigo != codigo)
            entrada = entrada.Proximo;

        return entrada;
    }

    internal void ExibirDados()
    {
        EntradaLivro? entrada = Inicio;
        while(entrada != null)
        {
            Console.WriteLine($"{entrada.Codigo},{entrada.Valor:0.##},{entrada.Quantidade}");
            entrada = entrada.Proximo;
        }
    }
}