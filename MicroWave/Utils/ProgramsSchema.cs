using System;

namespace MicroWave.Utils
{
    public class ProgramsSchema
    {
        private String name = "default";
        private int power = 8;
        private int time = 30;
        private char character = '.';
        private String instruction = "";

        public ProgramsSchema(String name, int power, int time, char character, String instruction)
        {
            this.name = name;
            this.power = power;
            this.time = time;
            this.character = character;
            this.instruction = instruction;
        }

        public ProgramsSchema()
        {
            this.name = "default";
            this.power = 8;
            this.time = 30;
            this.character = '.';
        }   
    
        public String getName()
        {
            return this.name;
        }

        public int getPower()
        {
            return this.power;
        }

        public int getTime()
        {
            return this.time;
        }

        public char getCharacter()
        {
            return this.character;
        }

        public String getInstruction()
        {
            return this.instruction;
        }

    }
}
