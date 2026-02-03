namespace api.Data;

using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

public class CacheContext
{
    private readonly IDatabase db;

    public CacheContext()
    {
        var muxer = ConnectionMultiplexer.Connect("localhost:6379");
        db = muxer.GetDatabase();
    }

    public string? GetCache(string key)
    {
        return db.StringGet(key);
    }

    public void NewCache(string key, string value, TimeSpan? expiration = null)
    {
        if (expiration.HasValue)
        {
            _ = db.StringSet(key, value, expiration);
        }
        else
        {
            _ = db.StringSet(key, value);
        }
    }

    public void DeleteKey(string key)
    {
        _ = db.KeyDelete(key);
    }
}

