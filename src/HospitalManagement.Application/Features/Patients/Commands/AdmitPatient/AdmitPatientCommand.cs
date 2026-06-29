using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.AdmitPatient;

public record AdmitPatientCommand(Guid Id) : IRequest<bool>;