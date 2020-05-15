using System; 

namespace MicroWave.Utils
{
    public static class Constants
    {
        public static string messageErrorSetFood => "Não foi possivel adicionar o alimento no micro-ondas";
        public static string messageSuccessSetFood(String value) => value + " foi adicionado ao micro-ondas";

        public static string messageErrorSetPower => "Valor de potencia invalido. Deve ser um valor entre 1 e 10.";
        public static string messageSuccessSetPower(int value) => "A potencia foi definida para " + value.ToString() + ".";

        public static string messageErrorSetTime => "Valor de tempo inválido. Deve ser um valor entre 1 e 120.";
        public static string messageSuccessSetTime(int value) => "O tempo foi definido para " + value.ToString() + " segundos.";

        public static string messageErrorHeatingTime => "Erro ao aquecer. Tempo deve estar entre 1 e 120.";

        public static string messageErrorHeatingPower => "Erro ao aquecer. Potencia deve estar entre 1 e 10.";

        public static string messageErrorGetProgram => "Alimento incompatível com o programa.";

    }
}
