using System;
using System.Collections.Generic;
using StingyPrice.DAL.Models;

namespace StingyPrice.DAL.Repositories
{
    public interface IRepository
    {
        T SingleOrDefault<T>(Func<T, bool> predicate) where T : IModel;
        IEnumerable<T> All<T>() where T : IModel;
        void Delete<T>(T item) where T : IModel;
        void Add<T>( T item ) where T : IModel;
        void Save();
    }
}