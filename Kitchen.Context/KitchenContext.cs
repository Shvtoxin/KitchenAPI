﻿using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts;
using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Context
{
    /// <summary>
    /// Контекст работы с БД
    /// </summary>
    /// <remarks>
    /// 1) dotnet tool install --global dotnet-ef --version 6.0.0
    /// 2) dotnet tool update --global dotnet-ef
    /// 3) dotnet ef migrations add [name] --project Kitchen.Context\Kitchen.Context.csproj
    /// 4) dotnet ef database update --project Kitchen.Context\Kitchen.Context.csproj
    /// 5) dotnet ef database update [targetMigrationName] --Kitchen.Context\Kitchen.Context.csproj
    /// </remarks>
    public class KitchenContext : DbContext, 
        IKitchenContext, 
        IDbRead, 
        IDbWriter, 
        IUnitOfWork
    {
        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Stimulation> Stimulations { get; set; }

        public DbSet<TypeOfTurnout> TypeOfTurnouts { get; set; }

        public DbSet<TurnOut> TurnOuts { get; set; }

        public KitchenContext(DbContextOptions<KitchenContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
            return count;
        }

        /// <summary>
        /// Чтение сущностей из БД
        /// </summary>
        IQueryable<TEntity> IDbRead.Read<TEntity>()
            => base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();

        /// <summary>
        /// Запись сущности в БД
        /// </summary>
        void IDbWriter.Add<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        /// <summary>
        /// Обновление сущностей
        /// </summary>
        void IDbWriter.Update<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        void IDbWriter.Delete<TEntity>(TEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;
    }
}
