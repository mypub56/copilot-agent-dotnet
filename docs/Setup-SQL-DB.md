# Setting Up SQL Server Database

Follow these steps to set up the SQL Server database in the development container:

## Prerequisites

- Ensure Docker is installed and running on your system.
- The development container should be built and running.

## Steps

1. **Start the SQL Server Container**
   The development container is configured to start a SQL Server instance automatically. If it is not running, you can manually start it using the following command:
   ```bash
   docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong@Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
   ```

2. **Connect to the SQL Server**
   Use a SQL client or the `sqlcmd` CLI to connect to the SQL Server instance. Replace `YourStrong@Password` with the password you set in the `postCreateCommand`.
   ```bash
   sqlcmd -S localhost -U sa -P 'YourStrong@Password'
   ```

3. **Create a New Database**
   Once connected, run the following SQL commands to create a new database:
   ```sql
   CREATE DATABASE MyDatabase;
   GO
   ```

4. **Verify the Database**
   List all databases to verify that your new database has been created:
   ```sql
   SELECT name FROM sys.databases;
   GO
   ```

## Notes

- The default `sa` user is used for authentication. You can create additional users if needed.
- Ensure the `ACCEPT_EULA` and `SA_PASSWORD` environment variables are set correctly when starting the container.