# epicwallet
EPIC CASH wallet

Compilations:

Windows

dotnet-sdk.dotnet publish --configuration Release  --runtime win-x64  --self-contained false /p:PublishTrimmed=true

Linux

dotnet-sdk.dotnet publish --configuration Release  --runtime linux-x64  --self-contained false /p:PublishTrimmed=true

Mac

dotnet-sdk.dotnet publish --configuration Release  --runtime osd-x64  --self-contained false /p:PublishTrimmed=true

After compilation copy files others then *.cs *.proj to publish folder plus Icons folder.

For use tor you must have tor installed and curl. For Windows please copy standaleone curl.exe and curl need files to publish folder. 

For Mac please copy epic-wallet_for_mac to publish folder and rename to epic-wallet.

Main application start by NetCore file. You can rename it like you want ...aepicStart.exe for example.

That's all.
