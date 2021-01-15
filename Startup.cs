using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Dynamic;



namespace NetCore
{
    public class Startup
    {
        
        EpicWallet ew;
        private readonly IHostApplicationLifetime _appLifetime;
        


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ew = new EpicWallet();
            
        }

        private void OnStarted()
        {
              //  _logger.LogInformation("OnStarted has been called.");
              //   Console.WriteLine("Start");  
                // Perform post-startup activities here
        }

        private void OnStopping()
        {
                //_logger.LogInformation("OnStopping has been called.");
                
                // Perform on-stopping activities here

                ew.Stopping();
              //  Console.WriteLine("All processes close");
        }

        private void OnStopped()
        {
                //_logger.LogInformation("OnStopped has been called.");

                // Perform post-stopped activities here
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        public void Configure(IApplicationBuilder app, IHostApplicationLifetime applicationLifetime) 
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            applicationLifetime.ApplicationStarted.Register(OnStarted);
            applicationLifetime.ApplicationStopping.Register(OnStopping);
            applicationLifetime.ApplicationStopped.Register(OnStopped); 

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
               // Console.WriteLine(context.Request.Path);
               // Console.WriteLine(context.Request.Path.ToString().IndexOf("/torepicnode"));
                if(context.Request.Path.ToString().IndexOf("/torepicnode")==0){
                    

                        var bodyStr = "";
                     //   Console.WriteLine("I am torepicnode path "+ context.Request.Path);
                     //   Console.WriteLine("I am torepicnode querystring "+ context.Request.QueryString);
                     //   Console.WriteLine("I am torepicnode http method" + context.Request.Method);
                        
                        string responsetorepicnode= "";

                        using (StreamReader reader 
                                  //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                            = new StreamReader(context.Request.Body, false))
                        {
                            bodyStr = await reader.ReadToEndAsync();

                           // Console.WriteLine("epicnode"+bodyStr);

                            if(context.Request.Method.ToLower()=="get"){
                            
                                responsetorepicnode = await ew.TorEpicNode(bodyStr, context.Request.Path.ToString().Replace("/torepicnode","")+context.Request.QueryString.ToString());

                            } 

                            if(context.Request.Method.ToLower()=="post"){

                                responsetorepicnode = await ew.TorEpicNodePost(bodyStr, context.Request.Path.ToString().Replace("/torepicnode","")+context.Request.QueryString.ToString());


                            }

                        }
                        
                      //  Console.WriteLine("What return tor epic node"+responsetorepicnode);

                        context.Response.Headers.Add("Content-Type", "application/json");

                        await context.Response.WriteAsync(responsetorepicnode);
                    

                } else await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                

                endpoints.MapGet("/", async context =>
                {
                     
                    //Console.WriteLine(context.Request.Body);
                    
                    await context.Response.WriteAsync(System.IO.File.ReadAllText("test.html"));
                });

                endpoints.MapGet("/css", async context =>
                {
                    await context.Response.WriteAsync(System.IO.File.ReadAllText("w3.css"));
                });

                endpoints.MapGet("/logo", async context =>
                {
                    byte[] dane = System.IO.File.ReadAllBytes("EpicLogoPay.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/blacklogo", async context =>
                {
                    byte[] dane = System.IO.File.ReadAllBytes("logo.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/logoold", async context =>
                {
                    byte[] dane = System.IO.File.ReadAllBytes("logoold.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/epic_cash", async context =>
                {
                    byte[] dane = System.IO.File.ReadAllBytes("epic_cash.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                }); 

                endpoints.MapGet("/eye-icon", async context =>
                {
                    byte[] dane = System.IO.File.ReadAllBytes("eye-icon.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/icon-menu", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Other/icon-menu.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/icon-create-tx-grey", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Menu Icons/icon-create-tx-grey.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/icon-finalize-tx-grey", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Menu Icons/icon-finalize-tx-grey.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapGet("/icon-send-via-http-grey", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Menu Icons/icon-send-via-http-grey.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-create-tx-response-grey", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Menu Icons/icon-create-tx-response-grey.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-open-http-listener-grey", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Menu Icons/icon-open-http-listener-grey.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-search", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Other/icon-search.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-tx-sending-progress", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-tx-sending-progress.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-tx-received", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-tx-received.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-tx-receiving-progress", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-tx-receiving-progress.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-tx-sent", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-tx-sent.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-tx-canceled", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-tx-canceled.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-output-unconfirmed", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-output-unconfirmed.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-output-locked", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-output-locked.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });
                endpoints.MapGet("/icon-output-unspent", async context =>
                {   
                    context.Response.Headers.Add("Content-Type", "image/png");
                    byte[] dane = System.IO.File.ReadAllBytes("Icons/Transaction Icons/icon-output-unspent.png");
                    await context.Response.Body.WriteAsync(dane, 0, dane.Length);
                });

                endpoints.MapPost("/torsend/v2/foreign/", async context =>{




                    var bodyStr = "";
                    //Console.WriteLine("I am torsend");
                    
                    string responsetorsender= "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(context.Request.Body, false))
                    {
                        bodyStr = await reader.ReadToEndAsync();

                       // Console.WriteLine("ttt"+bodyStr);
                        
                        responsetorsender = await ew.TorSender(bodyStr);

                    }
                    
                  //  Console.WriteLine("What return tor"+responsetorsender);

                    context.Response.Headers.Add("Content-Type", "application/json");

                    await context.Response.WriteAsync(responsetorsender);


                });

              //  endpoints.MapGet("/torepicnode/v1/chain", async context =>{




              //  });

                endpoints.MapPost("/txfilereceiver", async context =>{

                    var bodyStr = "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(context.Request.Body, false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }
                    
                    string name = DateTime.Now.Ticks.ToString()+".tx";
                    
                   // Console.Write(bodyStr);
                    using (StreamWriter writer = new StreamWriter(name, false)){

                        writer.Write(bodyStr);
                    }

                    string response = await ew.TxReceive(name);
                    context.Response.Headers.Add("Content-Type", "application/json");

                    await context.Response.WriteAsync(response);


                });


                endpoints.MapPost("/finalizefilereceiver", async context =>{

                    var bodyStr = "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(context.Request.Body, false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }
                    
                    string name = DateTime.Now.Ticks.ToString()+".tx.response";
                    
                   // Console.Write(bodyStr);
                    using (StreamWriter writer = new StreamWriter(name, false)){

                        writer.Write(bodyStr);
                    }

                    string response = await ew.ResponseFinalize(name);
                    context.Response.Headers.Add("Content-Type", "application/json");

                    await context.Response.WriteAsync(response);


                });

                endpoints.MapPost("/content_receiver", async context =>{

                    //var bodyStr = "";

                    //using (StreamReader reader 
                    //          = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                    //{
                    //    bodyStr = await reader.ReadToEndAsync();
                    //}

                    FromPage odczyt;

                    //Console.WriteLine(context.Request.Body);

                    odczyt = await JsonSerializer.DeserializeAsync<FromPage>(context.Request.Body);
                    //ExpandoObject odczyt = await JsonSerializer.DeserializeAsync<ExpandoObject>(context.Request.Body);

                   // Console.WriteLine(odczyt.kind);
                    switch(odczyt.kind){

                        case "balance":
                                string balance = await ew.Balance();
                                context.Response.Headers.Add("Content-Type", "application/json");
                                string odp = "{\"kind\":\"balance\", \"odp\":"+balance+"}";
                                await context.Response.WriteAsync(odp);
                        break;

                        case "parameters":

                              string parameters = await ew.Parameters();
                              context.Response.Headers.Add("Content-Type", "application/json");
                              await context.Response.WriteAsync(parameters);

                        break;

                        case "sendbyfile":

                              //  Console.WriteLine("send by file");
                              //  Console.WriteLine(odczyt.amount);
                              //  Console.WriteLine(odczyt.smallest);
                              //  Console.WriteLine(odczyt.msg);

                                string response = await ew.SendByFile(odczyt.amount, odczyt.msg,  odczyt.smallest);
                                
                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(response);

                        break;


                        case "sendbyhttp":

                              //  Console.WriteLine("send by http");
                              //  Console.WriteLine(odczyt.amount);
                              //  Console.WriteLine(odczyt.smallest);
                              //  Console.WriteLine(odczyt.msg);
                              //  Console.WriteLine(odczyt.httpdest);

                                string responsesendhttp = await ew.SendByHttp(odczyt.amount, odczyt.msg,  odczyt.smallest, odczyt.httpdest);
                                
                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(responsesendhttp);

                        break;

                        case "history":

                                //Console.WriteLine("History");

                                string responsehistory = await ew.History();

                                string odphistory = "{\"kind\":\"history\", \"odp\":"+responsehistory+"}";
                                
                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odphistory);


                        break;

                        case "canceltransaction":

                               // Console.WriteLine("Cancel Transaction");

                                bool responsecancel = await ew.CancelTransaction(odczyt.id);

                                string odpcancel = "{\"kind\":\"canceltrasaction\", \"odp\":"+responsecancel.ToString().ToLower()+"}";
                                    
                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odpcancel);


                        break;

                        case "outputs":

                                //Console.WriteLine("Outputs");

                                string responseoutputs = await ew.Outputs();

                                string odpoutputs = "{\"kind\":\"outputs\", \"odp\":"+responseoutputs+"}";

                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odpoutputs);


                        break;

                        case "receivebyhttp":

                             //   Console.WriteLine("ReceiveByHttp");

                                bool responsereceive = await ew.StartReceiveByHttp();
                                                         
                                string odpreceive = "{\"kind\":\"receivebyhttp\", \"odp\":"+responsereceive.ToString().ToLower()+"}";

                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odpreceive);


                        break;


                        case "receivebyfast":

                            //    Console.WriteLine("ReceiveByFast");

                                bool responsereceivebyfast = await ew.StartReceiveByFast();
                                                         
                                string odpreceivebyfast = "{\"kind\":\"receivebyfast\", \"odp\":"+responsereceivebyfast.ToString().ToLower()+"}";

                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odpreceivebyfast);


                        break;

                        case "registershort":

                            //    Console.WriteLine("RegisterShort");

                                string responseregistershort = await ew.RegisterShort(odczyt.shortfastaddress);
                                                         
                                string odpregistershort = "{\"kind\":\"registershort\", \"odp\":\""+responseregistershort.ToString()+"\"}";

                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(odpregistershort);

                        break;

                        case "showmyaddresses":

                           //     Console.WriteLine("ShowMyAddresses");

                                string responseshowmyaddresses = await ew.ShowMyAddresses();
                                                         
                                //string odpshowmyaddresses = "{\"kind\":\"showmyaddresses\", \"odp\":\""+responseshowmyaddresses+"\"}";

                                context.Response.Headers.Add("Content-Type", "application/json");
                                
                                await context.Response.WriteAsync(responseshowmyaddresses);

                        break;

                        case "checkwallet":

                           //    Console.WriteLine("CheckWallet");

                               await ew.CheckWallet();

                               context.Response.Headers.Add("Content-Type", "application/json");

                               await context.Response.WriteAsync("{\"kind\":\"checkwallet\", \"odp\":\"Starting\"}");                               

                        break;

                        case "checkchecker":

                           //    Console.WriteLine("CheckChecker");

                               string responsecheckchecker = await ew.CheckChecker();

                               context.Response.Headers.Add("Content-Type", "application/json");

                               await context.Response.WriteAsync("{\"kind\":\"checkchecker\", \"odp\":\""+responsecheckchecker+"\"}");                               

                        break;

                        case "advancedoptionssave":

                            //    Console.WriteLine("AdvancedOptionSave");

                                bool responseadvancedoptionsave = await ew.AdvancedOptionSave(odczyt.epicserveraddress, odczyt.custom, odczyt.walletfoldertype, odczyt.usetor);

                                context.Response.Headers.Add("Content-Type", "application/json");

                               await context.Response.WriteAsync("{\"kind\":\"advancedoptionssave\", \"odp\":"+responseadvancedoptionsave.ToString().ToLower()+"}");                               


                        break;

                        case "asknextlanguage":

                            //   Console.WriteLine("AskNextLanguage");

                               string responseasknextlanguage = await ew.AskNextLanguage(odczyt.lang);

                               context.Response.Headers.Add("Content-Type", "application/json");

                               await context.Response.WriteAsync("{\"kind\":\"asknextlanguage\", \"words\":"+responseasknextlanguage+"}");                               


                        break;

                        case "restorewallet":

                           //    Console.WriteLine("RestoreWallet");

                               //bool responserestorewallet = await ew.RestoreWallet(odczyt.pass, odczyt.phrase);
                                
                               bool responserestorewallet = await ew.RestoreWallet("", "");
                              
                               context.Response.Headers.Add("Content-Type", "application/json");

                               await context.Response.WriteAsync("{\"kind\":\"restorewallet\", \"odp\":"+responserestorewallet.ToString().ToLower()+"}");                               


                        break;

                        default: 
                                await Task.Run(()=>CheckWhat(odczyt, context.Response ));
                        break;



                    }

/*                    if(odczyt.kind=="balance")
                    {
                        string balance = await ew.Balance();
                        context.Response.Headers.Add("Content-Type", "application/json");
                        string odp = "{\"kind\":\"balance\", \"odp\":"+balance+"}";
                        await context.Response.WriteAsync(odp);

                    } else {    
                        await Task.Run(()=>CheckWhat(odczyt, context.Response ));
                    }*/
                    // await context.Response.WriteAsync("Hello Post World!");

                });

            });
        }

       public async void CheckWhat(FromPage frompage, HttpResponse Response ){
      //public async void CheckWhat(ExpandoObject frompage, HttpResponse Response ){
         //   Console.WriteLine( frompage.kind);
            Response.Headers.Add("Content-Type", "application/json");

            string odp = "";

            switch(frompage.kind){

            
                case "Login":
                    
                    bool login = ew.StartOwnerApi(frompage.pass);
                    odp = "{\"kind\":\"Login\", \"odp\":"+login.ToString().ToLower()+"}";

                break;


                case "exit":
                     //   Console.WriteLine("exit");

                        odp = "{\"kind\":\"exit\"}";
                break; 
                
                case "lookfor":
                     
                     string iso = ew.LookFor();
                     //odp = "{\"kind\":\"lookfor\", \"odp\":"+iso.ToString().ToLower()+"}";
                     odp = iso;
                     
                break;

                case "NewWallet":
                    
                   // Console.WriteLine("New NewWallet Here");
                    string[] words = {};
                    if(frompage.pass.Length>2) words = ew.Words(frompage.pass);
                    
                    string wordsanswer ="[\"\"";

                    for(int i=0; i<words.Length; i++){

                        wordsanswer = wordsanswer + ",\""+words[i]+"\""; 

                    }    

                    wordsanswer += "]";

                    odp = "{\"kind\":\"NewWallet\", \"odp\":"+wordsanswer+"}";    

                break;

            }
            
            
            await Response.WriteAsync(odp);

       }
    }

    public class FromPage
    {
        public string kind { get; set; }
        public string pass { get; set; }
        public string filetx { get; set; }
        public string filename { get; set; }
        public string amount {get; set;}
        public string msg { get; set; }
        public bool smallest { get; set; }
        public string httpdest { get; set; }
        public int id { get; set; }
        public string shortfastaddress { get; set; }
        public string epicserveraddress { get; set; }
        public bool custom { get; set; }
        public string walletfoldertype { get; set; }
        public string lang { get; set; }
        public string phrase { get; set; }
        public bool usetor { get; set; }
    }


}
