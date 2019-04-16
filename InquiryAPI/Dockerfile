FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /app

COPY . ./
RUN  dotnet restore
WORKDIR "/app"

   # Enable detection of running in a container
ENV  DOTNET_RUNNING_IN_CONTAINER=true \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true 

EXPOSE 5001
EXPOSE 5000

CMD dotnet watch --project InquiryAPI/ run 
