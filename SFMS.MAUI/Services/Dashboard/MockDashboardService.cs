using SFMS.MAUI.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Services.Dashboard
{
    public sealed class MockDashboardService : IDashboardService
    {
        private readonly Random _random = new();

        private int _machineJobsToday = 3;
        private int _machineJobsThisWeek = 34;
        private int _sectionJobsToday = 12;
        private int _totalQuantity = 40_300;
        private int _generatedPallets = 21;
        private int _generatedChecklists = 12;

        public async Task<DashboardSummary> GetSummaryAsync(
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(
                200,
                cancellationToken);

            /*
             * Simulates small production changes.
             * This is development-only synthetic data.
             */
            _machineJobsToday += _random.Next(0, 2);
            _machineJobsThisWeek += _random.Next(0, 2);
            _sectionJobsToday += _random.Next(0, 2);

            _totalQuantity += _random.Next(50, 450);
            _generatedPallets += _random.Next(0, 2);
            _generatedChecklists += _random.Next(0, 2);

            return new DashboardSummary(
                TotalQtyProcessedToday: _totalQuantity,
                ProcessJobByMachineToday: _machineJobsToday,
                ProcessJobByMachineThisWeek: _machineJobsThisWeek,
                ProcessJobBySectionToday: _sectionJobsToday,
                GeneratedPalletsToday: _generatedPallets,
                GeneratedChecklistToday:
                    _generatedChecklists);
        }

        public async Task<IReadOnlyList<ProcessOutput>>
            GetProcessOutputsAsync(
                CancellationToken cancellationToken = default)
        {
            await Task.Delay(
                150,
                cancellationToken);

            return
            [
                new(
                ProcessName: "DIE CUTTING",
                PalletCount: 18 + _random.Next(0, 3),
                Percentage: 0.90),

            new(
                ProcessName: "OFFSET",
                PalletCount: 15 + _random.Next(0, 3),
                Percentage: 0.75),

            new(
                ProcessName: "COATING",
                PalletCount: 11 + _random.Next(0, 2),
                Percentage: 0.55),

            new(
                ProcessName: "LAMINATION",
                PalletCount: 8 + _random.Next(0, 2),
                Percentage: 0.40),

            new(
                ProcessName: "GLUING",
                PalletCount: 6 + _random.Next(0, 2),
                Percentage: 0.30)
            ];
        }

        public async Task<IReadOnlyList<RecentPallet>>
            GetRecentPalletsAsync(
                CancellationToken cancellationToken = default)
        {
            await Task.Delay(
                180,
                cancellationToken);

            var now = DateTimeOffset.Now;

            return
            [
                new(
                Machine: "P-DIE-STAMP-A",
                JobNumber: "P2609D2870",
                Suffix: "1",
                OperationNumber: "20",
                JobName:
                    "44513894 - CARTON BOARD NESTOGEN 1-3",
                Quantity: 500m,
                Status: "Pending",
                CreatedAt: now.AddMinutes(-2)),

            new(
                Machine: "P-DIE-STAMP-A",
                JobNumber: "P2609D2850",
                Suffix: "1",
                OperationNumber: "20",
                JobName:
                    "44513892 - CARTON BOARD NESTOGEN 0-6",
                Quantity: 1_000m,
                Status: "Pending",
                CreatedAt: now.AddMinutes(-7)),

            new(
                Machine: "P-DATIEN-115-B",
                JobNumber: "P2610F0060",
                Suffix: "9",
                OperationNumber: "10",
                JobName:
                    "FUJI IND.BOX (LAGOON GREEN) BO-48 WWD",
                Quantity: 37_300m,
                Status: "Pending",
                CreatedAt: now.AddMinutes(-12)),

            new(
                Machine: "P-DIE-STAMP-A",
                JobNumber: "P2609D2860",
                Suffix: "1",
                OperationNumber: "20",
                JobName:
                    "44513893 - CARTON BOARD NESTOGEN 6-12",
                Quantity: 500m,
                Status: "Pending",
                CreatedAt: now.AddMinutes(-18)),

            new(
                Machine: "P-DIE-STAMP-A",
                JobNumber: "P2609D2890",
                Suffix: "1",
                OperationNumber: "20",
                JobName:
                    "44513895 - CARTON BOARD NESTOGEN KID 3+",
                Quantity: 500m,
                Status: "Pending",
                CreatedAt: now.AddMinutes(-24))
            ];
        }
    }
}
