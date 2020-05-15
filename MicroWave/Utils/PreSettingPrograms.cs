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
                    new ProgramsSchema("frango", 3, 30, ';'),
                    new ProgramsSchema("pipoca", 7, 40, ','),
                    new ProgramsSchema("batata", 2, 10, ':'),
                    new ProgramsSchema("feijao", 10, 120, ','),
                    new ProgramsSchema("lasanha", 5, 90, '`'),
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
