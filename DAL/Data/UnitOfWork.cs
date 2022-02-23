using Core.Entities;
using Core.Interfaces;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CinemaDbContext context;

        private IRepository<Genre> genreRepository;
        private IRepository<Movie> movieRepository;

        public UnitOfWork(CinemaDbContext context)
        {
            this.context = context;
        }

        public IRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new BaseRepository<Genre>(context);

                return genreRepository;
            }
        }

        public IRepository<Movie> MovieRepository
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new BaseRepository<Movie>(context);

                return movieRepository;
            }
        }

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
