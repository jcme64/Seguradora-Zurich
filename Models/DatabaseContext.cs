using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SeguradoraApi.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Segurados> Segurados { get; set; }
        public virtual DbSet<Veiculos> Veiculos { get; set; }
        public virtual DbSet<Seguros> Seguros { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segurados>(entity =>
            {
                entity.ToTable("tb_segurados");

                entity.HasKey(e => e.IdSegurado).HasName("PK_tb_segurados");

                entity.Property(e => e.IdSegurado).HasColumnName("id_segurado");

                entity.Property(e => e.NomeSegurado)
                    .IsRequired()
                    .HasColumnName("nome_segurado")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("Cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DtNascimento)
                    .HasColumnName("dt_nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculos>(entity =>
            {
                entity.ToTable("tb_veiculos");

                entity.HasKey(e => e.IdVeiculo).HasName("PK_tb_veiculos");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.MarcaVeiculo)
                    .IsRequired()
                    .HasColumnName("marca_veiculo")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModeloVeiculo)
                    .HasColumnName("modelo_veiculo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CorVeiculo)
                    .HasColumnName("cor_veiculo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasColumnName("placa")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AnoVeiculo)
                    .HasColumnName("ano_veiculo")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Renavam)
                    .HasColumnName("renavam")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ValorVeiculo).HasColumnName("valor_veiculo");
            });

            modelBuilder.Entity<Seguros>(entity =>
            {
                entity.ToTable("tb_seguros");

                entity.HasKey(e => e.IdSeguro).HasName("PK_tb_seguros");

                entity.Property(e => e.IdSeguro).HasColumnName("id_seguro");

                entity.Property(e => e.IdSegurado).HasColumnName("id_segurado");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.TaxaRisco).HasColumnName("taxa_risco");

                entity.Property(e => e.PremioRisco).HasColumnName("premio_risco");

                entity.Property(e => e.PremioPuro).HasColumnName("premio_puro");

                entity.Property(e => e.PremioComercial).HasColumnName("premio_comercial");

                entity.Property(e => e.ValorSeguro).HasColumnName("valor_seguro");
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.ToTable("tb_parametros");

                entity.HasKey(e => e.IdParametro).HasName("PK_tb_parametros");

                entity.Property(e => e.IdParametro).HasColumnName("id_parametro");

                entity.Property(e => e.MargemSeguranca).HasColumnName("margem_seguranca");

                entity.Property(e => e.Lucro).HasColumnName("lucro");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbDataReader GetProcList(string procName, List<SqlParameter> listparam = null)
        {
            try
            {
                this.Database.OpenConnection();
                DbCommand cmd = this.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (listparam != null)
                {
                    listparam.ForEach(x =>
                    {
                        cmd.Parameters.Add(x);
                    });
                }
                return cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
