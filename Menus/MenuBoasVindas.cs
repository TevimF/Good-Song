

namespace GoodSong.Menus
{
    internal class MenuBoasVindas
    {
        string NomeApp = "Good Song 2.0";
        string Curso = "C#";
        string Plataforma = "Alura";
        string MeuNome = "Estêvão Fonseca";
        internal void Executar()
        {
            ExibirBoasVindas();
            void ExibirBoasVindas()
            {
                Console.WriteLine(@"
░██████╗░░█████╗░░█████╗░██████╗░  ░██████╗░█████╗░███╗░░██╗░██████╗░
██╔════╝░██╔══██╗██╔══██╗██╔══██╗  ██╔════╝██╔══██╗████╗░██║██╔════╝░
██║░░██╗░██║░░██║██║░░██║██║░░██║  ╚█████╗░██║░░██║██╔██╗██║██║░░██╗░
██║░░╚██╗██║░░██║██║░░██║██║░░██║  ░╚═══██╗██║░░██║██║╚████║██║░░╚██╗
╚██████╔╝╚█████╔╝╚█████╔╝██████╔╝  ██████╔╝╚█████╔╝██║░╚███║╚██████╔╝
░╚═════╝░░╚════╝░░╚════╝░╚═════╝░  ╚═════╝░░╚════╝░╚═╝░░╚══╝░╚═════╝░");
                Console.WriteLine($"Bem vindo ao app {NomeApp}");
                Console.WriteLine($"Esse app foi desenvolvido por mim, {MeuNome}, enquanto assistia o curso {Curso} na {Plataforma}");
                Thread.Sleep(3000);
                Console.Clear();
                return;
            }
        }
    }
}
