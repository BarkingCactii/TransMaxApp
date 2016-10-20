using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TransMaxApp {
    class Program {
        static void Main(string[] args) {
            try {
                if (args.Length < 1)
                    throw new Exception("No input file defined");

                // create an instance of grade, it will return a non null 
                // value if the file name exists, and data is valid
                Grade grade = Grade.CreateInstance(args[0]);
                if (grade == null)
                    throw new Exception("Failed to create Grade class");

                grade.StartGrading();
                Console.Write(grade.ToString());
                grade.Save();

                Console.WriteLine("Finished: created " + grade.OutputFile);
            }
            catch ( Exception ex ) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
