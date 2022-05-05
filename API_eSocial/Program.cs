using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using API_eSocial.Model;
using API_eSocial.Controllers;


namespace API_eSocial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static async Task RunAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:53557/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/produtos/3");
                if (response.IsSuccessStatusCode)
                {  //GET
                    X509Certificate2 certificate2 = await response.Content.ReadAsAsync<X509Certificate2>();
                    Console.WriteLine("{0}\tR${1}\t{2}", certificate2);
                    Console.WriteLine("Produto acessado e exibido.  Tecle algo para incluir um novo produto.");
                    Console.ReadKey();
                }
                ////POST
                //var cha = new Produto() { Nome = "Chá Verde", Preco = 1.50M, Categoria = "Bebidas" };
                //response = await client.PostAsJsonAsync("api/produtos", cha);
                //Console.WriteLine("Produto cha verde incluído. Tecle algo para atualizar o preço do produto.");
                //Console.ReadKey();

                if (response.IsSuccessStatusCode)
                {   //PUT
                    Uri Url = response.Headers.Location;
                    //cha.Preco = 2.55M;   // atualiza o preco do produto
                    response = await client.;
                    Console.WriteLine("resposta" + response.ToString()) ;
                    Console.ReadKey();
                    //DELETE
                    response = await client.DeleteAsync(Url);
                    Console.WriteLine("Produto deletado");
                    Console.ReadKey();
                }
            }
        }

    }
}
