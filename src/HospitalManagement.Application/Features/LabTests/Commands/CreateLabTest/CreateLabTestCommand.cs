using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.CreateLabTest;

public record CreateLabTestCommand(
    Guid PatientId,
    Guid DoctorId,
    Guid AppointmentId,
    string TestName
) : IRequest<Guid>;