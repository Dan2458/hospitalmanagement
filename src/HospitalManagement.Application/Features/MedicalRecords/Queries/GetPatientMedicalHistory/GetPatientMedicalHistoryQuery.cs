using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.MedicalRecords.Queries.GetPatientMedicalHistory;

public record GetPatientMedicalHistoryQuery(Guid PatientId)
    : IRequest<List<MedicalRecord>>;