using HospitalManagement.Application.DTOs.Dashboard;

namespace HospitalManagement.Application.Interfaces.Repositories;

public interface IDashboardRepository
{
    Task<DashboardStatisticsDto> GetStatisticsAsync(CancellationToken cancellationToken);
}