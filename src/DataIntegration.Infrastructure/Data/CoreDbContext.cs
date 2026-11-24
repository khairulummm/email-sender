using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Infrastructure.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			var domainAssembly = AppDomain.CurrentDomain.GetAssemblies()
							 .Where(w => w.GetName().Name == "DataIntegration.Domain")
							 .SelectMany(s => s.GetTypes())
							 .Where(t => t.IsClass && !t.IsAbstract && t.Namespace.StartsWith("DataIntegration.Domain.Entities"));

			if (domainAssembly != null)
			{
				foreach (var type in domainAssembly)
				{
					// Menandai entitas keyless jika memiliki atribut [Keyless]
					if (type.GetCustomAttribute<KeylessAttribute>() != null)
					{
						modelBuilder.Entity(type).HasNoKey();
					}
					else
					{
						var keyProperties = type.GetProperties()
							.Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
							.ToList();

						if (keyProperties.Any())
						{
							// Jika ada key yang ditentukan, gunakan key tersebut
							modelBuilder.Entity(type)
								.HasKey(keyProperties.Select(p => p.Name).ToArray());
						}
						else
						{
							var idProperty = type.GetProperty("ID");
							if (idProperty != null)
							{
								modelBuilder.Entity(type).HasKey("ID");
							}
							else
							{
								// Jika tidak ada properti "Id", tentukan key lain atau lemparkan error
								throw new InvalidOperationException($"Entitas {type.Name} tidak memiliki primary key yang valid.");
							}
						}
					}
				}
			}
			else
			{
				// Log warning atau handle jika assembly domain tidak ditemukan
				Console.WriteLine("WARNING: Assembly DataIntegration.Domain not found for model configuration.");
			}

			base.OnModelCreating(modelBuilder);

		}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
  //      {
  //          var currentAssembly = Assembly.GetExecutingAssembly();
  //          var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

  //          foreach (var assembly in referencedAssemblies)
  //          {
  //              if (assembly.FullName.Contains("DataIntegration.Domain"))
  //              {
  //                  var entityTypes = assembly.GetTypes()
  //                      .Where(t => t.Namespace != null &&
  //                                 t.Namespace.StartsWith("DataIntegration.Domain.Entities") &&
  //                                 t.IsClass &&
  //                                 !t.IsAbstract);

  //                  foreach (var type in entityTypes)
  //                  {
  //                      // Menandai entitas keyless jika memiliki atribut [Keyless]
  //                      if (type.GetCustomAttribute<KeylessAttribute>() != null)
  //                      {
  //                          modelBuilder.Entity(type).HasNoKey();
  //                      }
  //                      else
  //                      {
  //                          var keyProperties = type.GetProperties()
  //                              .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
  //                              .ToList();

  //                          if (keyProperties.Any())
  //                          {
  //                              // Jika ada key yang ditentukan, gunakan key tersebut
  //                              modelBuilder.Entity(type)
  //                                  .HasKey(keyProperties.Select(p => p.Name).ToArray());
  //                          }
  //                          else
  //                          {
  //                              var idProperty = type.GetProperty("ID");
  //                              if (idProperty != null)
  //                              {
  //                                  modelBuilder.Entity(type).HasKey("ID");
  //                              }
  //                              else
  //                              {
  //                                  // Jika tidak ada properti "Id", tentukan key lain atau lemparkan error
  //                                  throw new InvalidOperationException($"Entitas {type.Name} tidak memiliki primary key yang valid.");
  //                              }
  //                          }
  //                      }
  //                  }
  //              }
  //          }

  //          base.OnModelCreating(modelBuilder);
  //      }
    }
}
