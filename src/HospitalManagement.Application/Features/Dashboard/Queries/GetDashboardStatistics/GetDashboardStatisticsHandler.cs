using HospitalManagement.Application.DTOs.Dashboard;
using HospitalManagement.Application.Interfaces.Repositories;
using MediatR;

namespace HospitalManagement.Application.Features.Dashboard.Queries.GetDashboardStatistics;

public class GetDashboardStatisticsHandler
    : IRequestHandler<GetDashboardStatisticsQuery, DashboardStatisticsDto>
{
    private readonly IDashboardRepository _dashboardRepository;

    public GetDashboardStatisticsHandler(IDashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    public async Task<DashboardStatisticsDto> Handle(
        GetDashboardStatisticsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dashboardRepository.GetStatisticsAsync(cancellationToken);
    }
}