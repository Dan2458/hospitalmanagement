using MediatR;

namespace HospitalManagement.Application.Features.Patients.Commands.DeletePatient;

public record DeletePatientCommand(Guid Id) : IRequest<bool>;