using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPrice.DAL.Models;

namespace RavenDbDemo.DAL.Repository
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