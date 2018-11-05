using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaGoal.Domain.UnitTests.Core
{
    public abstract class TestBase
    {
        private ServiceCollection _serviceCollection = new ServiceCollection();

        public TestBase()
        {
            
        }
    }
}
