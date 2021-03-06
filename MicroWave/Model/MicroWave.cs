﻿using System;
using System.Threading;
using MicroWave.Utils;

namespace MicroWave
{
    class MicroWave
    {
        private static MicroWave _instance;
        private String alimento = "";
        private int tempo = 1;
        private int potencia = 1;
        private bool ligado = false;
        private char caractere = '.';


        public static MicroWave getInstance()
        {
            if(_instance == null)
            {
                _instance = new MicroWave();
            }
            return _instance;
        }

        public String getAlimento()
        {
            return this.alimento;
        }

        public ResponseSchema setAlimento(String value)
        {
            if (value != this.alimento && value.Length > 0)
            {
                this.alimento = value;
                return new ResponseSchema(false, Constants.messageSuccessSetFood(value));
            }
            return new ResponseSchema(true, Constants.messageErrorSetFood);
        }

        public int getTempo()
        {
            return this.tempo;
        }

        public ResponseSchema setTempo(int value)
        {
            if (value >= Constants.minTimePossible && value <= Constants.maxTimePossible)
            {
                this.tempo = value;
                return new ResponseSchema(false, Constants.messageSuccessSetTime(value));
            }

            return new ResponseSchema(true, Constants.messageErrorSetTime);
        }

        public int getPotencia()
        {
            return this.potencia;
        }

        public ResponseSchema setPotencia(int value)
        {
            if(value >= Constants.minPowerPossible && value <= Constants.maxPowerPossible)
            {
                this.potencia = value;
                return new ResponseSchema(false, Constants.messageSuccessSetPower(value));
            }

            return new ResponseSchema(true, Constants.messageErrorSetPower);
        }

        public bool getLigado()
        {
            return this.ligado;
        }

        public String setLigado(bool value)
        {
            this.ligado = value;
            return value ? "O micro-ondas foi ligado." : "O micro-ondas foi desligado.";
        }

        public char getCaractere()
        {
            return this.caractere;
        }

        public ResponseSchema setCaractere(char value)
        {
            this.caractere = value;
            return new ResponseSchema(false, Constants.messageSuccessSetCharacter(value));
        }

        public void aquecerRapido()
        {
            Console.WriteLine(this.setTempo(30));
            Console.WriteLine(this.setPotencia(8));
            Console.WriteLine(this.aquecer());
        }

        public ResponseSchema aquecer ()
        {
            if (this.potencia <= 10 && this.potencia >= 1) 
            {
                if (this.tempo >= 1 && this.tempo <= 120)
                {
                        this.setLigado(true);
                        Thread.Sleep(this.tempo * 1000);
                        OnTimedEvent();
                        return new ResponseSchema(false, this.alimento);
                }
                return new ResponseSchema(true, Constants.messageErrorHeatingTime);
            }
            return new ResponseSchema(true, Constants.messageErrorHeatingPower);
        }

        private void OnTimedEvent()
        {
            String alimento = this.alimento;
            int pontos = this.getPotencia() * this.getTempo();

            for(int i = 0; i < pontos; i++)
            {
                alimento = alimento + this.caractere;
            }

            this.setAlimento(alimento);
        }

    }
}
