using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//=================================================================================================
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PatientsConnectionString")));
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

builder.Services.AddTransient<IAnswer, AnswerService>();
builder.Services.AddTransient<ICategory, CategoryServices>();
builder.Services.AddTransient<IQuestion, QuestionServices>();
builder.Services.AddTransient<IAdmin, AdminService>();
builder.Services.AddTransient<IProfile, ProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//=================================================================================================
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
