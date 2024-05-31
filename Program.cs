using Projeto_Web_Lh_Pets_versão_1;

namespace WEB_LH_PETS;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "WEB-LH PETS");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext contexto)=> {
                contexto.Response.Redirect("index.html", false);
        });

        Banco dba=new Banco();
        app.MapGet("/listaClientes", (HttpContent contexto) =>{
                contexto.Response.WriteAsync( dba.GetListaString());
        });

        app.Run();
    }
}
