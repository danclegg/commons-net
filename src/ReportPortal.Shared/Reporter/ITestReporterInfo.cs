using System;

namespace ReportPortal.Shared.Reporter
{
    public interface ITestReporterInfo
    {
        string Uuid { get; }

        string Name { get; }

        DateTime StartTime { get; }

        DateTime? FinishTime { get; }

        string TestCaseId { get; set; }
    }
}
