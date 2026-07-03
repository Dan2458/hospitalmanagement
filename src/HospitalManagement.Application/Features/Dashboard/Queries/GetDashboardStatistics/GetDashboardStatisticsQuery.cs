using HospitalManagement.Application.DTOs.Dashboard;
using MediatR;

namespace HospitalManagement.Application.Features.Dashboard.Queries.GetDashboardStatistics;

public record GetDashboardStatisticsQuery()
    : IRequest<DashboardStatisticsDto>;