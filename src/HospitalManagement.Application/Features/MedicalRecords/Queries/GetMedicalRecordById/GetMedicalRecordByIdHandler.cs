using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetMedicalRecordById;

public record GetMedicalRecordByIdQuery(Guid Id)
    : IRequest<MedicalRecord?>;