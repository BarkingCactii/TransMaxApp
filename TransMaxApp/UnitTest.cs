using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransMaxApp {
    [TestClass]
    public class UnitTest {
        [TestMethod]
        public void BasicCheck() {
            string inputFile = "BasicCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 88",
                "SMITH, ALLAN, 70",
                "KING, MADISON, 88",
                "SMITH, FRANCIS, 85"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "BUNDY,TERESSA,88",
                "KING,MADISON,88",
                "SMITH,FRANCIS,85",
                "SMITH,ALLAN,70"
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine, 
                grade.ToString()
            );
        }

        [TestMethod]
        public void LastNameCheck() {
            string inputFile = "LastNameCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 88",
                "ALLAN, ALLAN, 88",
                "KING, MADISON, 88",
                "SMITH, FRANCIS, 88"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "ALLAN,ALLAN,88",
                "BUNDY,TERESSA,88",
                "KING,MADISON,88",
                "SMITH,FRANCIS,88"
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine,
                grade.ToString()
            );
        }


        [TestMethod]
        public void ScoreCheck() {
            string inputFile = "ScoreCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 85",
                "BUNDY, ALLAN, 86",
                "BUNDY, MADISON, 87",
                "BUNDY, FRANCIS, 88"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "BUNDY,FRANCIS,88",
                "BUNDY,MADISON,87",
                "BUNDY,ALLAN,86",
                "BUNDY,TERESSA,85"
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine,
                grade.ToString()
            );
        }

        [TestMethod]
        public void FirstNameCheck() {
            string inputFile = "FirstNameCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 88",
                "BUNDY, ALLAN, 88",
                "BUNDY, MADISON, 88",
                "BUNDY, FRANCIS, 88"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "BUNDY,ALLAN,88",
                "BUNDY,FRANCIS,88",
                "BUNDY,MADISON,88",
                "BUNDY,TERESSA,88"
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine,
                grade.ToString()
            );
        }

        [TestMethod]
        public void SingleEntry() {
            string inputFile = "SingleEntry.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 88",
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "BUNDY,TERESSA,88",
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine,
                grade.ToString()
            );
        }

        [TestMethod]
        public void BigListCheck() {
            string inputFile = "BigListCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA, 88",
                "BUNDY, ALLAN, 87",
                "BUNDY, MADISON, 86",
                "BUNDY, FRANCIS, 85",
                "SMITH, TERESSA, 86",
                "SMITH, ALLAN, 87",
                "SMITH, MADISON, 88",
                "SMITH, FRANCIS, 87",
                "KING, TERESSA, 86",
                "KING, ALLAN, 85",
                "KING, MADISON, 86",
                "KING, FRANCIS, 87"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            grade.StartGrading();
            grade.Save();

            String[] outputData = {
                "BUNDY,TERESSA,88",
                "SMITH,MADISON,88",
                "BUNDY,ALLAN,87",
                "KING,FRANCIS,87",
                "SMITH,ALLAN,87",
                "SMITH,FRANCIS,87",
                "BUNDY,MADISON,86",
                "KING,MADISON,86",
                "KING,TERESSA,86",
                "SMITH,TERESSA,86",
                "BUNDY,FRANCIS,85",
                "KING,ALLAN,85"
            };

            Assert.AreEqual(
                string.Join(Environment.NewLine, outputData.Select(x => x.ToString())) + Environment.NewLine,
                grade.ToString()
            );
        }

        [TestMethod]
        public void FileNameCheck() {
            string inputFile = "FileNameCheck.txt";
            string outputFile = "FileNameCheck-graded.txt";

            String[] inputData = {
                "a,a,1"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);
            Assert.AreEqual(grade.OutputFile, outputFile);
        }

        [TestMethod]
        public void BadDataCheck() {
            string inputFile = "BadDataCheck.txt";

            String[] inputData = {
                "BUNDY, TERESSA,",
                "SMITH, ALLAN, 70, 70",
                "SMITH, ALLAN, 70, 70"
            };
            CreateFile(inputFile, inputData);

            Grade grade = Grade.CreateInstance(inputFile);

            //int count = grade.Results.Count;

            Assert.IsNull(grade);
        }

        #region Helpers

        void CreateFile(String fileName, String [] data ) {
            using (StreamWriter writer = new StreamWriter(fileName)) {
                foreach ( String line in data ) {
                    writer.WriteLine(line);
                }
            }
        }

        #endregion
    }
}
