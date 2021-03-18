using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
//using NSec.Cryptography;
//using Socks;



// add for neverdelete.json and .api_secret
// File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden)

// dotnet-sdk.dotnet publish --configuration Release  --runtime win-x64  --self-contained true /p:PublishTrimmed=true


namespace NetCore
{
	public  class EpicWallet {


		public  EpicWallet(){
            
           //var algorithm = AeadAlgorithm.ChaCha20Poly1305;

           //using var key = Key.Create(algorithm);


           // Console.WriteLine(Figgle.FiggleFonts.Standard.Render("EPIC CASH"));



           //Console.WriteLine(utfString);

/*           byte[] saltBytes = Encoding.ASCII.GetBytes("mnemonic");

           Console.WriteLine("SALT "+ByteArrayToString(saltBytes));
           int interactionCount = 2048; 

           byte[] derived;
           using (var pbkdf2 = new Rfc2898DeriveBytes(
			    "solar hospital daughter royal ladder other then cabbage camp artwork essence senior rude obtain regret mail furnace couch quarter barrel problem review mistake never",
			    saltBytes,
			    interactionCount,
			    HashAlgorithmName.SHA512))
			{
			   derived = pbkdf2.GetBytes(64);
			   Console.WriteLine("Seed "+ByteArrayToString(derived));
			}
           
			byte[] salt2Bytes = Encoding.ASCII.GetBytes("12345678");

			using (var pbkdf2 = new Rfc2898DeriveBytes(
			    "paprykarz",
			    salt2Bytes,
			    100,
			    HashAlgorithmName.SHA512))
			{
			   byte[] derived2 = pbkdf2.GetBytes(32);
			   Console.WriteLine("key "+ByteArrayToString(derived2));

			   var algorithm = AeadAlgorithm.ChaCha20Poly1305;

	           using var key = Key.Import(algorithm, derived2, KeyBlobFormat.RawSymmetricKey);
               
               byte[] nonce = Encoding.ASCII.GetBytes("123456789ABC");
               
               byte[] nic = {};
               
               Console.WriteLine("KeySize "+algorithm.KeySize.ToString());
               Console.WriteLine("NonceSize "+algorithm.NonceSize.ToString());
               Console.WriteLine("TagSize "+algorithm.TagSize.ToString());

	           byte[] seed = algorithm.Encrypt(key, nonce, nic, derived );

	           Console.WriteLine("Seed "+ ByteArrayToString(seed));
	           Console.WriteLine("Salt "+ ByteArrayToString(salt2Bytes));
	           Console.WriteLine("Nonce "+ ByteArrayToString(nonce));


			}*/

		   //TestTcpListener();

           Starter();   

           

          // to_entropy("solar hospital daughter royal ladder other then cabbage camp artwork essence senior rude obtain regret mail furnace couch quarter barrel problem review mistake never");

		}

/*		internal class LifetimeEventsHostedService : IHostedService
		{
		    private readonly ILogger _logger;
		    private readonly IHostApplicationLifetime _appLifetime;

		    

		    public LifetimeEventsHostedService(
		        ILogger<LifetimeEventsHostedService> logger, 
		        IHostApplicationLifetime appLifetime)
		    {
		        _logger = logger;
		        _appLifetime = appLifetime;
		    }

		    public LifetimeEventsHostedService(EpicWallet parent)
	        {
	            this.parent = parent;
	        }

		    public Task StartAsync(CancellationToken cancellationToken)
		    {
		        _appLifetime.ApplicationStarted.Register(OnStarted);
		        _appLifetime.ApplicationStopping.Register(OnStopping);
		        _appLifetime.ApplicationStopped.Register(OnStopped);

		        return Task.CompletedTask;
		    }

		    public Task StopAsync(CancellationToken cancellationToken)
		    {
		        return Task.CompletedTask;
		    }

		    private void OnStarted()
		    {
		        _logger.LogInformation("OnStarted has been called.");
                 Console.WriteLine("Start");  
		        // Perform post-startup activities here
		    }

		    private void OnStopping()
		    {
		        _logger.LogInformation("OnStopping has been called.");
                
		        // Perform on-stopping activities here
                
		    }

		    private void OnStopped()
		    {
		        _logger.LogInformation("OnStopped has been called.");

		        // Perform post-stopped activities here
		    }
		}*/

        public void Stopping(){

        	//private System.Diagnostics.Process ownerapiproccess;

		    //private System.Diagnostics.Process receiveproccess;
        	if(ownerapiproccess!=null) { ownerapiproccess.Kill(); Console.WriteLine("Close owner port"); }
        	if(receiveproccess!=null) { receiveproccess.Kill(); Console.WriteLine("Close receive port"); }

        	Console.WriteLine("Close all wallet processes");

        }


		private void TestTcpListener(){

		    TcpListener server=null;
		    try
		    {
		      // Set the TcpListener on port 13000.
		      Int32 port = 13000;
		      IPAddress localAddr = IPAddress.Parse("127.0.0.1");

		      // TcpListener server = new TcpListener(port);
		      server = new TcpListener(localAddr, port);

		      // Start listening for client requests.
		      server.Start();

		      // Buffer for reading data
		      Byte[] bytes = new Byte[256];
		      String data = null;

		      // Enter the listening loop.
		      while(true)
		      {
		        Console.Write("Waiting for a connection... ");

		        // Perform a blocking call to accept requests.
		        // You could also use server.AcceptSocket() here.
		        TcpClient client = server.AcceptTcpClient();
		        Console.WriteLine("Connected!");

		        data = null;

		        // Get a stream object for reading and writing
		        NetworkStream stream = client.GetStream();

		        int i;

		        // Loop to receive all the data sent by the client.
		        while((i = stream.Read(bytes, 0, bytes.Length))!=0)
		        {
		          // Translate data bytes to a ASCII string.
		          data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
		          Console.WriteLine("Received: {0}", data);

		          // Process the data sent by the client.
		          data = data.ToUpper();

		          byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

		          // Send back a response.
		          stream.Write(msg, 0, msg.Length);
		          Console.WriteLine("Sent: {0}", data);
		        }

		        // Shutdown and end connection
		        client.Close();
		      }
		    }
		    catch(SocketException e)
		    {
		      Console.WriteLine("SocketException: {0}", e);
		    }
		    finally
		    {
		       // Stop listening for new clients.
		       server.Stop();
		    }

		    Console.WriteLine("\nHit enter to continue...");
		    Console.Read();
		}

		

		void to_entropy(string phrase){

		    string[] WORDSREAD = System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+"en.txt").Split('\n');

		    var WORDS = new List<string>(WORDSREAD);
             
		    //Console.WriteLine("WORDS Length "+WORDS.Count.ToString());

	    	var words = new List<string>(phrase.Split(" "));
            
            int[] s = {12, 15, 18, 21, 24}; 

			var sizes = new List<int>(s);

			if(!sizes.Contains(words.Count)) return;

			var indexes = new List<int>();

			words.ForEach(delegate(string word)
			{
    			//Console.WriteLine(word);
    			indexes.Add(WORDS.IndexOf(word));

			});
            
            byte wordcount = BitConverter.GetBytes(words.Count)[0];

			byte checksum_bits = Convert.ToByte(wordcount / 3);

			byte mask = BitConverter.GetBytes((1 << checksum_bits) - 1)[0] ; // like u8

			byte last = BitConverter.GetBytes(indexes[indexes.Count - 1])[0];

			indexes.RemoveAt(indexes.Count - 1);

			var checksum = BitConverter.GetBytes(last)[0] & mask;

			var datalen = ((11 * words.Count) - checksum_bits) / 8 - 1;

            var entropy = new List<byte>();

            for(int i = 0; i<datalen; i++){

            	entropy.Add(0);
            }

            byte[] bb = BitConverter.GetBytes((last >> checksum_bits));
            

            entropy.Add(bb[0]);

            var loc = 11 - checksum_bits;

            for(int i=indexes.Count-1; i>=0; i=i-1){

            		for(byte j = 0; j<=11; j++ ){

            			var bita = (BitConverter.GetBytes(indexes[i])[0] & (1 << j)) != 0;


            			byte bil;

            			if(bita) bil =1; else bil = 0;

            			byte locnew = BitConverter.GetBytes(loc)[0];

                        var aa = (bil << (locnew % 8));
            			entropy[datalen - locnew / 8] |= BitConverter.GetBytes(aa)[0];
						
						loc += 1;


            		}

            }
            
            byte[] hashValue;

            using (SHA256 mySHA256 = SHA256.Create())
            {

            	hashValue = mySHA256.ComputeHash(entropy.ToArray());
                       
            }

            var actual = (hashValue[0] >> (8 - checksum_bits)) & mask;

            if(actual != checksum ){

            	Console.WriteLine("Big Mistake");
            }
				
		}

/*        private async Task<bool> checkTor(){
            


        	Socks5Options option = new Socks5Options("127.0.0.1", 9050, "185.228.141.6", 80, "sjsjsj","jsjsjs");
            
            try{
            	Socket s = await Socks5.Connect(DajSocket, option);
            	return true;
            	} catch( SocketException sc) {

            		//Console.WriteLine("checkTor "+sc);

            		
            	}
             	
            return false; 	
        }*/

        static Socket DajSocket()
	    {

	        return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
;
	    }

	    public class SocksocketException : Exception
        {
            public SocksocketException()
            {
            }

            public SocksocketException(string message)
                : base(message)
            {
            }

            public SocksocketException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public async Task<string> TorEpicNodePost(string request, string path){

        	string output="clear";

            System.IO.File.WriteAllText(startdir+Path.DirectorySeparatorChar+"TorTransmisionNode.txt", request);
            var command = " -sS --socks5 127.0.0.1:9050 --data-binary \"@"+startdir+Path.DirectorySeparatorChar+"TorTransmisionNode.txt\" -H \"Content-Type: application/json\" "+epicserveraddress+path;
            //var command = " --socks5 127.0.0.1:9050 -d \""+request+"\"  -X POST "+where;
              
            //Console.WriteLine(command);

             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = "curl";
                 pProcess.StartInfo.Arguments = command;
            
               //  Console.WriteLine(pProcess.StartInfo.Arguments);
                 pProcess.StartInfo.UseShellExecute = false;
                 //pProcess.StartInfo.WorkingDirectory = epichome;
                 pProcess.StartInfo.RedirectStandardOutput = true;
                 pProcess.StartInfo.RedirectStandardInput = false;
                 pProcess.StartInfo.RedirectStandardError = true;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 pProcess.Start();
                 //StreamWriter myStreamWriter = pProcess.StandardInput;
                 //if(usepass==true) myStreamWriter.WriteLine(pass);

                 output = pProcess.StandardOutput.ReadToEnd(); //The output result
                 string error = pProcess.StandardError.ReadToEnd();
                 //pProcess.WaitForExit();
                 
                 do{

                 } while (!pProcess.WaitForExit(30000));

               //  Console.WriteLine("CURL here");

               //  Console.WriteLine($"  Process exit code       : {pProcess.ExitCode}");
               //  Console.WriteLine($"  Process output          : {output}");
               //  Console.WriteLine($"  Process error           : {error}");

                // an.ExitCode = pProcess.ExitCode;
                // an.Output = output;
                // an.Error = error;

                // if(usesearch == true) {

                // 	if(output.Contains(texttosearch)) an.Search = true;
                // }

                

             }


        	return output;
        }

        
        public async Task<string> TorEpicNode(string request, string path){

        	string output="clear";


            var command = " -sS --socks5 127.0.0.1:9050  -H \"Content-Type: application/json\" "+epicserveraddress+path;
            //var command = " --socks5 127.0.0.1:9050 -d \""+request+"\"  -X POST "+where;
              
            //Console.WriteLine(command);

             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = "curl";
                 pProcess.StartInfo.Arguments = command;
            
                // Console.WriteLine(pProcess.StartInfo.Arguments);
                 pProcess.StartInfo.UseShellExecute = false;
                 //pProcess.StartInfo.WorkingDirectory = epichome;
                 pProcess.StartInfo.RedirectStandardOutput = true;
                 pProcess.StartInfo.RedirectStandardInput = false;
                 pProcess.StartInfo.RedirectStandardError = true;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 pProcess.Start();
                 //StreamWriter myStreamWriter = pProcess.StandardInput;
                 //if(usepass==true) myStreamWriter.WriteLine(pass);

                 output = pProcess.StandardOutput.ReadToEnd(); //The output result
                 string error = pProcess.StandardError.ReadToEnd();
                 //pProcess.WaitForExit();
                 
                 do{

                 } while (!pProcess.WaitForExit(30000));

                // Console.WriteLine("CURL here");

                // Console.WriteLine($"  Process exit code       : {pProcess.ExitCode}");
                // Console.WriteLine($"  Process output          : {output}");
                // Console.WriteLine($"  Process error           : {error}");

                // an.ExitCode = pProcess.ExitCode;
                // an.Output = output;
                // an.Error = error;

                // if(usesearch == true) {

                // 	if(output.Contains(texttosearch)) an.Search = true;
                // }

                

             }


        	return output;
        }

        public async Task<string> TorSender(string request){
            
            if(torworking) return "TOR BUSY";

            torworking = true;
	    	string output="clear";
	    	//request = request.Replace(""","/"");
	    	System.IO.File.WriteAllText(startdir+Path.DirectorySeparatorChar+"TorTransmision.txt", request);
            var command = " -sS --socks5 127.0.0.1:9050 --data-binary \"@"+startdir+Path.DirectorySeparatorChar+"TorTransmision.txt\" -H \"Content-Type: application/json\" -X POST  "+torwhere;
            //var command = " --socks5 127.0.0.1:9050 -d \""+request+"\"  -X POST "+where;
              
            //Console.WriteLine(command);

             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = "curl";
                 pProcess.StartInfo.Arguments = command;
            
                // Console.WriteLine(pProcess.StartInfo.Arguments);
                 pProcess.StartInfo.UseShellExecute = false;
                 //pProcess.StartInfo.WorkingDirectory = epichome;
                 pProcess.StartInfo.RedirectStandardOutput = true;
                 pProcess.StartInfo.RedirectStandardInput = false;
                 pProcess.StartInfo.RedirectStandardError = true;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 pProcess.Start();
                 //StreamWriter myStreamWriter = pProcess.StandardInput;
                 //if(usepass==true) myStreamWriter.WriteLine(pass);

                 output = pProcess.StandardOutput.ReadToEnd(); //The output result
                 string error = pProcess.StandardError.ReadToEnd();
                 //pProcess.WaitForExit();
                 
                 do{

                 } while (!pProcess.WaitForExit(30000));

               //  Console.WriteLine("CURL here");

               //  Console.WriteLine($"  Process exit code       : {pProcess.ExitCode}");
               //  Console.WriteLine($"  Process output          : {output}");
               //  Console.WriteLine($"  Process error           : {error}");

                // an.ExitCode = pProcess.ExitCode;
                // an.Output = output;
                // an.Error = error;

                // if(usesearch == true) {

                // 	if(output.Contains(texttosearch)) an.Search = true;
                // }

                

             }

             torworking = false;

             return output; 

		}
        

		public static string ByteArrayToString(byte[] ba)
		{
		  StringBuilder hex = new StringBuilder(ba.Length * 2);
		  foreach (byte b in ba){
		    	hex.AppendFormat("{0:x2}", b);
				//hex.Append(" ");
				}
		  return hex.ToString();
		}

		public static string ByteArrayToAddress(byte[] ba, int interval){

			StringBuilder hex = new StringBuilder(Convert.ToInt32((ba.Length/interval)*2));
			for(int i = 0; i<ba.Length; i=i+interval){

				hex.AppendFormat("{0:x2}", ba[i]);

			}

			return hex.ToString();
		}

		public static byte[] StringToByteArray(String hex)
		{
		  int NumberChars = hex.Length;
		  byte[] bytes = new byte[NumberChars / 2];
		  for (int i = 0; i < NumberChars; i += 2)
		    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		  return bytes;
		}

		private async Task Starter(){

 			Console.WriteLine("Start Epic Wallet. Look at your web browser !");



            startdir = SplitFilename(getExePath());

            string homedir = HomeDirectory();

            epichome = homedir;
            
            //Console.WriteLine("epichome "+epichome);

            configer = JsonSerializer.Deserialize<Configurer>(readfastepicwalletconfig());

            usetor = configer.usetor;

            //Console.WriteLine("use tor"+configer.usetor.ToString());

            epicwallethome = configer.epic_wallet_directory;

            epicwallethometype = configer.epic_wallet_directory_type;

            epicserveraddress = configer.epic_server;

            epicservercustom = configer.epic_server_custom;

            fasthttpinterface = configer.http_inter;

            language = configer.language;

            //Console.WriteLine(language);

            //Console.WriteLine("Startdir " + startdir);

          //  bool toris = await checkTor();

          //  Console.WriteLine("Tor ? "+toris.ToString());

            if(epicwallethometype=="Standard"){

            	epichome = homedir + Path.DirectorySeparatorChar + epicwallethome ;

            } else {

            	epichome = startdir  ; 
            }

            
            // ENcryption side

			            //Generate a public/private key pair.
            
			              
			if(!File.Exists(startdir+Path.DirectorySeparatorChar+"neverdelete.json")){

				rsa = RSA.Create();  

				byte[] privatekey = rsa.ExportRSAPrivateKey();

				//Save the public key information to an RSAParameters structure.  
				//RSAParameters rsaKeyInfo = rsa.ExportParameters(false);

				File.WriteAllBytes(startdir+Path.DirectorySeparatorChar+"neverdelete.json", privatekey);
               // Console.WriteLine("Create New Keys "+ startdir+Path.DirectorySeparatorChar+"neverdelete.json");
			} 
        
			rsa = RSA.Create();
            
            //Console.WriteLine("Read Keys "+ startdir+Path.DirectorySeparatorChar+"neverdelete.json");


			byte[] keys = File.ReadAllBytes(startdir+Path.DirectorySeparatorChar+"neverdelete.json");
            
            int ile;
			
			rsa.ImportRSAPrivateKey(keys, out ile);

			RSAParameters rsaKeyInfo = rsa.ExportParameters(false);			 

			//Console.WriteLine(rsaKeyInfo.Exponent);

			//for(int i = 0; i<rsaKeyInfo.Exponent.Length; i=i+1){

			//	Console.Write(rsaKeyInfo.Exponent[i]);
			//	Console.Write(" ");
			//}

			//Console.WriteLine(ByteArrayToString(rsaKeyInfo.Modulus));
			
			//Console.WriteLine("Length "+ rsaKeyInfo.Modulus.Length.ToString());

			//Console.WriteLine(ByteArrayToString(rsaKeyInfo.Exponent));
			
			fastaddress = ByteArrayToString(rsaKeyInfo.Exponent)+"-"+ByteArrayToString(rsaKeyInfo.Modulus);
            

			fastepicaddress = "https://fastepic.eu/"+fastaddress;
           // Console.WriteLine(fastepicaddress);

           // try{
	//            byte[] test = System.IO.File.ReadAllBytes("tekos.tx");

	//            Array.Copy(a, 1, b, 0, 3);

	//		    a = source array
	//		    1 = start index in source array
	//		    b = destination array
	//		    0 = start index in destination array
	//		    3 = elements to copy

/*	            using (var stream = new FileStream("tekosdecyrpted.tx", FileMode.Append))
				    {
			            for(int i = 0; i<test.Length; i=i+128){
							
							byte[] rob;
						    if(i<(test.Length-128)){
								 
							   rob = new byte[128];
							   Console.WriteLine(i.ToString() + " " + test.Length.ToString());
							   Array.Copy(test, i, rob, 0, 128);	
							} else { 
								rob = new byte[test.Length-i];
								Console.WriteLine(i.ToString() + " "+ (i-test.Length).ToString());
								Array.Copy(test, i, rob, 0, test.Length-i);
								
							}	

							

			            	byte[] encrypted;

							encrypted = rsa.Encrypt(rob, RSAEncryptionPadding.Pkcs1);



			            	string ss = ByteArrayToString(encrypted);
	                        
	                        Console.WriteLine(ss);

			            	byte[] decrypted = StringToByteArray("377418ed66b3e0dbf36f29277c73860a8c8a175dfaa0f38ebe70d85aa3426dc2ffb3e9e09ec162b614cd55ace3ef5f2e8a9e00a248b3404e63b30b6eff5d5a2ad826a092f28dc5cbdc97ebe21e2da5ec91334379069b424a5f5e1aa98da426b0a49cd2c9d09eef667467bf2a6985bfae3e78b2299b412acbfe7b75026f7602558a33ca7969995b27efe40bfe55085a58f5c6d797275ad3b6cdfe25aa02bf6a139fdf1d5336ffdf1ab22bbc7ab5db86e9b382c27efe1b158abcaec522e4044c6900e82d91ce15ec7e5d5a7997276b24102d061a506f7333105034a2e6283e30e37a099d197d8d3c77dc48005c2b6fdb50e675ee43f852f3559041c03e22009f9a");			

							byte[] special = rsa.Decrypt(decrypted, RSAEncryptionPadding.Pkcs1);

			           			

						        stream.Write(special, 0, special.Length);
						    
						}
				}*/

			 //} catch(...){

			 //	Console.Write("texos error");
			 //}

		//	ReadFastTest();
  
						
			//System.IO.File.WriteAllBytes("tekosdecyrpted.tx", test);			
			//Console.WriteLine(ByteArrayToAddress(rsaKeyInfo.Modulus, 4));			

			// End of encryption side  

			//set epic-wallet.toml
            
/*            List<string> tomllines = new List<string>();


			if(File.Exists(startdir+Path.DirectorySeparatorChar+"epic-wallet.toml")){	
			
				foreach (string line in File.ReadLines(startdir+Path.DirectorySeparatorChar+"epic-wallet.toml"))
				{
					string toadd = line;
				    if (line.Contains("data_file_dir"))
				    {
				        Console.WriteLine(line);
				        toadd = "data_file_dir = \""+epichome+Path.DirectorySeparatorChar+"wallet_data\"";
				    }

				    if(line.Contains("api_secret_path") && !line.Contains("node_api_secret_path")){

				    	Console.WriteLine(line);
				    	toadd = "api_secret_path = \""+epichome+Path.DirectorySeparatorChar+".api_secret\"";
				    }

				    tomllines.Add(toadd);
				}

				File.WriteAllLines(startdir+Path.DirectorySeparatorChar+"epic-wallet.toml", tomllines.ToArray(), Encoding.UTF8);

			}*/

            OpenBrowser("http://localhost:5000");

           // Console.WriteLine(configer.epic_server);

           // startProcesEpic(" -r https://fastepic.eu:3413 info", "", true, "takst to serch", true);
			

		}

		private string torwhere = "https://fastepic.eu/keybaseid_ilonapie/v2/foreign";

		private bool torworking = false;

		private bool usetor = false;

		private string language;
        
		private string checkwallet;

		private RSA rsa;

        private string fastaddress; 

		private string fastepicaddress;

		public string startdir;

		public string omedir;

		public string epichome;

		public Configurer configer;

		public string epicwallethome;

		public string epicwallethometype;

		public string epicserveraddress;

		public bool epicservercustom;

		public string fasthttpinterface; 

		private string  apisecret;

		private string password;

		private System.Diagnostics.Process ownerapiproccess;

		private System.Diagnostics.Process receiveproccess;

		private bool listen = false;

	    private bool listenfast = false;

	    private static Timer timer;

		static readonly HttpClient client = new HttpClient();

                    
		public string getExePath(){

			return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
			
		}

		public string SplitFilename(string filename){
            
           // Console.WriteLine("fileName" + filename);
			int last = filename.LastIndexOf(Path.DirectorySeparatorChar);

			return filename.Substring(0, last);
		}

		public string HomeDirectory(){

			return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile, Environment.SpecialFolderOption.DoNotVerify);
		}

		public string readfastepicwalletconfig(){

            return System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+"fastconfig.json");
            
		}

		public string LookFor(){

			string odp = "{\"kind\":\"lookfor\", \"odp\":false}";

			string languagewords ="{\"words\":[]}";

			if(!File.Exists(startdir+Path.DirectorySeparatorChar+language.ToLower()+".lang")){

				languagewords = System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+"english.lang");

			} else {

				languagewords = System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+language.ToLower()+".lang");

			}

			LanguageWords lw = JsonSerializer.Deserialize<LanguageWords>(languagewords);

		    string[] fileEntries = Directory.GetFiles(startdir,"*.lang");

	      //  Console.WriteLine("Number of languages: "+fileEntries.Length.ToString());

	        List<string> langs = new List<string>(); 
	        foreach(string fileName in fileEntries){

	          //  Console.WriteLine(fileName);

	            langs.Add(Path.GetFileNameWithoutExtension(fileName));

	        }

	        string langsss = JsonSerializer.Serialize(langs.ToArray());

	       // Console.WriteLine(langsss);

	      //  EpicAnswer an;

	        bool aan = false;

			if(epicwallethometype=="Standard") {

				// Console.WriteLine("LookFor Standard " + epicwallethometype);

				// an = startProcesEpic(" info", "testpassword", true,"seed could not be opened (epic wallet init)", true);
                 
                 aan = !File.Exists(epichome+Path.DirectorySeparatorChar+"wallet_data"+Path.DirectorySeparatorChar+"wallet.seed");
                 //Console.WriteLine(epichome+Path.DirectorySeparatorChar+"wallet_data"+Path.DirectorySeparatorChar+"wallet.seed");
                 //return an.Search;

			} else {

				// Console.WriteLine("LookFor Local " + epicwallethometype);

				// an = startProcesEpic(" info", "testpassword", true,"seed could not be opened (epic wallet init)", true);
				 aan = !File.Exists(epichome+Path.DirectorySeparatorChar+"wallet_data"+Path.DirectorySeparatorChar+"wallet.seed");
                // Console.WriteLine(epichome+Path.DirectorySeparatorChar+"wallet_data"+Path.DirectorySeparatorChar+"wallet.seed");                
                 // return an.Search;
			}

		//	Console.WriteLine("{\"kind\":\"lookfor\", \"odp\":"+an.Search.ToString().ToLower()+", \"usetor\":"+usetor.ToString().ToLower()+", \"epicservercustom\":"+epicservercustom.ToString().ToLower()+" , \"epicserveraddress\":\""+epicserveraddress+"\" , \"epicwallethometype\":\""+epicwallethometype+"\", \"languages\":"+langsss+",\"language\":\""+language+"\", \"words\":"+JsonSerializer.Serialize(lw.words)+"}");

		//	return "{\"kind\":\"lookfor\", \"odp\":"+an.Search.ToString().ToLower()+",\"usetor\":"+usetor.ToString().ToLower()+", \"epicservercustom\":"+epicservercustom.ToString().ToLower()+" , \"epicserveraddress\":\""+epicserveraddress+"\" , \"epicwallethometype\":\""+epicwallethometype+"\", \"languages\":"+langsss+",\"language\":\""+language+"\", \"words\":"+JsonSerializer.Serialize(lw.words)+"}";
		
		return "{\"kind\":\"lookfor\", \"odp\":"+aan.ToString().ToLower()+",\"usetor\":"+usetor.ToString().ToLower()+", \"epicservercustom\":"+epicservercustom.ToString().ToLower()+" , \"epicserveraddress\":\""+epicserveraddress+"\" , \"epicwallethometype\":\""+epicwallethometype+"\", \"languages\":"+langsss+",\"language\":\""+language+"\", \"words\":"+JsonSerializer.Serialize(lw.words)+"}";
	
		}

		public async Task<bool> RestoreWallet(string pass, string phrase){
            
        //    Console.WriteLine("RestoreWallet");

	        EpicAnswer an;

			if(epicwallethometype=="Standard") {
				
				an = startProcesEpicRecover(" init -r", phrase, pass+'\n'+pass+'\n', true, "Command 'init' completed successfully", true);

			} else {

				an = startProcesEpicRecover(" init -r -h", phrase, pass+'\n'+pass+'\n', true, "Command 'init' completed successfully", true);
			}
		    
		    if(an.ExitCode == 0){
			
				return true;             
			
			} else {

				return false;

			}


		}

		public async Task<string> AskNextLanguage(string lang){

			string languagewords ="{\"words\":[]}";

			if(!File.Exists(startdir+Path.DirectorySeparatorChar+lang.ToLower()+".lang")){

				languagewords = System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+"english.lang");

			} else {

				languagewords = System.IO.File.ReadAllText(startdir+Path.DirectorySeparatorChar+lang.ToLower()+".lang");

			}

			LanguageWords lw = JsonSerializer.Deserialize<LanguageWords>(languagewords);

			
			return JsonSerializer.Serialize(lw.words);	

		}

		public async Task<bool> AdvancedOptionSave(string address, bool custom, string folder, bool runtor){

			// Console.WriteLine(address + " " + custom.ToString() + " "+ folder);
            
            if(checkwallet=="Working") return false;

            configer.epic_server = address;

            configer.epic_server_custom = custom;

            configer.epic_wallet_directory_type = folder;

            configer.usetor = runtor;

            //using FileStream createStream = File.Create(startdir+"/"+"fastconfig.json");
			//await JsonSerializer.SerializeAsync(createStream, configer);
			string jsonString = JsonSerializer.Serialize(configer);
			File.WriteAllText(startdir+Path.DirectorySeparatorChar+"fastconfig.json", jsonString);

			if(listen==true) await StartReceiveByHttp(); 

			if(listenfast == true ) await StartReceiveByFast();

			if(ownerapiproccess!=null) {

				//Console.WriteLine("Kill ownerapiproccess");
				ownerapiproccess.Kill();;

			}

            Starter();

			return true;
		}


/*		string teststring = @"File /home/robert/Documents/NetCore/epic-wallet.toml configured and created
Please enter a password for your new wallet
Password: Confirm Password: 20201123 14:38:24.319 WARN epic_wallet_impls::seed - Generating wallet seed file at: /home/robert/Documents/NetCore/wallet_data/wallet.seed
Your recovery phrase is:

tenant aerobic unveil add grocery oak cool setup length sing urban glue scatter coffee problem leave solar silk misery image pupil end brain horror

Please back-up these words in a non-digital format.
Command 'init' completed successfully";*/

		public string[] Words(string pass){
            
           // Console.WriteLine("Words");
			string[] words = {};

            EpicAnswer an;

			if(epicwallethometype=="Standard") {

				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	an = startProcesEpic(" init", pass, true, "Command 'init' completed successfully", true);

		        } else an = startProcesEpic(" init", pass+'\n'+pass+'\n', true, "Command 'init' completed successfully", true);

			} else {
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	an = startProcesEpic(" init -h", pass, true, "Command 'init' completed successfully", true);
		        	
		        } else an = startProcesEpic(" init -h", pass+'\n'+pass+'\n', true, "Command 'init' completed successfully", true);
			}

			if(an.Search == true){
			
			    if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	//Console.Write(an.Output);
			    	string[] ww = an.Output.Split('\n');
			    	//Console.WriteLine(ww[2]);
					words = ww[5].Split(' '); 
					

		        } else {
					//Console.Write(an.Output);
			    	string[] ww = an.Output.Split(Environment.NewLine);
					words = ww[5].Split(' '); 
					//Console.WriteLine(words[0]);             
				}
			} else {

			 	Console.WriteLine("Error creation wallet");

			}

			return words;

		}
        

        public async Task<string> Balance(){

        	  string responseBody = "!!!!!";
        	  try	
			  {

              //  apisecret="epic:xcHuTCUs6DaKJyoWIily";

			  	var json = "{\"jsonrpc\": \"2.0\",\"method\": \"retrieve_summary_info\",\"params\": [true, 10],\"id\": 1}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");;

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:3420/v2/owner", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			     //Console.WriteLine(responseBody);
			  }
			  catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }


        public async Task<string> Parameters(){

        	return "{\"kind\":\"parameters\", \"listen\":"+listen.ToString().ToLower()+", \"listenfast\":"+listenfast.ToString().ToLower()+", \"fastepicaddress\":\""+fastepicaddress+"\"}";

        }

        public async Task<string> History(){

        	  string responseBody = "false";
        	  try	
			  {

              //  apisecret="epic:xcHuTCUs6DaKJyoWIily";

			  	var json = "{\"jsonrpc\": \"2.0\",\"method\": \"retrieve_txs\",\"params\": [true, null, null],\"id\": 1}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");;

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:3420/v2/owner", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			     //Console.WriteLine(responseBody);
			  }
			  catch(HttpRequestException e)
			  {
			   //  Console.WriteLine("\nException Caught!");	
			   //  Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }

         public async Task<string> Outputs(){

        	  string responseBody = "false";
        	  try	
			  {

               // apisecret="epic:xcHuTCUs6DaKJyoWIily";

			  	var json = "{\"jsonrpc\": \"2.0\",\"method\": \"retrieve_outputs\",\"params\": [false, true, null],\"id\": 1}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");;

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:3420/v2/owner", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			     //Console.WriteLine(responseBody);
			  }
			  catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }


        public async Task<string> TxReceive(string filename){

        	  string responseBody = "{\"kind\":\"txreceive\",\"odp\":false }";
        	  try	
			  {

			  	EpicAnswer an = startProcesEpic(" receive -i "+filename, password, true, "Command 'receive' completed successfully", true);

			  	if(an.Search==true){

			  		var bodyStr = "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(filename+".response", false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }

                    responseBody = "{\"kind\":\"txreceive\",\"odp\":"+bodyStr+", \"filename\":\""+filename+".response\"}";
			  	
			  	}

			  }
			  catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }



        public async Task<string> ResponseFinalize(string filename){

        	  string responseBody = "{\"kind\":\"responsefinalize\",\"odp\":false }";
        	  try	
			  {

			  	EpicAnswer an = startProcesEpic(" finalize -i "+filename, password, true, "Command 'finalize' completed successfully", true);

			  	if(an.Search==true){


                    responseBody = "{\"kind\":\"responsefinalize\",\"odp\":true}";
			  	
			  	}

			  }
			  catch(HttpRequestException e)
			  {
			   //  Console.WriteLine("\nException Caught!");	
			   //  Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }
        

        public async Task<bool> CancelTransaction(int id){

        	bool canceled = false;
        	try{

        		EpicAnswer an = startProcesEpic(" cancel -i "+id.ToString() , password, true, "Command 'cancel' completed successfully", true); 

        		if(an.Search==true){

        			canceled = true;
        		} else {

        			canceled = false;
        		}
        	}catch(HttpRequestException e){

        	}

        	return canceled;

        }

        public async Task<string> SendByFile(string amount, string msg, bool smallest){

        	  string responseBody = "{\"kind\":\"sendbyfile\",\"odp\":false }";
        	  try	
			  {

			  	EpicAnswer an;

			  	string name = DateTime.Now.Ticks.ToString()+".tx";

			  	string message = "";

			  	if(msg!="") message = " -g "+"\""+msg+"\"";
                
                if(smallest==false){
			  		an = startProcesEpic(" send -m file -d "+name +" "+amount + message, password, true, "Command 'send' completed successfully", true);
			  	} else {

			        an = startProcesEpic(" send -m file -s smallest -d "+name +" "+amount + message, password, true, "Command 'send' completed successfully", true);		
			  	}

			  	if(an.Search==true){

			  		var bodyStr = "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(name, false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }

                    responseBody = "{\"kind\":\"sendbyfile\",\"odp\":"+bodyStr+", \"filename\":\""+name+"\"}";
			  	
			  	}

			  }
			  catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }

			  return responseBody;

        }


        public async Task<string> SendByHttp(string amount, string msg, bool smallest, string httpdest){

        	  string responseBody = "{\"kind\":\"sendbyhttp\",\"odp\":false }";

        	  if(usetor==true) {

        	  	torwhere = httpdest+"/v2/foreign";
        	  	httpdest = "http://localhost:5000/torsend";
        	  
        	  }

        	  try	
			  {

			  	EpicAnswer an;

			  	string message = "";

			  	if(msg!="") message = " -g "+"\""+msg+"\"";
                
                if(smallest==false){
			  		an = startProcesEpic(" send -d "+httpdest +" "+amount + message, password, true, "Command 'send' completed successfully", true);
			  	} else {

			        an = startProcesEpic(" send -s smallest -d "+httpdest +" "+amount + message, password, true, "Command 'send' completed successfully", true);		
			  	}

			  	if(an.Search==true){


                    responseBody = "{\"kind\":\"sendbyhttp\",\"odp\":true}";
			  	
			  	}

			  }
			  catch(HttpRequestException e)
			  {
			   //  Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }

			  torworking = false;

			  return responseBody;

        }


		public bool StartOwnerApi(string pass){

			apisecret = System.IO.File.ReadAllText(epichome+Path.DirectorySeparatorChar+".api_secret");

			apisecret = "epic:" + apisecret;

			string serveraddress = epicserveraddress;

			if(usetor) serveraddress = "http://localhost:5000/torepicnode";
            
            //Console.WriteLine(apisecret);

			 	 ownerapiproccess = new System.Diagnostics.Process();
             	
			     ownerapiproccess.StartInfo.FileName = startdir+Path.DirectorySeparatorChar+"epic-wallet";


                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	
                        pass = pass.Replace("\n","");
		        		//ownerapiproccess.StartInfo.Arguments ="-p "+ pass + " -d "+epichome+Path.DirectorySeparatorChar+"wallet_data -r "+serveraddress+" owner_api"; //argument
                		ownerapiproccess.StartInfo.Arguments ="-p "+ pass + " -r "+serveraddress+" owner_api"; //argument
                  
		        	
		        
		        } else ownerapiproccess.StartInfo.Arguments = " -r "+serveraddress+" owner_api"; //argument
                 
                 //ownerapiproccess.StartInfo.Arguments = " -d "+epichome+Path.DirectorySeparatorChar+"wallet_data -r "+serveraddress+" owner_api"; //argument
                 
                 ownerapiproccess.StartInfo.UseShellExecute = false;
                 ownerapiproccess.StartInfo.WorkingDirectory = epichome;

                // Console.WriteLine(ownerapiproccess.StartInfo.WorkingDirectory);

                // Console.WriteLine("OwnerApi epichome "+epichome );
                // Console.WriteLine("OwnerApi startdir "+startdir );
                 
                 ownerapiproccess.StartInfo.RedirectStandardOutput = true;
                 ownerapiproccess.StartInfo.RedirectStandardInput = true;
                 ownerapiproccess.StartInfo.RedirectStandardError = false;
                 ownerapiproccess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 ownerapiproccess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 ownerapiproccess.Start();
                 //StreamWriter myStreamWriter = ownerapiproccess.StandardInput;
                 //myStreamWriter.WriteLine(pass+"\n");
				 
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
               	} else {
               		  ownerapiproccess.StandardInput.WriteLine(pass+"\n");
                }                 


                 password = pass;

                 if(configer.easy){
                	 StartReceiveByFast();
             	 }



             return true;

		}

		
		public void ChangeListenPortinToml(){
		
		
		}

		public async Task<bool> StartReceiveByHttp(){
            
             if(listen==true) { receiveproccess.Kill(); listen = false; } else {

                 // maybe other files we need here of epic server tor post
             	 string serveraddress = epicserveraddress;

				 if(usetor) serveraddress = "http://localhost:5000/torepicnode";

			 	 
			 	 receiveproccess = new System.Diagnostics.Process();
             	
			     receiveproccess.StartInfo.FileName = startdir+Path.DirectorySeparatorChar+"epic-wallet";


                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	//receiveproccess.StartInfo.Arguments ="-p "+password+ " -d "+epichome+Path.DirectorySeparatorChar+"wallet_data -r "+serveraddress+" -e listen"; //argument
                    receiveproccess.StartInfo.Arguments ="-p "+password+ " -r "+serveraddress+" -e listen"; //argument
                 	 	
		        
		        } else receiveproccess.StartInfo.Arguments = "-r "+serveraddress+" -e listen"; //argument
                // receiveproccess.StartInfo.Arguments = " -d "+epichome+Path.DirectorySeparatorChar+"wallet_data -r "+serveraddress+" -e listen"; //argument
                 
                 receiveproccess.StartInfo.UseShellExecute = false;
                 ownerapiproccess.StartInfo.WorkingDirectory = epichome;

               //  Console.WriteLine("StartReceiveByHttp epichome "+epichome );
               //  Console.WriteLine("StartReceiveByHttp startdir "+startdir );

                 receiveproccess.StartInfo.RedirectStandardOutput = true;
                 receiveproccess.StartInfo.RedirectStandardInput = true;
                 receiveproccess.StartInfo.RedirectStandardError = false;
                 receiveproccess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 receiveproccess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 
                 
                 receiveproccess.Start();
                // StreamWriter myStreamWriter = receiveproccess.StandardInput;
                 //myStreamWriter.WriteLine(password+"\n");
                 
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {

               	} else {

               		  receiveproccess.StandardInput.WriteLine(password+"\n");
                }

                 if(receiveproccess == null){

                 	listen = false;

                 } else if (receiveproccess.HasExited== true ) {


                 } else {

                 	listen = true;
                 }

                 
              }   
                 
             return listen;

		}
        
		public async Task<bool> StartReceiveByFast(){
            
             if(listenfast==true) { 
                 
                 //look out await
             	 await timer.DisposeAsync();

             	// stop listen fast
             	listenfast = false; 
             } else {

	            var timerState = new TimerState { Counter = 0 };

		        timer = new Timer(
		            callback: new TimerCallback(TimerTask),
		            state: timerState,
		            dueTime: 1000,
		            period: 12*60*1000);

               listenfast = true;
                 
             }   
                 
             return listenfast;

		}


		private async  void TimerTask(object timerState)
	    {
	       // Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
	        var state = timerState as TimerState;
	        Interlocked.Increment(ref state.Counter);
	        //look out awiat added
            await FastResponse(); 
	        await FastTx();
	    }

	    class TimerState
	    {
	        public int Counter;
	    }

        private EpicAnswer startProcesEpicRecover(string command, string phrase, string pass, bool usepass, string texttosearch, bool usesearch){

        	EpicAnswer an = new EpicAnswer();

        	an.ExitCode = -1;
        	an.Output = "Empty";
        	an.Error  = "Empty";
        	an.Search = false;

        	//Console.WriteLine(phrase);
        	//Console.WriteLine(pass);

        	string serveraddress = epicserveraddress;

			if(usetor) serveraddress = "http://localhost:5000/torepicnode";
        	
        		
        // try{

             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = startdir+Path.DirectorySeparatorChar+"epic-wallet";

                 // pProcess.StartInfo.Arguments = " -r "+serveraddress+" -d "+epichome+Path.DirectorySeparatorChar+"wallet_data "+command; //argument
                 pProcess.StartInfo.Arguments = " -r "+serveraddress+" "+command; //argument
                
                 pProcess.StartInfo.UseShellExecute = false;
                 pProcess.StartInfo.WorkingDirectory = epichome;
                 pProcess.StartInfo.RedirectStandardOutput = false;
                 pProcess.StartInfo.RedirectStandardInput = false;
                 pProcess.StartInfo.RedirectStandardError = false;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                 pProcess.StartInfo.CreateNoWindow = false; //not diplay a windows
                 pProcess.Start();
                 //StreamWriter myStreamWriter = pProcess.StandardInput;

                 //Console.WriteLine(pProcess.StandardOutput.ReadLine());
                 //Console.WriteLine(pProcess.StandardOutput.ReadLine());
                 
                 //myStreamWriter.WriteLine("pies");
                // pProcess.StandardInput.Write("Pies");	
                 //if(usepass==true) myStreamWriter.WriteLine(pass);

                 //string output = pProcess.StandardOutput.ReadToEnd(); //The output result
                 //string error = pProcess.StandardError.ReadToEnd();
                 //pProcess.WaitForExit();
                 
                 do{

                 } while (!pProcess.WaitForExit(10000));

                // Console.WriteLine($"  Process exit code       : {pProcess.ExitCode}");
                 //Console.WriteLine($"  Process output          : {output}");
                 //Console.WriteLine($"  Process error           : {error}");

                 an.ExitCode = pProcess.ExitCode;
                // an.Output = output;
                // an.Error = error;

                 if(usesearch == true) {

                 //	if(output.Contains(texttosearch)) an.Search = true;
                 }

             }


        // 	}catch(System.ComponentModel.Win32Exception e) {

         //		Console.WriteLine("Error run epic-wallet");
        // 	}

         	return an;
        }



        private EpicAnswer startProcesEpic(string command, string pass, bool usepass, string texttosearch, bool usesearch){

        	EpicAnswer an = new EpicAnswer();

        	an.ExitCode = -1;
        	an.Output = "Empty";
        	an.Error  = "Empty";
        	an.Search = false;

        	string serveraddress = epicserveraddress;

			if(usetor) serveraddress = "http://localhost:5000/torepicnode";
        		
        // try{

             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = startdir+Path.DirectorySeparatorChar+"epic-wallet";
                

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		        	if(usepass){
		        		pass = pass.Replace("\n","");
		        		//pProcess.StartInfo.Arguments =" -p "+pass +" -r "+serveraddress+" -d "+epichome+Path.DirectorySeparatorChar+"wallet_data "+ command; //argument
                 		pProcess.StartInfo.Arguments =" -p "+pass +" -r "+serveraddress+" "+ command; //argument
                 		
                 	} else {
                 		//pProcess.StartInfo.Arguments =" -r "+serveraddress+" -d "+epichome+Path.DirectorySeparatorChar+"wallet_data "+ command; //argument
                 		pProcess.StartInfo.Arguments =" -r "+serveraddress+" "+ command; //argument
                 			
                 	}

                } else 
                  pProcess.StartInfo.Arguments =" -r "+serveraddress+"  "+ command; //argument
                //  pProcess.StartInfo.Arguments =" -r "+serveraddress+" -d "+epichome+Path.DirectorySeparatorChar+"wallet_data "+ command; //argument
                 
            //   Console.WriteLine(pProcess.StartInfo.Arguments);  
               //  Console.WriteLine(pProcess.StartInfo.FileName);
               //  Console.WriteLine(pProcess.StartInfo.Arguments);
                 
                 pProcess.StartInfo.UseShellExecute = false;
                 pProcess.StartInfo.WorkingDirectory = epichome;
                 pProcess.StartInfo.RedirectStandardOutput = true;
                 pProcess.StartInfo.RedirectStandardInput = true;
                 pProcess.StartInfo.RedirectStandardError = true;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 pProcess.Start();
                // StreamWriter myStreamWriter = pProcess.StandardInput;
                 //if(usepass==true) myStreamWriter.Write(pass+Environment.NewLine);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
               	} else {
               		 if(usepass==true) pProcess.StandardInput.WriteLine(pass);
                }
                 string output = pProcess.StandardOutput.ReadToEnd(); //The output result
                 string error = pProcess.StandardError.ReadToEnd();
                 //pProcess.WaitForExit();
                 
                 do{

                 } while (!pProcess.WaitForExit(10000));

                // Console.WriteLine($"  Process exit code       : {pProcess.ExitCode}");
               //  Console.WriteLine($"  Process output          : {output}");
               //  Console.WriteLine($"  Process error           : {error}");

                 an.ExitCode = pProcess.ExitCode;
                 an.Output = output;
                 an.Error = error;

                 if(usesearch == true) {

                 	if(output.Contains(texttosearch)) an.Search = true;
                 }

             }


        // 	}catch(System.ComponentModel.Win32Exception e) {

         //		Console.WriteLine("Error run epic-wallet");
        // 	}

         	return an;
        }


        public void OpenBrowser(string url)
		{
		    try
		    {
		        Process.Start(url);
		    }
		    catch
		    {
		        // hack because of this: https://github.com/dotnet/corefx/issues/10361
		        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		        {
		            url = url.Replace("&", "^&");
		            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
		        }
		        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		        {
		            Process.Start("xdg-open", url);
		        }
		        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		        {
		            Process.Start("open", url);
		        }
		        else
		        {
		            throw;
		        }
		    }
		}

		private void ReadFastTest(string filename){

			string ss = System.IO.File.ReadAllText(epichome+Path.DirectorySeparatorChar+filename);

			Fast fast = JsonSerializer.Deserialize<Fast>(ss);

			//Console.WriteLine(fast.sec1);
           string name = epichome+Path.DirectorySeparatorChar+filename+".tx";
           using (var stream = new FileStream(name, FileMode.Append))
		   {
	       
	            for(int i =0 ; i< fast.elements.Length; i=i+1){
					//Console.WriteLine("Element "+fast.elements[i]);
				    byte[] decrypted = StringToByteArray(fast.elements[i]);			
				    byte[] special = rsa.Decrypt(decrypted, RSAEncryptionPadding.Pkcs1);
					stream.Write(special, 0, special.Length);
				}


		   }

		}
        

        public async Task<string> FastTx(){

        	  string responseBody = "!!!!!";
        	  try	
			  {

              
			  	var json = "{\"kind\": \"fasttx\",\"params\": [\""+fastaddress+"\", 0]}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");;

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				//var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			    // Console.WriteLine("now"+responseBody);

			     FastTxFiles files = JsonSerializer.Deserialize<FastTxFiles>(responseBody);

                 if(files.kind=="nothing") files.files = new string[]{};
                 
			     ProcessDirectoryFast(epichome, files);

			  }
			  catch(HttpRequestException e)
			  {
			   //  Console.WriteLine("\nException Caught!");	
			   //  Console.WriteLine("Message :{0} ",e.Message);
			  }
              
             // Console.WriteLine(responseBody);

			  return responseBody;

        }


        public async Task FastTxGet(string filename){

        	  string responseBody = "!!!!!";
        	  try	
			  {

              
			  	var json = "{\"kind\": \"fasttxget\",\"params\": [\""+fastaddress+"\", \""+filename+"\"]}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				//var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			     //Console.WriteLine(responseBody);

			     //FastTxFiles files = JsonSerializer.Deserialize<FastTxFiles>(responseBody);

                 File.WriteAllText(epichome+Path.DirectorySeparatorChar+filename, responseBody);

                 ReadFastTest(filename);
                 
                 EpicAnswer an = startProcesEpic(" receive -i "+filename+".tx", password, true, "Command 'receive' completed successfully", true);

			  	if(an.Search==true){

			  		var bodyStr = "";

                    using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(epichome+Path.DirectorySeparatorChar+filename+".tx.response", false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }

                    File.Copy(epichome+Path.DirectorySeparatorChar+filename+".tx.response", epichome+Path.DirectorySeparatorChar+filename+".tx.response.fastr");

                    json = "{\"kind\":\"fastresponse\",\"params\":[\""+fastaddress+"\","+bodyStr+",\""+filename+".fastr\" ]}";
					content = new StringContent(json, Encoding.UTF8, "application/json");
					response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
			     	response.EnsureSuccessStatusCode();
			     	

			  	}

                 
			     //ProcessDirectoryFast(startdir, files);

			  }
			  catch(HttpRequestException e)
			  {
			   //  Console.WriteLine("\nException Caught!");	
			   //  Console.WriteLine("Message :{0} ",e.Message);
			  }
              
              //Console.WriteLine(responseBody);

			  //return responseBody;

        }

	    // Process all files in the directory passed in, recurse on any directories
	    // that are found, and process the files they contain.
	    public async void ProcessDirectoryFast(string targetDirectory, FastTxFiles fastfiles)
	    {
	        // Process the list of files found in the directory.
	        string[] fileEntries = Directory.GetFiles(targetDirectory,"*.fast");

	        //Console.WriteLine(targetDirectory);
	        foreach(string fileName in fileEntries){

	            //Console.WriteLine(fileName);

	        } 

	        //Console.WriteLine(fastfiles.kind);
            
            var diff =     
		    fastfiles.files.
		    Where( p => 
		            !fileEntries.Any( s => 
		                Path.GetFileName(s) == p
		                //s.FirstName == p.FirstName && 
		                //s.SecondName == p.SecondName
		         ) 
		    );

		    //Console.WriteLine(diff.Count());

		    if(diff.Count()>0){

		    	var enumerator = diff.GetEnumerator();

		    	if(enumerator.MoveNext()){

		    		//Console.WriteLine("next "+enumerator.Current);
                    
                    // look out changed
		    		await FastTxGet(enumerator.Current);	

		    	}

		    }

	        //foreach(string fileName in fileEntries){

	        //     ProcessFile(fileName);

	        //}     
	        // Recurse into subdirectories of this directory.
	       // string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
	       // foreach(string subdirectory in subdirectoryEntries)
	       //     ProcessDirectory(subdirectory);
	    }



        public async Task<string> FastResponse(){

        	  string responseBody = "!!!!!";
        	  try	
			  {

              
			  	var json = "{\"kind\": \"fastresponsefiles\",\"params\": [\""+fastaddress+"\", 0]}";
			  	var content = new StringContent(json, Encoding.UTF8, "application/json");;

				//Basic Authentication
				//var authenticationString = $"{clientId}:{clientSecret}";
				//var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apisecret));
				//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64EncodedAuthenticationString);
					// .Headers.Add("Authorization", $"Basic {base64EncodedAuthenticationString}");


			     HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
			     response.EnsureSuccessStatusCode();
			     responseBody = await response.Content.ReadAsStringAsync();
			     // Above three lines can be replaced with new helper method below
			     // string responseBody = await client.GetStringAsync(uri);

			     //Console.WriteLine(responseBody);

			     
			     FastTxFiles files = JsonSerializer.Deserialize<FastTxFiles>(responseBody);

			     if(files.kind=="nothing") files.files = new string[]{};

                 
                 // look out changed await added
			     await ProcessDirectoryFastResponse(epichome, files);

			  }
			  catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }
              
             // Console.WriteLine(responseBody);

			  return responseBody;

        }


	    // Process all files in the directory passed in, recurse on any directories
	    // that are found, and process the files they contain.
	    public async Task ProcessDirectoryFastResponse(string targetDirectory, FastTxFiles filesresponse)
	    {
	        // Process the list of files found in the directory.
	        string[] fileEntries = Directory.GetFiles(targetDirectory,"*.fastr");
	        //foreach(string fileName in fileEntries)
	        //     ProcessFile(fileName);

	        //Console.WriteLine("How many in folder"+fileEntries.Length);

	        //Console.WriteLine(filesresponse.files.Length);

	        var diff =     
		    fileEntries.
		    Where( p => 
		            !filesresponse.files.Any( s => 
		                s == Path.GetFileName(p)
		                //s.FirstName == p.FirstName && 
		                //s.SecondName == p.SecondName
		         ) 
		    );

			//Console.WriteLine(".fastr"+diff.Count());		    

		    if(diff.Count()>0){

		    	var enumerator = diff.GetEnumerator();

		    	if(enumerator.MoveNext()){

		    		//Console.WriteLine("next festr to send "+enumerator.Current);

		    		string bodyStr = "";
                    
		    		using (StreamReader reader 
                              //= new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                        = new StreamReader(enumerator.Current, false))
                    {
                        bodyStr = await reader.ReadToEndAsync();
                    }

                   
                    var json = "{\"kind\":\"fastresponse\",\"params\":[\""+fastaddress+"\","+bodyStr+",\""+Path.GetFileName(enumerator.Current)+"\" ]}";
					var content = new StringContent(json, Encoding.UTF8, "application/json");
					HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
			     	response.EnsureSuccessStatusCode();	

		    	}

		    }

	        // Recurse into subdirectories of this directory.
	       // string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
	       // foreach(string subdirectory in subdirectoryEntries)
	       //     ProcessDirectory(subdirectory);
	    }

	    // Insert logic for processing found files here.
	    public static void ProcessFile(string path)
	    {
	        //Console.WriteLine("Processed file '{0}'.", path);	
	    }


        public async Task<string> RegisterShort(string shortaddress){

        	string responseBody = "Server mistake";
        	try	
			{
				var json = "{\"kind\":\"registershortname\",\"params\":[\""+fastaddress+"\",\""+shortaddress+"\"]}";
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
				response.EnsureSuccessStatusCode();
				responseBody = await response.Content.ReadAsStringAsync();

				ShortAddress sa = JsonSerializer.Deserialize<ShortAddress>(responseBody);

				responseBody = sa.odp;
                
			} catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }
              
             // Console.WriteLine(responseBody);

			  return responseBody;
        }

        public async Task<string> ShowMyAddresses(){

        	string responseBody = "{\"kind\":\"showmyaddresses\", odp:[]}";
        	try	
			{	
				//Console.WriteLine(fastaddress);
				var json = "{\"kind\":\"showmyaddresses\",\"params\":[\""+fastaddress+"\",0]}";
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync("https://fastepic.eu/epicwallet", content);
				response.EnsureSuccessStatusCode();
				responseBody = await response.Content.ReadAsStringAsync();
                
			} catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }
              
             // Console.WriteLine(responseBody);

			  return responseBody;
        }


        public async Task CheckWallet(){

        	bool oldlisten;
        	bool oldlistenfast;

        	if(checkwallet=="Working") return;
            
            EpicAnswer an = new EpicAnswer();

            checkwallet = "";


			oldlisten = listen;

			if(listen==true) await StartReceiveByHttp(); 

			oldlistenfast = listenfast;

			if(listenfast == true ) await StartReceiveByFast();


			ownerapiproccess.Kill();


        	try	
			{	
				// off processes



				checkwallet = "Working";

				an = startProcesEpic(" check ", password, true, "Command 'check' completed successfully", true); 
  

                
			} catch(HttpRequestException e)
			  {
			    // Console.WriteLine("\nException Caught!");	
			    // Console.WriteLine("Message :{0} ",e.Message);
			  }
			

			StartOwnerApi(password);

			if(an.Search==true){

					checkwallet="OK";

			} else {

					checkwallet="Mistake";	
			}

			if(oldlisten==true) await StartReceiveByHttp();

			if(oldlistenfast==true) await StartReceiveByFast();              
             


			  
        }

        
		public async Task<string> CheckChecker(){

			return checkwallet;

		}

		private void appShortcutToDesktop(string linkName)
		{
		    string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		    using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
		    {
		        string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
		        writer.WriteLine("[InternetShortcut]");
		        writer.WriteLine("URL=file:///" + app);
		        writer.WriteLine("IconIndex=0");
		        string icon = app.Replace('\\', '/');
		        writer.WriteLine("IconFile=" + icon);
		    }
		}

		public class LanguageWords{

			public string[] words {get; set;}
		}        

	    public class ShortAddress{

	    	public string kind { get; set; }
	    	public string odp {get; set; }
	    }

	    public class FastTxFiles{

	    	public string kind { get; set; }
	    	public string[] files {get; set; }
	    }

		public class Fast{

			public string[] elements {get; set;}
			public string sec1 { get; set;}
		}

        public class EpicAnswer{

        	public int ExitCode { get; set; }
        	public string Output { get; set; }
        	public string Error {get; set; }
        	public bool Search { get; set; }
        }

		public class Configurer
	    {
	        public string epic_server { get; set; }
	        public bool epic_server_custom { get; set; }
	        public string epic_wallet_directory { get; set; }
	        public string epic_wallet_directory_type { get; set; }
	        public string http_inter { get; set; }
	        public int http_port { get; set; }
	        public bool start_webgui { get; set; }
	        public string language {get; set;}
	        public bool usetor { get; set; }
	        public bool easy {get; set; }

	    }



	}

}
