using web_api;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Logging.AddJsonConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
  options.InjectStylesheet("style.css");
});

app.UseHttpsRedirection();
app.MapGroup("/api")
   .UseApplicationRouting(builder.Services);

app.Run();
