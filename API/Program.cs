var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<API.NoteService>();
var origins = "origins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: origins,
        builder =>
        {
            builder.WithOrigins("https://localhost:7002", "http://localhost:5124");
        });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(origins);

app.Run();