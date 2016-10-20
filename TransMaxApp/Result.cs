using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransMaxApp {
    // a Result is a record of a single line from
    // the input file. It is in effect, a Person & score record
    class Result {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Score { get; set; }

        // private constructor
        private Result(String line) {
            String[] fields = line.Split(',');

            if (fields.Length != 3) {
                throw new Exception("fields should total 3");
            }

            int tmp;
            if (int.TryParse(fields[2].Trim(), out tmp) == false) {
                throw new Exception("Invalid score");
            }

            LastName = fields[0].Trim();
            FirstName = fields[1].Trim();
            Score = tmp;
        }

        // construct objects through CreateInstance
        public static Result CreateInstance(String line) {
            try {
                Result result = new TransMaxApp.Result(line);
                return result;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        // override ToString()
        public override String ToString() {
            return String.Format("{0},{1},{2}{3}", LastName, FirstName, Score, Environment.NewLine);
        }
    }
}
