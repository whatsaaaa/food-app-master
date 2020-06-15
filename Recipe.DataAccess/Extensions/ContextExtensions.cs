using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recipe.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Recipe.DataAccess.Extensions
{
    public static class ContextExtensions
    {
        public static void SetCreatedUpdatedAtDates(this IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.Now;
                            break;

                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
