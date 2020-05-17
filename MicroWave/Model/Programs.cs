using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroWave.Utils
{
    public class Programs
    {
        private static Programs _instance;
        private List<ProgramsSchema> programs = new List<ProgramsSchema>();
        
        public Programs()
        {

            programs.Add(new ProgramsSchema("frango", 3, 30, ';', "Aqui tem uma instrução que eu nao sei o que por"));
            programs.Add(new ProgramsSchema("pipoca", 7, 40, ',', "Aqui tem uma instrução que eu nao sei o que por"));
            programs.Add(new ProgramsSchema("batata", 2, 10, ':', "Aqui tem uma instrução que eu nao sei o que por"));
            programs.Add(new ProgramsSchema("feijao", 10, 120, ',', "Aqui tem uma instrução que eu nao sei o que por"));
            programs.Add(new ProgramsSchema("lasanha", 5, 90, '`', "Aqui tem uma instrução que eu nao sei o que por"));
        }

        public static Programs GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Programs();
            }
            return _instance;
        }

        public List<ProgramsSchema> getPrograms()
        {
            return this.programs;
        }

        public ProgramsSchema findPrograms(String value)
        {
            foreach (ProgramsSchema program in programs)
            {
                if (program.getName() == value)
                {
                    return program;
                }

            }
            return new ProgramsSchema();
        }

        public String getStringProgramsName()
        {
            String message = "Alimentos compativeis são: ";
            programs.ForEach( delegate(ProgramsSchema program) { 
                message = "\n - " + program.getName();
            });

            return message; 
        }

        public ResponseSchema createNewProgram(String name, int power, int time, char character, String instrucion) 
        {
            if (name.Length == 0)
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramName);
            }

            if (power < Constants.minPowerPossible || power > Constants.maxPowerPossible)
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramPower);
            }

            if (time < Constants.minTimePossible || time > Constants.maxTimePossible)
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramTime);
            }

            if (character == '\0')
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramCharacter);
            }

            if (instrucion.Length == 0)
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramInstrucion);
            }

            if (this.findPrograms(name).getName() != "default")
            {
                return new ResponseSchema(true, Constants.messageErrorCreateProgramDuplicate);
            }

            this.programs.Add(new ProgramsSchema(name, power, time, character, instrucion));

            return new ResponseSchema(false, Constants.messageSuccesCreateProgram);
        }
    }
}
