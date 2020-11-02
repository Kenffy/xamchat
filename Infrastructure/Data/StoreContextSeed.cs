using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Identity.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Medias.Any())
                {
                    var mediasData = File.ReadAllText("../Infrastructure/Data/SeedData/medias.json");

                    var medias = JsonSerializer.Deserialize<List<Media>>(mediasData);

                    foreach(var item in medias)
                    {
                        context.Medias.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if(!context.Chats.Any())
                {
                    var chatsData = File.ReadAllText("../Infrastructure/Data/SeedData/chats.json");

                    var chats = JsonSerializer.Deserialize<List<Chat>>(chatsData);

                    foreach(var item in chats)
                    {
                        context.Chats.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}