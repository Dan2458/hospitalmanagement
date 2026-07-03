using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Commands.CreateLabTest;

public class CreateLabTestHandler : IRequestHandler<CreateLabTestCommand, Guid>
{
    private readonly ILabTestRepository _labRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateLabTestHandler(
        ILabTestRepository labRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IAppointmentRepository appointmentRepository)
    {
        _labRepository = labRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Guid> Handle(CreateLabTestCommand request, CancellationToken cancellationToken)
    {
        if (await _patientRepository.GetByIdAsync(request.PatientId) is null)
            throw new Exception("Patient not found.");

        if (await _doctorRepository.GetByIdAsync(request.DoctorId) is null)
            throw new Exception("Doctor not found.");

        if (await _appointmentRepository.GetByIdAsync(request.AppointmentId) is null)
            throw new Exception("Appointment not found.");

        var labTest = new LabTest(
            request.PatientId,
            request.DoctorId,
            request.AppointmentId,
            request.TestName);

        await _labRepository.AddAsync(labTest);

        return labTest.Id;
    }
}