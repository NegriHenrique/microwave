using System;
using System.Threading;
using MicroWave.Controller;
using MicroWave.Utils;

namespace MicroWave.View
{
    class MicroWaveView
    {

        MicroWaveController controller = new MicroWaveController();
        Actions actions = new Actions();

        public void start()
        {
                Console.Clear();
                this.loadHeader();
                Thread.Sleep(2000);
                this.loadStatusAtual();
        }

        private void loadHeader()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("*        MICRO-ONDAS         *");
            Console.WriteLine("* Criado por: Henrique Negri *");
            Console.WriteLine("*  github.com/NegriHenrique  *");
            Console.WriteLine("******************************");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void loadStatusAtual()
        {
            String[] status = controller.getStatus();

            Console.Clear();
            Console.WriteLine("STATUS ATUAL:");
            Console.WriteLine("* Alimento: {0}", status[0]);
            Console.WriteLine("* Potencia: {0}", status[1]);
            Console.WriteLine("* Tempo: {0}", status[2]);
            Console.WriteLine("* Caractere de aquecimento: '{0}'", status[3]);
            Console.WriteLine("");
            Console.WriteLine("");

            this.loadMenu();
        }

        private void loadMenu()
        {
            String[] valores = new String[6]{ "1", "2", "3", "4", "5", "6" };

            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Definir Alimento");
            Console.WriteLine("2 - Buscar por programa");
            Console.WriteLine("3 - Ver programas existentes");
            Console.WriteLine("4 - Aquecer");
            Console.WriteLine("5 - Aquecimento Rapido");
            Console.WriteLine("6 - Sair");

            String input = Console.ReadLine();

            if (Array.IndexOf(valores, input) != -1)
            {
                int value = Convert.ToInt32(input);

                this.callOption(value);
            } else
            {
                Console.WriteLine("Opção inválida...");
                Thread.Sleep(2000);
                this.loadStatusAtual();
            }


        }

        private void callOption(int value)
        {
            Console.Clear();
            bool error = false;
            switch (value)
            {
                case 1:
                    Console.WriteLine("Opção 1: Definir alimento");
                    Console.WriteLine("Digite o alimento...");
                    error = actions.defineAlimento(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Opção 2: Buscar por programa");
                    Console.WriteLine("Digite o nome do alimento");
                    error = actions.verUmProgramaDefinido(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Opção 3: Ver programas existentes");
                    error = actions.verProgramasDefinidos();
                    break;
                case 4:
                    Console.WriteLine("Opção 4: Aquecer");
                    Console.WriteLine("Aquecendo...");
                    error = actions.aquecer();
                    break;
                case 5:
                    Console.WriteLine("Opção 5: Aquecimento rápido");
                    Console.WriteLine("Aquecendo na potencia 8 e durante 30 segundos\n");
                    actions.aquecerRapido();
                    break;
                case 6:
                    Console.WriteLine("Opção 6: Sair");
                    Console.WriteLine("Fechando o programa...");
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            if(error)
            {
                Console.WriteLine("Precione qualquer tecla para continuar...");
                Console.ReadKey();
            } 
                this.loadStatusAtual();
                
        }

        
    }
}
