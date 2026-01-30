var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddScoped<api.Service.Todo.ITodoService, api.Service.Todo.TodoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

