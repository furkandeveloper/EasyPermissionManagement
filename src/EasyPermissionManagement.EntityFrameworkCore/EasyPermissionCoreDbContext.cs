using EasyPermissionManagement.Core.Abstractions;
using EasyPermissionManagement.Core.Entities;
using EasyPermissionManagement.EntityFrameworkCore.Generators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPermissionManagement.EntityFrameworkCore
{
    /// <summary>
    /// Easy Permission Core DbContext
    /// </summary>
    public abstract class EasyPermissionCoreDbContext : DbContext, IEasyPermissionContext
    {
        protected EasyPermissionCoreDbContext()
        {
        }

        protected EasyPermissionCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables
        public virtual DbSet<Permission> Permissions { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>(entity =>
            {
                entity
                    .ToTable(nameof(Permissions), "easy-permissions");

                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(ix=> new{ ix.CreateDate, ix.UpdateDate, ix.Key, ix.Provider });

                entity
                    .Property(p => p.Key)
                    .IsRequired();

                entity
                    .Property(p => p.Provider)
                    .IsRequired();

                entity
                    .Property(p => p.CreateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.UpdateDate)
                    .HasValueGenerator<DateTimeValueGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidValueGenerator>()
                    .ValueGeneratedOnAdd();
            });
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        public virtual async Task<T> InsertAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            await SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task DeleteAsync<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public virtual T Insert<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Added;
            SaveChanges();
            return entry.Entity;
        }

        public virtual T Replace<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = EntityState.Modified;
            SaveChanges();
            return entry.Entity;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
            SaveChangesAsync();
        }
    }
}
