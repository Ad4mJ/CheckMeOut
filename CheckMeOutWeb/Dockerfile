FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CheckMeOut/CheckMeOut.csproj", "CheckMeOut/"]
RUN dotnet restore "CheckMeOut/CheckMeOut.csproj"
COPY . .
WORKDIR "/src/CheckMeOut"
RUN dotnet build "CheckMeOut.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CheckMeOut.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CheckMeOut.dll"]