
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TextCutter.Model
{
    class FileTextCutter : ITextCutter
    {
        private string _inputFilePath;
        private string _outputFilePath;
        private int _minWordSize;
        private bool _isRemovePunctuationMarks;

        public FileTextCutter (string inputFilePath, string outputFilePath, int minWordSize, bool isRemovePunctuationMArks)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
            _minWordSize = minWordSize;
            _isRemovePunctuationMarks = isRemovePunctuationMArks;
        }

        public TextCutterResult Cut()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(_inputFilePath))
                {
                    string inputLine;
                    using (StreamWriter streamWriner = new StreamWriter(_outputFilePath))
                    {
                        while ((inputLine = streamReader.ReadLine()) != null)
                        {
                            if (_isRemovePunctuationMarks)
                            {
                                inputLine = Regex.Replace(inputLine, "[-,.?!)(;:]", "");
                            }
                            string[] inputWords = inputLine.Split(new char[] { ' ' });

                            StringBuilder stringBuilder = new StringBuilder();
                            string tmpWord;
                            char[] charsToTrim = { '-', ',', '.', '?', '!', ')', '(', ':' };

                            foreach (var word in inputWords)
                            {
                                tmpWord = word.Trim(charsToTrim);

                                if(tmpWord.Length >= _minWordSize)
                                {
                                    stringBuilder.Append(word)
                                        .Append(" ");
                                }
                            }
                            streamWriner.WriteLine(stringBuilder.ToString());
                        }
                    }
                }
                return TextCutterResult.Ok;
            }
            catch
            {
                return TextCutterResult.Error;
            }
        }
    }
}
