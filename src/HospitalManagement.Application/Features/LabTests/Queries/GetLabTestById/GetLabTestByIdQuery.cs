using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Queries.GetLabTestById;

public record GetLabTestByIdQuery(Guid Id)
    : IRequest<LabTest?>;