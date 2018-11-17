FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52848
EXPOSE 44374

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ILeilao.API/ILeilao.API.csproj", "ILeilao.API/"]
COPY ["ILeilao.Domain/ILeilao.Domain.csproj", "ILeilao.Domain/"]
COPY ["ILeilao.Kernel/ILeilao.Kernel.csproj", "ILeilao.Kernel/"]
COPY ["ILeilao.Service/ILeilao.Service.csproj", "ILeilao.Service/"]
COPY ["ILeilao.Business/ILeilao.Business.csproj", "ILeilao.Business/"]
COPY ["ILeilao.Repository/ILeilao.Repository.csproj", "ILeilao.Repository/"]
COPY ["ILeilao.CrossCutting/ILeilao.CrossCutting.csproj", "ILeilao.CrossCutting/"]
RUN dotnet restore "ILeilao.API/ILeilao.API.csproj"
COPY . .
WORKDIR "/src/ILeilao.API"
RUN dotnet build "ILeilao.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ILeilao.API.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Docker
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ILeilao.API.dll"]