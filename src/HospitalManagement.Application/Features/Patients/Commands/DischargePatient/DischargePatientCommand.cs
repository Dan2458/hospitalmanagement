using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.DischargePatient;

public record DischargePatientCommand(Guid Id) : IRequest<bool>;