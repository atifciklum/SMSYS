using SMSYS.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Auto Mapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson(s => { 

    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

});


builder.Services.AddControllers();
builder.Services.AddScoped<IStudentRepo, SqlStudentRepo>();
builder.Services.AddDbContext<StudentContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SMSYSConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<ITeacherRepo, SqlTeacherRepo>();


builder.Services.AddControllers();
builder.Services.AddScoped<IResultRepo, SqlResultRepo>();


builder.Services.AddControllers();
builder.Services.AddScoped<IExamRepo, SqlExamRepo>();


builder.Services.AddControllers();
builder.Services.AddScoped<ISubjectRepo, SqlSubjectRepo>();

builder.Services.AddControllers();
builder.Services.AddScoped<IClassroomRepo, SqlClassroomRepo>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("8hu3ufM2PA5QAvlyDA2r7m2XDBQwa8Bs")),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
    };

});
builder.Services.AddMvc();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => 
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
