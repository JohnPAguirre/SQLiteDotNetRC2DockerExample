FROM microsoft/dotnet:core

#Microsoft.Data.Sqlite on ubuntu needs sqlitev3-dev
#https://github.com/aspnet/EntityFramework/issues/3794
RUN mkdir -p /dotnetapp && apt-get -y update  && apt-get install -y libsqlite3-dev && apt-get clean
COPY ./Built/ /dotnetapp
WORKDIR /dotnetapp

#dotnet run  will not work with published apps, must go with dotnet dllname.dll
#https://github.com/dotnet/core/issues/77
ENTRYPOINT ["dotnet", "SQLiteTest.dll"]
#ENTRYPOINT ["dotnet", "run"]
#ENTRYPOINT ["/bin/bash"]