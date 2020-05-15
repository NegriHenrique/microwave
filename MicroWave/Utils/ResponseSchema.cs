using System;

namespace MicroWave
{
    public class ResponseSchema
    {
        private bool error = false;
        private String message = "";

        public ResponseSchema(bool err, String message) 
        {
            this.error = err;
            this.message = message;
        }


        public bool getError()
        {
            return this.error;
        }

        public String getMessage()
        {
            return this.message;
        }
    }
}
