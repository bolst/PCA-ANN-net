using RehseBlazor.Api;
using RehseBlazor.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
    
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<OptionProfile>(s =>
{
    var instance = OptionProfile.Instance();
    return instance;
});
builder.Services.AddSingleton(s =>
{
    var instance = ThemeService.Instance();
    return instance;
});
builder.Services.AddSingleton(s =>
{
    var instance = StateService.Instance();
    return instance;
});
builder.Services.AddSingleton(s =>
{
    var instance = OptionProfileController.Instance();
    return instance;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
