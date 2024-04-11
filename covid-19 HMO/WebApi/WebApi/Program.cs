using DataContext;
using Microsoft.OpenApi.Models;
using Repository.Interfaces;
using Service;

var builder = WebApplication.CreateBuilder(args);

//sealed= מחלקה חתומה שאי אפשר לרשת אותה
//UserSecretsConfigurationExtensions method-שיטות להרחבה
//ניתן להוסיף פונקציות למחלקה חתומה
//פונקציה סטטית 1
//במחלקה סטטית 2
//מצביע למחלקה 3

builder.Services.AddControllers();
builder.Services.AddService(); 
builder.Services.AddDbContext<IContext, Db>(); 



// הוספת הרשאת CRUD מהלקוח
var policy = "policy";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//הגדרת התלויות
// builder.services.
//services.AddScopes<IRepository<User>, UserRepository>();
// addScoped עבור כל גולש ייצור הזרקת תלות
//services.AddTransient עבור כל בקשה
//עבור כל הגולשים service.AddSingelton

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

