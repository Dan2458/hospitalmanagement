using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Queries.GetPrescriptionById;

public record GetPrescriptionByIdQuery(Guid Id)
    : IRequest<Prescription?>;