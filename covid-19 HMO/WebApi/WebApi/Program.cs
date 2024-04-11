using DataContext;
using Microsoft.OpenApi.Models;
using Repository.Interfaces;
using Service;

var builder = WebApplication.CreateBuilder(args);

//sealed= ����� ����� ��� ���� ���� ����
//UserSecretsConfigurationExtensions method-����� ������
//���� ������ �������� ������ �����
//������� ����� 1
//������ ����� 2
//����� ������ 3

builder.Services.AddControllers();
builder.Services.AddService(); 
builder.Services.AddDbContext<IContext, Db>(); 



// ����� ����� CRUD ������
var policy = "policy";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//����� �������
// builder.services.
//services.AddScopes<IRepository<User>, UserRepository>();
// addScoped ���� �� ���� ����� ����� ����
//services.AddTransient ���� �� ����
//���� �� ������� service.AddSingelton

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(policy);

app.UseAuthorization();

app.MapControllers();

app.Run();

