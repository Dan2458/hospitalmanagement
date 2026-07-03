namespace HospitalManagement.Application.Interfaces.FileStorage;

public interface IFileStorageService
{
    Task<string> UploadAsync(
        Stream stream,
        string fileName,
        string contentType);

    Task DeleteAsync(string filePath);
}