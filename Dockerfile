FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Server2/Server2.csproj", "Server2/"]
RUN dotnet restore "Server2/Server2.csproj"
COPY . .
WORKDIR "/src/Server2"
RUN dotnet build "Server2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Server2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Server2.dll"]
