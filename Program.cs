using Dapper;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string conn = Environment.GetEnvironmentVariable("ConnectionStrings__AzureSql");

app.UseStaticFiles();

app.MapGet("/api/data", async (string? phanLoai) =>
{
    using var db = new SqlConnection(conn);
    var data = await db.QueryAsync("SELECT * FROM gc.vw_TonKhoGiayCuon_Chuahet");
    return Results.Ok(data);
});

app.Run();
