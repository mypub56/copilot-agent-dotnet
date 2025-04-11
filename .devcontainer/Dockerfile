FROM mcr.microsoft.com/dotnet/sdk:7.0

# Install required tools
RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends sqlite3

# Set the working directory
WORKDIR /workspace

# Expose ports
EXPOSE 5000 5001
