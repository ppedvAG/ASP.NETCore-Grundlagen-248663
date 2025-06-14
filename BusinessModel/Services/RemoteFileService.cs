﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace BusinessModel.Services;

public class FileServiceOptions
{
    public string BaseUrl { get; set; }

    public string ApiKey { get; set; }
}

public class RemoteFileService : IFileService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RemoteFileService> _logger;

    public RemoteFileService(IOptions<FileServiceOptions> options, HttpClient httpClient, ILogger<RemoteFileService> logger)
    {
        if (string.IsNullOrEmpty(options.Value.BaseUrl) || string.IsNullOrEmpty(options.Value.ApiKey))
        {
            throw new ArgumentException("FileServiceOptions.BaseUrl und FileServiceOptions.ApiKey müssen gesetzt sein.");
        }

        _httpClient = httpClient;
        _logger = logger;
        _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("X-API-Key", options.Value.ApiKey);
    }

    public async Task<string?> UploadFile(string fileName, Stream stream, CancellationToken cancellationToken = default)
    {
        var content = new StreamContent(stream);
        content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);

        using var formContent = new MultipartFormDataContent();
        formContent.Add(content, "file", fileName);

        try
        {
            var response = await _httpClient.PostAsync("upload", formContent, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Fehler beim Hochladen der Datei: {response.StatusCode}");
            }

            var url = await response.Content.ReadAsStringAsync();
            return url;
        }
        catch (TaskCanceledException ex)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Timeout beim Hochladen der Datei {FileName}", fileName);
            }
            else
            {
                _logger.LogError(ex, "Hochladen der Datei {FileName} abgebrochen", fileName);
            }
            return null;
        }
    }
}
