using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearchAndReplace
{
    /// <summary>
    /// Find and replace string in every TXT files in a directory 
    /// Github: PaulMCheng
    /// @2019
    /// </summary>
    public class SearchReplace
    {
        /// --------------------------------------------------------------------------------
        /// Initialise
        /// --------------------------------------------------------------------------------
        private string _replaceFrom; // = "Hello";
        private string _replaceTo; // = "Bye";
        private string _folderPath; // = @"C:\Test\";
        private string _searchPattern; // = "*.csv";


        /// --------------------------------------------------------------------------------
        /// Public methods 
        /// --------------------------------------------------------------------------------
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchReplace"/> class.
        /// </summary>
        /// <param name="replaceFrom">The replace from.</param>
        /// <param name="replaceTo">The replace to.</param>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="searchPattern">The search pattern. eg *.csv </param>
        public SearchReplace(string replaceFrom, string replaceTo, string folderPath, string searchPattern)
        {
            _replaceFrom = replaceFrom;
            _replaceTo = replaceTo;
            _folderPath = folderPath;
            _searchPattern = searchPattern;
        }

        /// <summary>
        /// Runs the find and search
        /// </summary>
        public void Run()
        {
            //Get all files including sub folder
            IEnumerable<string> subDirectory = Directory.EnumerateFiles(_folderPath, _searchPattern, SearchOption.AllDirectories);

            //For each filePath find and replace string 
            foreach (string filePath in subDirectory)
            {
                Console.WriteLine("Process file: " + filePath);

                List<string> sourceLines = ReadAllLines(filePath);
                List<string> newLines = ReplaceAllLines(sourceLines);

                //Save back to file
                if (!newLines.Equals(sourceLines))
                {
                    Console.WriteLine("Save file: " + filePath);
                    File.WriteAllLines(filePath, newLines);
                }
            }
        }

        /// <summary>
        /// Reads all lines.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        public List<string> ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        /// <summary>
        /// Find and replaces the lines.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <param name="txtLines">The text lines.</param>
        public List<string> ReplaceAllLines(List<string> sourceLines)
        {
            List<int> lineIndex = new List<int>();
            List<string> txtLines = new List<string>(sourceLines);
            int row = 0;

            //Search for each line in the filePath
            foreach (string txtLine in txtLines)
            {
                //next row
                row ++;

                //find matching string in the line 
                if (txtLine.Contains(_replaceFrom))
                {
                    lineIndex.Add(row);
                }
            }

            //Find and replace string
            foreach (var line in lineIndex)
            {
                txtLines[line - 1] = txtLines[line - 1].Replace(_replaceFrom, _replaceTo);
            }

            //return result
            return txtLines;

        }

    }
}
