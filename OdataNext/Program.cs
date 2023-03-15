using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using OdataNext.Data;
using OdataNext.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Order>();
modelBuilder.EntitySet<Customer>("Customers");


builder.Services.AddControllers().AddOData(

    options => options.Select().Filter().OrderBy().Expand().Count().Expand().Count().SetMaxTop(null).AddRouteComponents(
        routePrefix: "odata",
        modelBuilder.GetEdmModel()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OdataDbContextcs>(
  options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("DbConn")
  )
);

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
