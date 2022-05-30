using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Course.Models.Database
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStat> PlayerStats { get; set; }
        public virtual DbSet<TeamStat> TeamStats { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        private string DbPath = @"Assets\DB_KHL.DB";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                DbPath = directoryPath + DbPath;
                optionsBuilder.UseSqlite("Data Source=" + DbPath);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.ToTable("Game");

                entity.Property(e => e.Date).HasColumnName("Date");

                entity.Property(e => e.Result).HasColumnName("Result");

                entity.Property(e => e.Referee).HasColumnName("Referee");

            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Team");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.City).HasColumnName("City");

                entity.Property(e => e.Stadium).HasColumnName("Stadium");

                entity.Property(e => e.Coach).HasColumnName("Coach");

            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerName);

                entity.ToTable("Player");

                entity.Property(e => e.PlayerName).HasColumnName("PlayerName");

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamName);

                entity.Property(e => e.Num).HasColumnName("Num");

                entity.Property(e => e.Role).HasColumnName("Role");

                entity.Property(e => e.Age).HasColumnName("Age");

                entity.Property(e => e.Siticenship).HasColumnName("Siticenship");

            });

            modelBuilder.Entity<TeamStat>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TeamStats");

                entity.HasOne(d => d.DateNameNavigation)
                    .WithMany(p => p.TeamStats)
                    .HasForeignKey(d => d.DateName);

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.TeamStats)
                    .HasForeignKey(d => d.TeamName);

                entity.Property(e => e.Goals).HasColumnName("Goals");

                entity.Property(e => e.Shots).HasColumnName("Shots");

                entity.Property(e => e.Face_off_wins).HasColumnName("FaceOffWins");

                entity.Property(e => e.Penalty_time).HasColumnName("PenaltyTime");

            });

            modelBuilder.Entity<PlayerStat>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("PlayerStats");

                entity.HasOne(d => d.DateNameNavigation)
                    .WithMany(p => p.PlayerStats)
                    .HasForeignKey(d => d.DateName);

                entity.HasOne(d => d.PlayerNameNavigation)
                    .WithMany(p => p.PlayerStats)
                    .HasForeignKey(d => d.PlayerName);

                entity.Property(e => e.Player_goals).HasColumnName("PlayerGoals");

                entity.Property(e => e.Passes).HasColumnName("Passes");

                entity.Property(e => e.Score).HasColumnName("Score");

                entity.Property(e => e.Player_shots).HasColumnName("PlayerShots");

                entity.Property(e => e.Player_penalty_time).HasColumnName("PlayerPenaltyTime");

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}