using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ShooterGame.Tests
{
    public class ThereShouldBeTests
    {
        [Fact]
        public void BecauseTestsAreFun()
        {
            "So here's some tests!".ShouldNotBeEmpty();
        }
    }
}
