using HospitalManagement.Domain.Entities;
using MediatR;

namespace HospitalManagement.Application.Features.LabTests.Queries.GetAllLabTests;

public record GetAllLabTestsQuery() : IRequest<List<LabTest>>;