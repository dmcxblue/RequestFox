# RequestFox

RequestFox is a tool that grabs the necessary files that are needed to decrypt user logins it is still buggy as it will crash if there is no server listening but here is a dirty POC

It will search for FireFox profiles
Copy them to the Downloads Folder location
Zip all files in 1 then convert it to a base64 string
Send that base64 via a POST request to a controlled server
Delete the Files and Zip
Then you can base64 -d <BLOB> > loot.zip
You can then Decrypt them offline
