namespace VGR_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MemoryStream stream = new MemoryStream();

             
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<DTO>();
            
            // Add services to the container.
            builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod()
.AllowAnyHeader()));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}