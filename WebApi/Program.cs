using Microsoft.EntityFrameworkCore;
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
builder.Services.AddDbContext<storeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(@"Data Source=DESKTOP-4G5A9E;Initial Catalog=storeDB;Integrated Security=True;Trust Server Certificate=True")),ServiceLifetime.Transient);

var app = builder.Build();  

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
