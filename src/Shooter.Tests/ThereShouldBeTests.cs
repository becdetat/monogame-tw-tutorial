using Shouldly;
using Xunit;

namespace Shooter.Tests
{
    public class ThereShouldBeTests
    {
        [Fact]
        public void BecauseTestsAreFun()
        {
            "So here are some tests".ShouldNotBeEmpty();
        }
    }
}