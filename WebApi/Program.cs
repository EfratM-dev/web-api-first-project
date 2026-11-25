using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IPasswordService, PasswordService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddOpenApi();
builder.Host.UseNLog();
builder.Services.AddDbContext<storeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnectionString")),ServiceLifetime.Transient);

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsEnvironment("School")|| app.Environment.IsEnvironment("Home"))
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.UseHttpsRedirection();


app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
