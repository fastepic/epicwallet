# epicwallet
EPIC CASH wallet

Compilations:

Windows

dotnet-sdk.dotnet publish --configuration Release  --runtime win-x64  --self-contained true /p:PublishTrimmed=true

Linux

dotnet-sdk.dotnet publish --configuration Release  --runtime linux-x64  --self-contained true /p:PublishTrimmed=true

Mac

dotnet publish --configuration Release  --runtime osx-x64  --self-contained true /p:PublishTrimmed=true

Copy the contents of the epicwallet directory EXCEPT FOR *.cs, *.csproj, and bin to epicwallet/bin/Release/net5.0/osx-x64/publish with the option to replace any duplicate files.

Rename epic-wallet_for_mac to epic-wallet in the publish directory. 

Copy the contents of the publish directory to your user directory.  For example, Users/Bobby

Rename NetCore to Epic_Wallet and double click Epic_Wallet.  

You should now see a terminal window open with some descriptive text and your web browser should open with the Epic Cash wallet page

Other Comments:

If problems with receive epic cash by port listen please find file epic-wallet.toml and in second line change 

api_listen_interface = "127.0.0.1" to api_listen_interface = "0.0.0.0"

To use tor you must have tor installed and curl. For Windows please copy standaleone curl.exe and curl need files to publish folder. 

In next version we will make it automatic.


You can insert this application (NetCore.exe) in proccess of standard other NET application by


             using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
             {
                 pProcess.StartInfo.FileName = "NetCore.exe";
                 pProcess.StartInfo.UseShellExecute = false;
                 pProcess.StartInfo.RedirectStandardOutput = false;
                 pProcess.StartInfo.RedirectStandardInput = false;
                 pProcess.StartInfo.RedirectStandardError = false;
                 pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                 pProcess.Start();

             }
