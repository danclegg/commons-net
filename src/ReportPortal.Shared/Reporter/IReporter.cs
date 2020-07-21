﻿using System.Threading.Tasks;

namespace ReportPortal.Shared.Reporter
{
    public interface IReporter
    {
        Task StartTask { get; }

        Task FinishTask { get; }
    }
}
