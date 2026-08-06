// Em Program.cs (Versão Final e Corrigida)

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500") 
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); 
        });
});

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection(); // Ótima decisão deixar comentado para dev local

app.UseStaticFiles();

app.UseRouting();

// APLICANDO A REGRA DE CORS NO LUGAR CERTO
app.UseCors(MyAllowSpecificOrigins); 

app.UseAuthorization();

app.MapControllers(); 

app.Run();