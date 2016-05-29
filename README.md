# SQLite dotnet core docker example application
I wanted to see how easy it was to get an RC2 SQLite application working, 
and then wondered if there was a way to get it working with docker.  It did
take me a while so I thought I would help out others with the process.

Docker file example taken from here:
https://github.com/dotnet/dotnet-docker

This was harder than I initially though as there are very vew resources and 
very scattered.  Hopefully this example can help someone get to a working 
application a bit faster.

Since I am fairly new to this entire process, these are the steps to get this enviroment up and running

Steps to build 

1) Download docker

https://www.docker.com/products/docker-toolbox

2) Download git

https://git-scm.com/downloads

3) Download this repository

First open up a powershell window and navigate to some directory

EX) cd ~\

git clone https://github.com/JohnPAguirre/SQLiteDotNetRC2DockerExample.git

cd into the folder

4) Lets use the build script to build and push to docker.  First command temporarily 
enables executing powershell scripts

Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope Process -Force 

.\src\SQLiteTest\buildContainer.ps1
