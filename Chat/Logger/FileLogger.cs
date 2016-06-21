
using System.IO;

namespace Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _pathToFile;

        public FileLogger(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void Logging(string data)
        {
            using (var sw = new StreamWriter(_pathToFile, true))
            {
                sw.WriteLine(data);
                sw.Close();
            }
        }
    }
}
