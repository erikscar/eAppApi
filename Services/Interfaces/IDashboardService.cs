using eApp.Models.DTOs;

namespace eApp.Services.Interfaces;

public interface IDashboardService
{
    public Task<ICollection<DashboardDTO>> GetLatestRecords();
}