using System;
using Raven.Client.Linq;
using StingyPrice.DAL.Models;

namespace StingyPrice.DAL.Repositories
{
    public interface IRepository
    {
        T SingleOrDefault<T>(Func<T, bool> predicate) where T : IModel;
        IRavenQueryable<T> All<T>() where T : IModel;
        void Delete<T>(T item) where T : IModel;
        void Add<T>( T item ) where T : IModel;
        void Save();
    }
}