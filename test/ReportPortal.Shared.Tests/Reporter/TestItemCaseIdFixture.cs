using FluentAssertions;
using ReportPortal.Shared.Extensibility;
using ReportPortal.Shared.Reporter;
using ReportPortal.Shared.Tests.Helpers;
using Xunit;

namespace ReportPortal.Shared.Tests.Reporter
{
    public class TestItemCaseIdFixture
    {
        [Fact]
        public void ShouldGenerateSameTestCaseIdIfProvided()
        {
            var testCaseId = "123";

            var service = new MockServiceBuilder().Build();

            var launch = new LaunchReporter(service.Object, null, null, new ExtensionManager());
            launch.Start(new Client.Abstractions.Requests.StartLaunchRequest
            {

            });

            var test = launch.StartChildTestReporter(new Client.Abstractions.Requests.StartTestItemRequest
            {
                TestCaseId = testCaseId
            });

            var test2 = launch.StartChildTestReporter(new Client.Abstractions.Requests.StartTestItemRequest
            {
                TestCaseId = testCaseId
            });

            test.Sync();
            test2.Sync();

            test.Info.TestCaseId.Should().Be(test2.Info.TestCaseId);
        }
    }
}
