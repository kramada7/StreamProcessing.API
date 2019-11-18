using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamProcessing.Services;
using System.Collections.Generic;

namespace StreamProcessing.Test
{
    [TestClass]
    public class StreamServiceTest
    {
        private IStreamService _streamService;
        private List<string> _listFakeString;

        [TestInitialize]
        public void Initialize()
        {
            _streamService = new StreamService();
            _listFakeString = new List<string>
            {
                "{}",
                "{{{}}}",
                "{{},{}}",
                "{{{},{},{{}}}}",
                "{<a>,<a>,<a>,<a>}",
                "{{<ab>},{<ab>},{<ab>},{<ab>}}",
                "{{<!!>},{<!!>},{<!!>},{<!!>}}",
                "{{<a!>},{<a!>},{<a!>},{<ab>}}",
            };
        }

        [TestMethod]
        public void TestStreamServiceFromFakeStream()
        {
            for (int i = 0; i < _listFakeString.Count; i++)
            {
                int score = _streamService.CalculateScore(_listFakeString[i]);
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(1, score);
                        break;
                    case 1:
                        Assert.AreEqual(6, score);
                        break;
                    case 2:
                        Assert.AreEqual(5, score);
                        break;
                    case 3:
                        Assert.AreEqual(16, score);
                        break;
                    case 4:
                        Assert.AreEqual(1, score);
                        break;
                    case 5:
                        Assert.AreEqual(9, score);
                        break;
                    case 6:
                        Assert.AreEqual(9, score);
                        break;
                    case 7:
                        Assert.AreEqual(3, score);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
