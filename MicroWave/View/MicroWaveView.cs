using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MicroWave
{
    class MicroWaveView
    {

        MicroWaveController controller = new MicroWaveController();

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
            Console.WriteLine("");
            Console.WriteLine("");

            this.loadMenu();
        }

        private void loadMenu()
        {
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Definir Alimento");
            Console.WriteLine("2 - Definir Potencia");
            Console.WriteLine("3 - Definir Tempo");
            Console.WriteLine("4 - Aquecer");
            Console.WriteLine("5 - Aquecimento Rapido");
            Console.WriteLine("6 - Sair");

            int value = Convert.ToInt32(Console.ReadLine());

            this.callOption(value);
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
                    error = this.defineAlimento(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Opção 2: Definir potencia");
                    Console.WriteLine("Digite a potencia de 1 a 10");

                    error = this.definePotencia(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Opção 3: Definir tempo");
                    Console.WriteLine("Digite o tempo em segundos entre 1 e 120");
                    error = this.defineTempo(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 4:
                    Console.WriteLine("Opção 4: Aquecer");
                    Console.WriteLine("Aquecendo...");
                    error = this.aquecer();
                    break;
                case 5:
                    this.aquecerRapido();
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

        private bool defineAlimento(String valor)
        {
            ResponseSchema response = controller.defineAlimento(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
            
        }

        private bool definePotencia(int valor)
        {
            ResponseSchema response = controller.definePotencia(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        private bool defineTempo(int valor)
        {
            ResponseSchema response = controller.defineTempo(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        private bool aquecer()
        {
            ResponseSchema response = controller.aquecer();

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        private bool aquecerRapido()
        {
            Console.WriteLine("Opção 5: Aquecimento rápido");
            Console.WriteLine("Aquecendo na potencia 8 e durante 30 segundos\n");
            Console.WriteLine("Mudando tempo para 30 segundos...");
            if(!this.defineTempo(30))
            {
                Console.WriteLine("\nMudando potencia para 8...");
                if (!this.definePotencia(8))
                {
                    Console.WriteLine("\nAquecendo...");
                    if (!this.aquecer())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
