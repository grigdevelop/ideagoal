using IdeaGoal.Domain.Core.Data;
using IdeaGoal.Domain.UnitTests.Core;
using IdeaGoal.Domain.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.UnitTests.Services
{
    [TestClass]
    public class ComponentServiceTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            DbHelper.CleanDb(GetService<IdeaGoalDbContext>());
        }

        [TestMethod]
        public void Should_Create_Component()
        {

        }
    }
}
