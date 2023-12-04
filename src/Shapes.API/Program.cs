var builder = WebApplication.CreateBuilder(args);

IApplicationConfigurator startup = new Startup()
{
    UseSwagger = true//builder.Environment.IsDevelopment()
};

startup.Configure(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

startup.Setup(app);

app.MapControllers();

app.Run();
