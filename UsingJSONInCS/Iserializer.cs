﻿namespace UsingJSONInCS
{
    public interface ISerializer
    {
        string Serialize<TEntity>(TEntity entity)
            where TEntity : class, new();

        TEntity Deserialize<TEntity>(string entity)
            where TEntity : class, new();
    }
}
