using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MlbStatsLoader.ConsoleApp.Configurations;
using MlbStatsLoader.ConsoleApp.Contexts;
using MlbStatsLoader.ConsoleApp.Models;
using MlbStatsLoader.ConsoleApp.Repositories;
using MlbStatsLoader.ConsoleApp.Transformers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MlbStatsLoader.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            var settings = provider.GetService<AppSettings>();

            if (!string.IsNullOrEmpty(settings.LogFile))
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
                   .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                   .WriteTo.File(settings.LogFile, Serilog.Events.LogEventLevel.Information)
                   .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
                    .WriteTo.Console(Serilog.Events.LogEventLevel.Information)
                    .CreateLogger();
            }

            var logger = provider.GetService<ILogger<Program>>();

            logger.LogInformation("PRESS ANY KEY TO BEGIN IMPORT...");
            Console.ReadKey();

            try
            {
                if (Directory.Exists(settings.ImportDirectory))
                {
                    List<string> files = Directory.GetFiles(settings.ImportDirectory).ToList();

                    Parallel.ForEach(files, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, file => 
                    {
                        try
                        {
                            if (File.Exists(file))
                            {
                                logger.LogInformation($"Processing File {file}");
                                string json = File.ReadAllText(file);
                                var models = JsonConvert.DeserializeObject<List<GameModel>>(json);

                                var context = provider.GetService<SqlContext>();
                                var repo = new SqlRepository(context);

                                foreach (var model in models)
                                {

                                    var homeTeam = TeamTransformer.TransformerHome(model);
                                    var awayTeam = TeamTransformer.TransformAway(model);

                                    model.AwayHitting.RemoveAll(c => string.IsNullOrEmpty(c.Url));
                                    model.AwayPitching.RemoveAll(c => string.IsNullOrEmpty(c.Url));
                                    model.HomeHitting.RemoveAll(c => string.IsNullOrEmpty(c.Url));
                                    model.HomePitching.RemoveAll(c => string.IsNullOrEmpty(c.Url));
                                    if (repo.Exists(homeTeam))
                                    {
                                        var original = repo.GetTeam(homeTeam.Code);
                                        homeTeam.Id = original.Id;
                                        homeTeam = repo.Update(homeTeam);
                                    }
                                    else
                                    {
                                        homeTeam = repo.Insert(homeTeam);
                                    }
                                    if (repo.Exists(awayTeam))
                                    {
                                        var original = repo.GetTeam(awayTeam.Code);
                                        awayTeam.Id = original.Id;
                                        awayTeam = repo.Update(awayTeam);
                                    }
                                    else
                                    {
                                        awayTeam = repo.Insert(awayTeam);
                                    }

                                    if (model.AwayHitting.Count > 0)
                                    {
                                        foreach (PlayerStatModel statmodel in model.AwayHitting)
                                        {
                                            var player = PlayerTransformer.Transform(statmodel, awayTeam.Id);
                                            if (repo.Exists(player))
                                            {
                                                var original = repo.GetPlayer(player.Url);
                                                player.Id = original.Id;
                                                player = repo.Update(player);
                                            }
                                            else
                                            {
                                                player = repo.Insert(player);
                                            }

                                            var stat = StatTransformer.Transform(statmodel, player.Id, homeTeam.Id, awayTeam.Id, model.GameDate);
                                            repo.Insert(stat);

                                        }
                                    }

                                    if (model.AwayPitching.Count > 0)
                                    {
                                        foreach (PitcherStatModel statmodel in model.AwayPitching)
                                        {
                                            var player = PlayerTransformer.Transform(statmodel, awayTeam.Id);
                                            if (repo.Exists(player))
                                            {
                                                var original = repo.GetPlayer(player.Url);
                                                player.Id = original.Id;
                                                player = repo.Update(player);
                                            }
                                            else
                                            {
                                                player = repo.Insert(player);
                                            }
                                            var stat = StatTransformer.Transform(statmodel, player.Id, homeTeam.Id, awayTeam.Id, model.GameDate);
                                            repo.Insert(stat);
                                        }
                                    }

                                    if (model.HomeHitting.Count > 0)
                                    {
                                        foreach (PlayerStatModel statmodel in model.HomeHitting)
                                        {
                                            var player = PlayerTransformer.Transform(statmodel, homeTeam.Id);
                                            if (repo.Exists(player))
                                            {
                                                var original = repo.GetPlayer(player.Url);
                                                player.Id = original.Id;
                                                player = repo.Update(player);
                                            }
                                            else
                                            {
                                                player = repo.Insert(player);
                                            }

                                            var stat = StatTransformer.Transform(statmodel, player.Id, awayTeam.Id, homeTeam.Id, model.GameDate);
                                        }
                                    }

                                    if (model.HomePitching.Count > 0)
                                    {
                                        foreach (PitcherStatModel statmodel in model.HomePitching)
                                        {
                                            var player = PlayerTransformer.Transform(statmodel, homeTeam.Id);
                                            if (repo.Exists(player))
                                            {
                                                var original = repo.GetPlayer(player.Url);
                                                player.Id = original.Id;
                                                player = repo.Update(player);
                                            }
                                            else
                                            {
                                                player = repo.Insert(player);
                                            }
                                            var stat = StatTransformer.Transform(statmodel, player.Id, awayTeam.Id,homeTeam.Id, model.GameDate);
                                        }
                                    }
                                }

                                logger.LogInformation($"Finished processing file {file}");
                            }
                            else
                            {
                                logger.LogWarning($"File {file} does not exist");
                            }
                        } catch (Exception ex)
                        {
                            logger.LogError(ex, $"FAILED TO PROCESS FILE {file}: {ex.Message}");
                        }


                    });

                }
                else
                {
                    logger.LogError($"IMPORT DIRECTORY {settings.ImportDirectory} DOES NOT EXIST");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"FAILED TO LOAD DATA: {ex.Message}");
            }


            logger.LogInformation("FINISHED");
            Console.ReadKey();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            var root = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var settings = new AppSettings();
            root.GetSection("application").Bind(settings);

            services.AddSingleton(settings);
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(settings.ConnectionString), ServiceLifetime.Transient);
            services.AddLogging(config => config.AddSerilog());

        }
    }
}
