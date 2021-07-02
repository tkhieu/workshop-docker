using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapGet("/cal", async http =>
{
    http.Request.Query.TryGetValue("num1", out var num1String);
    http.Request.Query.TryGetValue("num2", out var num2String);

    var num1 = int.Parse(num1String[0]);
    var num2 = int.Parse(num2String[0]);


    var totalResult = num1 + num2;
    var subtractResult = num1 - num2;
    var multipleResult = num1 * num2;
    var dividedResult = num1 / num2;

    var returnObj = new
    {
        add = totalResult,
        subtract = subtractResult,
        multiple = multipleResult,
        divided = dividedResult
    };

    await http.Response.WriteAsJsonAsync(returnObj);

});

app.Run();
