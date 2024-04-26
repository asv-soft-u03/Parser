using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Text;
using System.Threading;
using Avalonia.Controls.Documents;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SuperParser.ViewModels;

public class ParseOutputViewModel : ViewModelBase
{
    
    private string _request { get; set; }
    List<string> locarr = new()   /// точки которые собираемся отправлять lat,lon 
    {
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
        "-43.5,172.5", "27.6,1.98",
    };
    
    public ParseOutputViewModel()
    {
        ProgressValue = 0;
        StartParse = ReactiveCommand.Create(GoParse);
    }
    static HttpClient httpClient = new();
    public async void GoParse()
    {
        ProgressValue = 0;

        StringBuilder locations = new StringBuilder();
        foreach (var item in locarr)
        {
            locations.Append($"{item}|");
        }

        ProgressValue = 20;
        locations.Remove(locations.Length - 1, 1);
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            $"http://api.opentopodata.org/v1/srtm90m?locations={locations}&interpolation=cubic");
        using HttpResponseMessage response = await httpClient.SendAsync(request);
        foreach (var header in response.Headers)
        {
            Response += $"{header.Key} = {header.Value}\n";
            ProgressValue += 10;
        }

        string content = await response.Content.ReadAsStringAsync();
        ProgressValue = 90;

        Response += $"\n content = {content}";
        ProgressValue = 100;
    }
    [Reactive] public int ProgressValue { get; set; }
    [Reactive] public string Response { get; set; }
    public ReactiveCommand<Unit, Unit> StartParse { get; set; }
}