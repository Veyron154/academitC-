﻿using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TextCutter.Model
{
    class FileTextCutter : ITextCutter
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;
        private readonly int _minWordSize;
        private readonly bool _isRemovePunctuationMarks;
        private static readonly char[] charsToTrim = { '-', ',', '.', '?', '!', ')', '(', ':' };

        public FileTextCutter (string inputFilePath, string outputFilePath, int minWordSize, bool isRemovePunctuationMarks)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
            _minWordSize = minWordSize;
            _isRemovePunctuationMarks = isRemovePunctuationMarks;
        }

        public TextCutterResult Cut()
        {
            try
            {
                using (var streamReader = new StreamReader(_inputFilePath, Encoding.Default))
                {
                    using (var streamWriner = new StreamWriter(_outputFilePath))
                    {
                        string inputLine;
                        while ((inputLine = streamReader.ReadLine()) != null)
                        {
                            if (_isRemovePunctuationMarks)
                            {
                                inputLine = Regex.Replace(inputLine, "[-,.?!)(;:]", "");
                            }
                            var inputWords = inputLine.Split(new[] { ' ' });

                            var stringBuilder = new StringBuilder();

                            foreach (var word in inputWords)
                            {
                                var tmpWord = word.Trim(charsToTrim);

                                if (tmpWord.Length >= _minWordSize)
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
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                return TextCutterResult.Error;
            }
        }
    }
}
