using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetAllMedicalRecords;

public record GetAllMedicalRecordsQuery()
    : IRequest<List<MedicalRecord>>;