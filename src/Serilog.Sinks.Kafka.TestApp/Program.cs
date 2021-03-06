﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Serilog.Sinks.Kafka.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__BOOTSTRAP_SERVERS", "localhost:9092");
            
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__SocketKeepaliveEnable", "true");
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__MetadataMaxAgeMs", "180000");
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__RequestTimeoutMs", "30000");
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__Partitioner", "ConsistentRandom");
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__EnableIdempotence", "false");
            Environment.SetEnvironmentVariable("SERILOG__KAFKA__CompressionType", "None");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            Log.Information("Console Application Test!");

            Log.CloseAndFlush();
        }
    }
}
