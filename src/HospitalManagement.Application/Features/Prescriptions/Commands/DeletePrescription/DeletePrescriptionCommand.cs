using MediatR;

namespace HospitalManagement.Application.Features.Prescriptions.Commands.DeletePrescription;

public record DeletePrescriptionCommand(Guid Id) : IRequest;