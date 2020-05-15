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

        public bool definePotencia(int valor)
        {
            ResponseSchema response = controller.definePotencia(valor);

            Console.WriteLine(response.getMessage());

            return response.getError();
        }

        public bool defineTempo(int valor)
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
            Console.WriteLine("Opção 5: Aquecimento rápido");
            Console.WriteLine("Aquecendo na potencia 8 e durante 30 segundos\n");
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
