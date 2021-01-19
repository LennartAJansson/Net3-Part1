using Microsoft.Extensions.Configuration;

using System;

namespace ConfigurationProviders
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            //There is also providers available for:
            //Azure KeyVault,
            //XML,
            //INI
            //and it's also possible to write your own for YAML, SQL Server etc

            Console.WriteLine("You now have access to a complete IConfiguration through variable configuration");
            Console.WriteLine($"  {configuration.GetSection("JsonGroup")["JsonValue"]}");
            Console.WriteLine($"  {configuration.GetSection("UserSecretsGroup")["UserSecretsValue"]}");
            Console.WriteLine($"  {configuration.GetSection("EnvGroup")["EnvValue"]}");
            Console.WriteLine($"  {configuration.GetSection("CmdGroup")["CmdValue"]}");

            Console.WriteLine($"  {configuration["JsonGroup:JsonValue"]}");
            Console.WriteLine($"  {configuration["UserSecretsGroup:UserSecretsValue"]}");
            Console.WriteLine($"  {configuration["EnvGroup:EnvValue"]}");
            Console.WriteLine($"  {configuration["CmdGroup:CmdValue"]}");
        }
    }
}