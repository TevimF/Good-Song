
using GoodSong.Models;

namespace GoodSong.Menus;

internal class MenuExcluirConteudo : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        
        ExcluirBanda();
        void ExcluirBanda()
        {
            base.Executar(bandasRegistradas);
            ExibirTituloOpcao("Exclusão de Conteúdo");
            Console.WriteLine("\nSelecione a banda que deseja excluir ou digite 0 para sair");
            string exclusao = Console.ReadLine()!;
            if (exclusao == "0")
            {
                return;
            }
            else if (CadeEla(exclusao, bandasRegistradas) == null)
            {
                Console.WriteLine("Banda não encontrada");
                Thread.Sleep(1000);
                ExcluirBanda();
            }
            else
            {
                Console.WriteLine("Você deseja excluir a banda {0}? [s] [n]", exclusao);
                string resposta = Console.ReadLine()!;
                if (resposta == "n")
                {
                    ExcluirBanda();
                }
                else
                {
                    bandasRegistradas.Remove(CadeEla(exclusao, bandasRegistradas)!.Nome);
                }
                ExcluirBanda();
            }
        }
    }
}
