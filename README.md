# epicwallet
EPIC CASH wallet

Compilations:

Windows

dotnet-sdk.dotnet publish --configuration Release  --runtime win-x64  --self-contained true /p:PublishTrimmed=true

Linux

dotnet-sdk.dotnet publish --configuration Release  --runtime linux-x64  --self-contained true /p:PublishTrimmed=true

Mac

dotnet-sdk.dotnet publish --configuration Release  --runtime osd-x64  --self-contained true /p:PublishTrimmed=true

After compilation copy files others then *.cs *.proj to publish folder plus Icons folder.

For use tor you must have tor installed and curl. For Windows please copy standaleone curl.exe and curl need files to publish folder. 

For Mac please copy epic-wallet_for_mac to publish folder and rename to epic-wallet.

Main application start by NetCore file. You can rename it like you want ...aepicStart.exe for example.

That's all.


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
