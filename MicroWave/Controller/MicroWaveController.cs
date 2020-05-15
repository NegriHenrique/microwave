using System;
using MicroWave.Utils;

namespace MicroWave.Controller
{
    class MicroWaveController
    {

        MicroWave model = new MicroWave();

        public String[] getStatus()
        {
            return new String[3] { model.getAlimento(), model.getPotencia().ToString(), model.getTempo().ToString() } ;
        }

        public ResponseSchema definePrograma( ProgramsSchema programa)
        {
            return new ResponseSchema(false, "");
        }

        public ResponseSchema defineAlimento(String value)
        {
            return model.setAlimento(value);
        }

        public ResponseSchema definePotencia(int value)
        {

            return model.setPotencia(value);
        }

        public ResponseSchema defineTempo(int value)
        {
            return model.setTempo(value);
        }

        public ResponseSchema aquecer()
        {
            return model.aquecer();
        }
    }
}
