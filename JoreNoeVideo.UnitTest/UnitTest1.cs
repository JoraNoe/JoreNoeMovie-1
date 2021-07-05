using Microsoft.VisualStudio.TestTools.UnitTesting;
using JoreNoeVideo.Cache;
namespace JoreNoeVideo.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //≤‚ ‘
            var x = new RedisCache();
            var databse = x.GetDatabase();
            databse.StringSet("x","sdf");
        }
    }
}
