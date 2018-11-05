using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.UnitTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IdeaGoal.Domain.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DbHelper.Execute();
        }
    }
}
