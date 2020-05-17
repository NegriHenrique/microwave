using System; 

namespace MicroWave.Utils
{
    public static class Constants
    {

        public static int maxPowerPossible => 10;
        public static int minPowerPossible => 1;

        public static int maxTimePossible => 120;
        public static int minTimePossible => 1;

        public static string messageErrorSetFood => "Não foi possivel adicionar o alimento no micro-ondas";

        public static string messageSuccessSetFood(String value) => value + " foi adicionado ao micro-ondas";

        public static string messageErrorSetPower => "Valor de potencia invalido. Deve ser um valor entre " + minPowerPossible + " e " + maxPowerPossible + ".";
        public static string messageSuccessSetPower(int value) => "A potencia foi definida para " + value.ToString() + ".";

        public static string messageErrorSetTime => "Valor de tempo inválido. Deve ser um valor entre " + minTimePossible + " e " + maxTimePossible+ "."; 

        public static string messageSuccessSetTime(int value) => "O tempo foi definido para " + value.ToString() + " segundos.";

        public static string messageErrorHeatingTime => "Erro ao aquecer. Tempo deve estar entre " + minTimePossible + " e " + maxTimePossible + ".";

        public static string messageErrorHeatingPower => "Erro ao aquecer. Potencia deve estar entre " + minPowerPossible + " e " + maxPowerPossible + ".";

        public static string messageErrorGetProgram => "Alimento incompatível com o programa.";

        public static string messageErrorSetCharacter => "Erro ao setar o caractere de aquecimento.";
        public static string messageSuccessSetCharacter(char value) => value + " definido como caractere com sucesso.";

        public static string messageSuccessSetProgram => "Programa definido com sucesso.";

        public static string messageErrorCreateProgramName => "Erro ao criar programa. Nome não pode ser vazio.";

        public static string messageErrorCreateProgramPower => "Erro ao criar programa. Potencia deve estar entre" + minPowerPossible + " e " + maxPowerPossible + ".";

        public static string messageErrorCreateProgramTime => "Erro ao criar programa. Tempo deve estar entre " + minTimePossible + " e " + maxTimePossible + ".";

        public static string messageErrorCreateProgramCharacter => "Erro ao criar programa. Caractere de aquecimento não pode ser vazio";

        public static string messageErrorCreateProgramDuplicate => "Erro ao criar programa. Outro programa com o mesmo nome já existe.";

        public static string messageErrorCreateProgramInstrucion => "Erro ao criar programa. Instrução não pode ser vazia";

        public static string messageSuccesCreateProgram => "Programa criado com sucesso";




    }
}
