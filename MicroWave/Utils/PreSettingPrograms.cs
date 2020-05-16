using System;

namespace MicroWave.Utils
{
    public class PreSettingPrograms
    {
        private static PreSettingPrograms _instance;
        private ProgramsSchema[] programs;
        
        public PreSettingPrograms()
        {

            this.programs = new ProgramsSchema[5]
                {
                    new ProgramsSchema("frango", 3, 30, ';', "Aqui tem uma instrução que eu nao sei o que por"),
                    new ProgramsSchema("pipoca", 7, 40, ',', "Aqui tem uma instrução que eu nao sei o que por"),
                    new ProgramsSchema("batata", 2, 10, ':', "Aqui tem uma instrução que eu nao sei o que por"),
                    new ProgramsSchema("feijao", 10, 120, ',', "Aqui tem uma instrução que eu nao sei o que por"),
                    new ProgramsSchema("lasanha", 5, 90, '`', "Aqui tem uma instrução que eu nao sei o que por"),
                };
        }

        public static PreSettingPrograms GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PreSettingPrograms();
            }
            return _instance;
        }

        public ProgramsSchema[] getPrograms()
        {
            return this.programs;
        }

        public ProgramsSchema findPreSettingsPrograms(String value)
        {
            for(int i = 0; i < programs.Length ; i++ )
            {
                if (programs[i].getName() == value)
                {
                    return programs[i];
                }
            }
            return new ProgramsSchema();
        }

        public String getStringPreSettingProgramsName()
        {
            return "Alimentos compativeis são: \n - Frango \n - Pipoca \n - Batata \n - Feijão \n - Lasanha"; 
        }
    }
}
