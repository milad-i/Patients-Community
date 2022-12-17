using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//=================================================================================================
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PatientsConnectionString")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

builder.Services.AddTransient<IAnswer, AnswerServices>();
builder.Services.AddTransient<ICategory, CategoryServices>();
builder.Services.AddTransient<IQuestion, QuestionServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//=================================================================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
