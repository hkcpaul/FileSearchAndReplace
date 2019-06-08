using System.Collections.Generic;

namespace FileSearchAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            string replaceFrom = "Hello";
            string replaceTo = "Bye";
            string folderPath = @"C:\Test\";
            string searchPattern = "*.csv";
            List<string> sourceLines = new List<string>();

            SearchReplace sr = new SearchReplace(replaceFrom, replaceTo, folderPath, searchPattern);
            sr.Run();

        }
    }
}
