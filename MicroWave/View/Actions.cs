using System;
using MicroWave.Utils;
using MicroWave.Controller;

namespace MicroWave.View
{
    class Actions
    {

        MicroWaveController controller = new MicroWaveController();
        PreSettingPrograms programs = PreSettingPrograms.GetInstance();

        public bool defineAlimento(String valor)
        {

            ProgramsSchema programa = programs.findPreSettingsPrograms(StringParser.RemoveDiacritics(valor));
            if (programa.getName() != "default")
            {
                ResponseSchema response = controller.definePrograma(programa);

                Console.WriteLine(response.getMessage());

                return response.getError();
            }

            Console.WriteLine(Constants.messageErrorGetProgram);
            Console.WriteLine("");
            Console.WriteLine(programs.getStringPreSettingProgramsName());
            Console.WriteLine("");
            return true;

        }

        public bool verUmProgramaDefinido(String name)
        {
            ProgramsSchema programa = programs.findPreSettingsPrograms(StringParser.RemoveDiacritics(name));
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
            Console.WriteLine("Aperte qualquer recla para voltar ao menu");
            Console.ReadKey();
            return false; // retorno para quando nao der nenhum erro
        }

        public bool verProgramasDefinidos()
        {
            ProgramsSchema[] programas = programs.getPrograms();
            for (int i = 0; i < programas.Length; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine("======================================");
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Programa {0}: {1}", i, programas[i].getName());
                Console.WriteLine("Potencia: {0}", programas[i].getPower());
                Console.WriteLine("Tempo: {0}", programas[i].getTime());
                Console.WriteLine("Caractere de aquecimento: '{0}'", programas[i].getCharacter());
                Console.WriteLine("Instruções: {0}", programas[i].getInstruction());
                Console.WriteLine("");
                Console.WriteLine("");

            }
            Console.WriteLine("Aperte qualquer recla para voltar ao menu");
            Console.ReadKey();
            return false; // retorno para quando nao der nenhum erro
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

        public bool aquecer()
        {
            ResponseSchema response = controller.aquecer();

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
    }
}
