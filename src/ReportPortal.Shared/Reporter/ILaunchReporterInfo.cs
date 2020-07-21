using System;

namespace ReportPortal.Shared.Reporter
{
    public interface ILaunchReporterInfo
    {
        string Uuid { get; }

        string Name { get; }

        DateTime StartTime { get; }

        DateTime? FinishTime { get; }
    }
}
