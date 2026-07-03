using MediatR;

namespace HospitalManagement.Application.Features.Dashboard.Queries.GetDashboard;

public record GetDashboardQuery()
    : IRequest<DashboardDto>;