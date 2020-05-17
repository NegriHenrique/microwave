using System;
using MicroWave.Utils;
using MicroWave.Controller;
using System.Threading;

namespace MicroWave.View
{
    class Actions
    {

        MicroWaveController microWaveController = new MicroWaveController();
        ProgramsController programsController = new ProgramsController();

        public bool defineAlimento(String valor)
        {

            ProgramsSchema programa = programsController.buscarPrograma(valor);

            if (programa.getName() != "default")
            {
                ResponseSchema response = microWaveController.definePrograma(programa);

                Console.WriteLine(response.getMessage());

                return response.getError();
            }

            Console.WriteLine(Constants.messageErrorGetProgram);
            Console.WriteLine("");
            Console.WriteLine(programsController.buscarNomeProgramas());
            Console.WriteLine("");
            return true;

        }

        public bool verUmProgramaDefinido(String name)
        {
            ProgramsSchema programa = programsController.buscarPrograma(name);
            if (programa.getName() != "default")
            {
                Console.WriteLine("Programa: {0}", programa.getName());
                Console.WriteLine("Potencia: {0}", programa.getPower());
                Console.WriteLine("Tempo: {0}", programa.getTime());
                Console.WriteLine("Caractere de aquecimento: '{0}'", programa.getCharacter());
                Console.WriteLine("Instruções: {0}", programa.getInstruction());
            } else
            {
                Console.WriteLine("Programa não encontrado....");
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
            return false; // retorno para quando nao der nenhum erro
        }

        public bool verProgramasDefinidos()
        {
            Console.WriteLine(programsController.buscarProgramas());
            Console.WriteLine("Aperte qualquer recla para voltar ao menu");
            Console.ReadKey();
            return false; // retorno para quando nao der nenhum erro
        }

        private bool definePotencia(int valor)
        {
            ResponseSchema response = microWaveController.definePotencia(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        private bool defineTempo(int valor)
        {
            ResponseSchema response = microWaveController.defineTempo(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        public bool aquecer()
        {
            ResponseSchema response = microWaveController.aquecer();

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        public bool aquecerRapido()
        {
            Console.WriteLine("Mudando tempo para 30 segundos...");
            if (!this.defineTempo(30))
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

        public bool criarNovoPrograma()
        {
            Console.WriteLine("Escreva o alimento que o programa irá esquentar");
            String nome = Console.ReadLine().Trim();

            Console.WriteLine("Escreva a potencia com um numero de {0} a {1}", Constants.minPowerPossible, Constants.maxPowerPossible);
            String potenciaString = Console.ReadLine();
            int potencia;

            if (!Int32.TryParse(potenciaString, out potencia))
            {
                potencia = -1;
            }

            Console.WriteLine("Escreva o tempo com um numero de {0} a {1}", Constants.minTimePossible, Constants.maxTimePossible);
            String tempoString = Console.ReadLine();
            int tempo;

            if (!Int32.TryParse(tempoString, out tempo))
            {
                tempo = -1;
            }

            Console.WriteLine("Escreva o caractere de aquecimento que o programa irá esquentar");
            char caracter = Console.ReadLine().ToCharArray()[0];

            Console.WriteLine("Escreva o alimento que o programa irá esquentar");
            String instrucao = Console.ReadLine();

            ResponseSchema response = programsController.criarPrograma(nome, potencia, tempo, caracter, instrucao);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }
    }
}
