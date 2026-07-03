using HospitalManagement.Application.Interfaces.FileStorage;

namespace HospitalManagement.Infrastructure.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _uploadFolder;

    public LocalFileStorageService()
    {
        _uploadFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Uploads");

        if (!Directory.Exists(_uploadFolder))
        {
            Directory.CreateDirectory(_uploadFolder);
        }
    }

    public async Task<string> UploadAsync(
        Stream stream,
        string fileName,
        string contentType)
    {
        var extension = Path.GetExtension(fileName);

        var newFileName = $"{Guid.NewGuid()}{extension}";

        var fullPath = Path.Combine(_uploadFolder, newFileName);

        using var fileStream = new FileStream(
            fullPath,
            FileMode.Create);

        await stream.CopyToAsync(fileStream);

        return newFileName;
    }

    public Task DeleteAsync(string filePath)
    {
        var fullPath = Path.Combine(
            _uploadFolder,
            filePath);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        return Task.CompletedTask;
    }
}