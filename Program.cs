using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Classe criada para passar o path do arquivo
            FilesTarget filesTarget = new FilesTarget();

            string sourcePath = filesTarget.UpdateSourcePath();
            string targetPath = filesTarget.UpdateTargetPath();
            string[] lines = File.ReadAllLines(sourcePath);
           
            try
            {
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }

                using (StreamReader sr = File.OpenText(sourcePath))

                {
                    while (!sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }

            }
            catch (IOException error)
            {
                Console.WriteLine("An error occureed");
                Console.WriteLine(error.Message);
            }
        }
    }
}