#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/MyShop.Api/"
RUN dotnet restore "MyShop.sln"
#RUN dotnet build "MyShop.sln" -c Debug -o /app/build
#RUN dotnet publish "MyShop.sln" -c Debug -o /app/publish /p:UseAppHost=false

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
#WORKDIR /app
#COPY --from=build /app/publish .
#COPY --from=build /app/publish /build
#ENTRYPOINT ["dotnet", "MyShop.Api.dll"]
ENTRYPOINT ["tail", "-f", "/dev/null"]

#Couldn't build MyShop.sln