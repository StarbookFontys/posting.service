using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
			   builder.AllowAnyOrigin()
					 .AllowAnyMethod()
					 .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMetricServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
		   .AllowAnyMethod()
		   .AllowAnyHeader()
		   .AllowAnyOrigin()
		   .SetIsOriginAllowed(origin => true));

app.Run(url);
