using System;
using MicroWave.Utils;

namespace MicroWave.Controller
{
    class MicroWaveController
    {

        MicroWave model = MicroWave.getInstance();

        public String[] getStatus()
        {
            return new String[4] { model.getAlimento(), model.getPotencia().ToString(), model.getTempo().ToString(), model.getCaractere().ToString() } ;
        }

        public ResponseSchema definePrograma(ProgramsSchema programa)
        {
            ResponseSchema resNome = model.setAlimento(programa.getName());
            ResponseSchema resChar = model.setCaractere(programa.getCharacter());
            ResponseSchema resTempo = model.setTempo(programa.getTime());
            ResponseSchema resPotencia = model.setPotencia(programa.getPower());


            if (resNome.getError())
            {
                return resNome;
            }

            if (resChar.getError())
            {
                return resChar;
            }

            if (resPotencia.getError())
            {
                return resPotencia;
            }

            if (resTempo.getError())
            {
                return resTempo;
            }

            return new ResponseSchema(false, Constants.messageSuccessSetProgram );

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
