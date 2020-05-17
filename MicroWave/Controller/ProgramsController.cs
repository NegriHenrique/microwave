using MicroWave.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroWave.Controller
{
    class ProgramsController
    {

        Programs programs = Programs.GetInstance();

        public ProgramsSchema buscarPrograma(String valor)
        {
            return programs.findPrograms(StringParser.RemoveDiacritics(valor));
        }

        public String buscarNomeProgramas ()
        {
            return programs.getStringProgramsName();
        }

        public String buscarProgramas()
        {
            List<ProgramsSchema> programas =  programs.getPrograms();
            String message = "";

            foreach (ProgramsSchema programa in programas)
            {
                message += "\n\n" +
                    "\nPrograma: " + programa.getName() +
                    "\nPotencia: " + programa.getPower() +
                    "\nTempo: " + programa.getTime() +
                    "\nCaractere de aquecimento: '" + programa.getCharacter() + "'" +
                    "\nInstruções: " + programa.getInstruction() +
                    "\n\n" + 
                    "===============================================";
            }

            return message;
        }

        public ResponseSchema criarPrograma(String name, int power, int time, char character, String instrucion)
        {
            return programs.createNewProgram(name, power, time, character, instrucion);
        }

    }
}
