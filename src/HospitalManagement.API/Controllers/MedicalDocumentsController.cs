using HospitalManagement.Application.Features.MedicalDocuments.Commands.UploadMedicalDocument;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Application.Features.MedicalDocuments.Queries.GetPatientDocuments; 
using HospitalManagement.Application.Interfaces;
using Microsoft.AspNetCore.StaticFiles;
// 💡 Note: If your folder name uses a different structure, adjust the namespace to match where GetPatientDocumentsQuery lives!
namespace HospitalManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MedicalDocumentsController : ControllerBase
{ private readonly IMedicalDocumentRepository _repository;



public MedicalDocumentsController(

    IMediator mediator,

    IMedicalDocumentRepository repository)

{

    _mediator = mediator;

    _repository = repository;

}
    private readonly IMediator _mediator;

    public MedicalDocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(
        [FromForm] Guid patientId,
        IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(new
            {
                Message = "No file selected."
            });
        }

        await using var stream = file.OpenReadStream();

        var id = await _mediator.Send(
            new UploadMedicalDocumentCommand(
                patientId,
                stream,
                file.FileName,
                file.ContentType,
                file.Length));

        return Ok(new
        {
            Message = "Document uploaded successfully.",
            DocumentId = id
        });
    }
    [HttpGet("patient/{patientId:guid}")]
public async Task<IActionResult> GetPatientDocuments(Guid patientId)
{
    var documents = await _mediator.Send(
        new GetPatientDocumentsQuery(patientId));

    return Ok(documents);
}
[HttpGet("{id:guid}/download")]
public async Task<IActionResult> Download(Guid id)
{
    var document = await _repository.GetByIdAsync(id);

    if (document == null)
        return NotFound(new
        {
            Message = "Document not found."
        });

    var path = Path.Combine(
        Directory.GetCurrentDirectory(),
        "Uploads",
        document.FilePath);

    if (!System.IO.File.Exists(path))
        return NotFound(new
        {
            Message = "File does not exist."
        });

    var provider = new FileExtensionContentTypeProvider();

    if (!provider.TryGetContentType(path, out var contentType))
    {
        contentType = "application/octet-stream";
    }

    var bytes = await System.IO.File.ReadAllBytesAsync(path);

    return File(
        bytes,
        contentType,
        document.OriginalFileName);
}
[HttpDelete("{id:guid}")]
public async Task<IActionResult> Delete(Guid id)
{
    var document = await _repository.GetByIdAsync(id);

    if (document == null)
    {
        return NotFound(new
        {
            Message = "Document not found."
        });
    }

    var path = Path.Combine(
        Directory.GetCurrentDirectory(),
        "Uploads",
        document.FilePath);

    if (System.IO.File.Exists(path))
    {
        System.IO.File.Delete(path);
    }

    await _repository.DeleteAsync(document);

    await _repository.SaveChangesAsync();

    return NoContent();
}
}