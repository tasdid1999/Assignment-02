using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS.Entity.Helper;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.ChildRepository.CourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherCourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherRepository;
using SMS.Infrastructure.UnitOfWork;
using SMS.Service.course;
using SMS.Service.student;
using SMS.Service.teacher;
using SMS.Service.teacherCourse;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//child Repository
builder.Services.AddScoped<IStudentRepository , StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();
//service
builder.Services.AddScoped<IStudentService , StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherCourseService, TeacherCourseService>();
//autoMapper
var automapper = new MapperConfiguration(item => item.AddProfile(new MapperHandler()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
