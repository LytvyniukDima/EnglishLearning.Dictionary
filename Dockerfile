FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
ARG NUGET_PASS

COPY . /app
WORKDIR /app/src/EnglishLearning.Dictionary.Host
RUN dotnet nuget update source github -u LytvyniukDima -p $NUGET_PASS --store-password-in-clear-text
RUN dotnet publish -c Release -o /app/output

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS runtime
ARG WORDAPI
ARG TEXT_SPEECH
ARG TEXT_REGION

COPY --from=build /app/output /app/host

ENV ASPNETCORE_ENVIRONMENT=Docker
ENV ASPNETCORE_URLS="http://*:8200"
ENV WORDAPI_TOKEN $WORDAPI
ENV TEXT_SPEECH_REGION=${TEXT_REGION}
ENV TEXT_SPEECH_TOKEN=${TEXT_SPEECH}

ENTRYPOINT ["sh", "-c"]
CMD ["dotnet /app/host/EnglishLearning.Dictionary.Host.dll"]
