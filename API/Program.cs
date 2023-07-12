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
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.UseCors(origins);

app.Run("http://0.0.0.0:5446");