# epicwallet
EPIC CASH wallet

Compilations:

Windows

dotnet publish --configuration Release  --runtime win-x64  --self-contained true /p:PublishTrimmed=true

Linux

dotnet publish --configuration Release  --runtime linux-x64  --self-contained true /p:PublishTrimmed=true

Mac

dotnet publish --configuration Release  --runtime osx-x64  --self-contained true /p:PublishTrimmed=true

Copy the contents of the epicwallet directory EXCEPT FOR *.cs, *.csproj, and bin to epicwallet/bin/Release/net5.0/osx-x64/publish and replace any duplicate files.

In the publish directory, rename epic-wallet_for_mac to epic-wallet and rename NetCore to EpicStart. 

Copy the entire publish directory to your desktop and rename it Epic_Cash.  

Right click your desktop Epic_Cash directory and open a new terminal to it.

Run Epic_Wallet by typing ./EpicStart.  The browser wallet should now open.

If it fails, reboot the computer if and run the ./EpicStart command again from your desktop Epic_Cash directory

Other Comments:

If there are problems with receiving epic cash update the second line of epic-wallet.toml to this:

api_listen_interface = "0.0.0.0"

This listen port will be automated in future versions.

To use tor you must have tor installed and curl. For Windows please copy standaleone curl.exe and curl need files to publish folder. 



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
