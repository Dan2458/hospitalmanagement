namespace HospitalManagement.Domain.Entities;

public class MedicalDocument
{
    public Guid Id { get; private set; }

    public Guid PatientId { get; private set; }

    public string FileName { get; private set; } = string.Empty;

    public string OriginalFileName { get; private set; } = string.Empty;

    public string ContentType { get; private set; } = string.Empty;

    public long FileSize { get; private set; }

    public string FilePath { get; private set; } = string.Empty;

    public DateTime UploadedAt { get; private set; }

    public Patient Patient { get; private set; } = null!;

    private MedicalDocument()
    {
    }

    public MedicalDocument(
        Guid patientId,
        string fileName,
        string originalFileName,
        string contentType,
        long fileSize,
        string filePath)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        FileName = fileName;
        OriginalFileName = originalFileName;
        ContentType = contentType;
        FileSize = fileSize;
        FilePath = filePath;
        UploadedAt = DateTime.UtcNow;
    }
}