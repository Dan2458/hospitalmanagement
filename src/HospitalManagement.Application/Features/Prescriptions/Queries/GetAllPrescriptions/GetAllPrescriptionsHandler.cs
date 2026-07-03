using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Queries.GetAllPrescriptions;

public record GetAllPrescriptionsQuery()
    : IRequest<List<Prescription>>;