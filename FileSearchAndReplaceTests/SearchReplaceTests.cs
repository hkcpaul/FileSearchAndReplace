using System.Collections.Generic;
using System.Linq;
using FileSearchAndReplace;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
    public class SearchReplaceTests
    {

        [Test]
        public void ReplaceTest()
        {
            List<string> sourceLines = new List<string>();
            sourceLines.Add("1, Try to say Hello");

            SearchReplace sr = new SearchReplace("Hello", "Bye", null, null);
            List<string> newLines = sr.ReplaceAllLines(sourceLines);

            newLines.FirstOrDefault().ShouldBe("1, Try to say Bye");

        }

        [Test]
        public void NothingToReplaceTest()
        {
            List<string> sourceLines = new List<string>();
            sourceLines.Add("1, Try to say Hi");

            SearchReplace sr = new SearchReplace("Hello", "Bye", null, null);
            List<string> newLines = sr.ReplaceAllLines(sourceLines);

            newLines.FirstOrDefault().ShouldBe("1, Try to say Hi");
        }
    }
}