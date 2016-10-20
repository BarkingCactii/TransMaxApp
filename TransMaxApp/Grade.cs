using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TransMaxApp {
    // a Grade is a set of scores for individuals,
    // It stores all the personal results for grading
    class Grade {
        String InputFile { get; set; }
        public String OutputFile { get; set; }
        List<Result> _results;
        public List<Result> Results { get { return _results; } }

        // private constructor
        private Grade(String inputFile) {
            InputFile = inputFile;
            _results = new List<Result>();
            int idx = InputFile.LastIndexOf('.');
            OutputFile = InputFile.Substring(0, idx == -1 ? InputFile.Length : idx) + "-graded.txt";
            if (!File.Exists(inputFile))
                throw new Exception(String.Format("File {0} doesn't exist", inputFile));

            if (!Read()) {
                throw new Exception("Failed to read input file");
            }
        }

        // construct objects through CreateInstance
        public static Grade CreateInstance(String inputFile) {
            try {
                Grade grade = new TransMaxApp.Grade(inputFile);
                return grade;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // read input file, put results into _results
        private bool Read() {
            try {
                using (StreamReader file = new StreamReader(InputFile)) {
                    String line;
                    while ((line = file.ReadLine()) != null) {
                        Result result = Result.CreateInstance(line);
                        if (result == null) {
                            file.Close();
                            return false;
                        }

                        _results.Add(result);
                    }
                }
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        // score sorter
        public void StartGrading() {
            _results = _results.OrderByDescending(x => x.Score).ThenBy( x => x.LastName ).ThenBy( x => x.FirstName).ToList();
        }

        // override ToString()
        public override String ToString() {
            string resultStr = "";
            _results.ForEach(x => {
                resultStr += x.ToString();
            });
            return resultStr;
        }

        // write results to a text file
        public void Save() {
            using ( StreamWriter writer = new StreamWriter(OutputFile)) {
                foreach ( Result result in _results) {
                    writer.WriteLine(result.ToString());
                }
            }
        }
    }
}
