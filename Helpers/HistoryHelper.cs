using ContractMonthlyClaimSystem.Models;
using System;

namespace ContractMonthlyClaimSystem.Helpers
{
    public static class HistoryHelper
    {
        public static void AddHistory(ApplicationDbContext _context, int claimId, int updatedById, string oldStatus, string newStatus, string remarks = "")
        {
            var history = new ClaimHistory
            {
                ClaimId = claimId,
                UpdatedById = updatedById,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                Remarks = remarks,
                UpdatedAt = DateTime.Now
            };
            _context.ClaimHistories.Add(history);
            _context.SaveChanges();
        }
    }
}
