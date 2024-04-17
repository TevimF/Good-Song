// See https://aka.ms/new-console-template for more information

string nomeApp = "Good Song";
string curso = "C#";
string plataforma = "Alura";
string meuNome = "Estêvão";

Dictionary<string, List<float>> bandasRegistradas = new Dictionary<string, List<float>>();
bandasRegistradas.Add("Banda teste", new List<float>(0));
void ExibirTituloOpcao(string titulo)
{
    int quantidadeCaracteres = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeCaracteres, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
void ExibirBoasVindas()
{
    Console.WriteLine(@"
░██████╗░░█████╗░░█████╗░██████╗░  ░██████╗░█████╗░███╗░░██╗░██████╗░
██╔════╝░██╔══██╗██╔══██╗██╔══██╗  ██╔════╝██╔══██╗████╗░██║██╔════╝░
██║░░██╗░██║░░██║██║░░██║██║░░██║  ╚█████╗░██║░░██║██╔██╗██║██║░░██╗░
██║░░╚██╗██║░░██║██║░░██║██║░░██║  ░╚═══██╗██║░░██║██║╚████║██║░░╚██╗
╚██████╔╝╚█████╔╝╚█████╔╝██████╔╝  ██████╔╝╚█████╔╝██║░╚███║╚██████╔╝
░╚═════╝░░╚════╝░░╚════╝░╚═════╝░  ╚═════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░");
    Console.WriteLine($"Bem vindo ao app {nomeApp}");
    Console.WriteLine($"Esse app foi desenvolvido por mim, {meuNome}, enquanto assistia o curso {curso} na {plataforma}");
    Thread.Sleep(3000);
    Console.Clear();
}
void ExibirOpcoesMenu()
{
    Console.Clear();
    ExibirTituloOpcao("- - - MENU INICIAL - - -");
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para excluir uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.WriteLine("\nDigite a sua opção");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoNumerica)
    {
        case 0:
            Console.WriteLine("Tchau!");
            break;
        case 1:
            RegistrarBanda();
            break;
        case 2:
            Console.Clear();
            MostrarBandas();
            Console.WriteLine("Você deseja retornar ao menu ou adicionar uma nova banda? \n[0] [1]");
            string resposta = Console.ReadLine()!;
            int respostaNum = int.Parse(resposta);
            switch (respostaNum)
            {
                case 0:
                    ExibirOpcoesMenu();
                    break;
                case 1:
                    RegistrarBanda();
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
            break;
        case 3:
            Console.WriteLine("Você escolheu a opção: " + opcaoEscolhida);
            AvaliacaoDeBandas();
            break;
        case 4:
            Console.WriteLine("Você escolheu a opção: " + opcaoEscolhida);
            ExcluirBanda();
            break;
        default:
            Console.WriteLine("Opção inválida");
            Thread.Sleep(1000);
            ExibirOpcoesMenu();
            break;
    }
    return;
}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Registro de Bandas");
    Console.WriteLine("Digite o nome da banda a ser registrada ou digite 0 para sair: ");
    string nomeBanda = Console.ReadLine()!;
    if (nomeBanda == "0")
    {
        Console.WriteLine("Voltando ao menu...");
        Thread.Sleep(1000); // esperar um tempo até dar a resposta
        Console.Clear();
        ExibirOpcoesMenu();
    }
    if (nomeBanda != null)
    {
        bandasRegistradas.Add(nomeBanda, new List<float>());
        Console.WriteLine("A banda {0} foi registrada com Sucesso!", nomeBanda);
    }
    Thread.Sleep(1000);
    RegistrarBanda();
}
void MostrarBandas()
{
    if (bandasRegistradas.Count <= 0)
    {
        ExibirTituloOpcao("Nenhuma banda registrada");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    }
    ExibirTituloOpcao("Mostrar Bandas adicionadas");
    Console.WriteLine("Estas são as bandas adicionadas: \n");
    foreach (string banda in bandasRegistradas.Keys)
    {
        int espacos = 30 - banda.Length;
        string ocupaEspaços = string.Empty.PadLeft(espacos, ' ');
        Console.WriteLine(banda.ToUpper() + ocupaEspaços + $" Avaliação: {ExibirMediaAvaliacoes(banda)}");
    }
}
void AvaliacaoDeBandas()
{
    Console.Clear() ;
    ExibirTituloOpcao("Avaliação de Bandas");
    MostrarBandas();    
    Console.WriteLine("Insira o nome da banda que deseja avaliar ou digite 0 para voltar ao menu: ");
    string selecao = Console.ReadLine()!;
    Thread.Sleep(1000);
    if (selecao == "0")
    {
        Console.Clear();
        ExibirOpcoesMenu();
    }
    else if (SeraQueTem(selecao))
    {
        Console.WriteLine("Insira a sua avaliação para a banda {0} ", selecao);
        float avaliacao = float.Parse(Console.ReadLine()!);
        foreach (string nome in bandasRegistradas.Keys)
        {
            if (NormatizarNome(nome) == NormatizarNome(selecao))
            {
                bandasRegistradas[nome].Add(avaliacao);
                break;
            }
        }
        Console.WriteLine("A banda {0} foi avaliada!", selecao);
        Thread.Sleep(1000);
    }
    else
    {
        Console.WriteLine("\nBanda não registrada, digite novamente");
        Thread.Sleep(1000);
    }
    AvaliacaoDeBandas();
}
float ExibirMediaAvaliacoes(string banda)
{
    List<float> notasDaBanda = bandasRegistradas[banda];
    if (notasDaBanda.Count > 0 )
    {
        return notasDaBanda.Average();
    }else
    {
        return 0;
    }
}
void ExcluirBanda()
{
    Console.Clear();
    Console.WriteLine("\nSelecione a banda que deseja excluir ou digite 0 para sair");
    MostrarBandas();
    string exclusao = Console.ReadLine()!;
    if (exclusao == "0")
    {
        ExibirOpcoesMenu();
    }
    else if (!SeraQueTem(exclusao))
    {
        Console.WriteLine("Banda não encontrada");
        Thread.Sleep(1000);
        ExcluirBanda();
    }
    else
    {
        foreach (string nome in bandasRegistradas.Keys)
        {
            if (NormatizarNome(nome) == NormatizarNome(exclusao))
            {
                bandasRegistradas.Remove(nome);
                Console.WriteLine($"A banda '{nome.ToUpper()}' foi deletada com sucesso");
                Thread.Sleep(1000);
                break;
            }
        }
        ExcluirBanda();
    }
}
string NormatizarNome(string banda)
{
    banda = banda.ToLower();
    banda = banda.ReplaceLineEndings("");
    banda = banda.Replace(" ", "");
    return banda;
}
bool SeraQueTem(string banda)
{
    foreach (string nome in bandasRegistradas.Keys)
    {
        if (NormatizarNome(nome) == NormatizarNome(banda))
        {
            return true;
        }
    }
    return false;
}
void Start()
{
    ExibirBoasVindas();
    ExibirOpcoesMenu();
}
Start();

