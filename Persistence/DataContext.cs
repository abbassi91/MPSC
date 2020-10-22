using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Affilie> Affilies { get; set; }
        public virtual DbSet<AnnulerQp> AnnulerQps { get; set; }
        public virtual DbSet<AvanceCheque> AvanceCheques { get; set; }
        public virtual DbSet<CumuleQp> CumuleQps { get; set; }
        public virtual DbSet<Echeance> Echeances { get; set; }
        public virtual DbSet<Qp> Qps { get; set; }
        public virtual DbSet<QpMois> QpMois { get; set; }
        public virtual DbSet<LotMisAjour> LotMisAjours { get; set; }
        public virtual DbSet<TypeMisAjour> TypeMisAjours { get; set; }
        public virtual DbSet<MisAjour> MisAjours { get; set; }

        public virtual DbSet<RejetMaj> AnnulerMajs { get; set; }
        public virtual DbSet<CorrigeRejet> CorrigeRejets { get; set; }






        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Affilie>(entity =>
           {
               entity.HasKey(e => e.Cin)
                   .HasName("pk_affile");

               entity.ToTable("affilies");

               entity.HasIndex(e => e.Cin)
                   .HasName("UQ__affilies__D837D024EF0DEB99")
                   .IsUnique();

               entity.Property(e => e.Cin)
                   .HasColumnName("cin")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.Adresse)
                   .HasColumnName("adresse")
                   .HasMaxLength(500)
                   .IsUnicode(false);

               entity.Property(e => e.CodePostale)
                   .HasColumnName("code_postale")
                   .HasMaxLength(10)
                   .IsUnicode(false);

               entity.Property(e => e.DateNaissance)
                   .HasColumnName("date_naissance")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.Matricule)
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.Nom)
                   .HasMaxLength(50)
                   .IsUnicode(false);


               entity.Property(e => e.NumAdherent)
                   .HasColumnName("num_adherent")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.Prenom)
                   .HasColumnName("prenom")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.Rang).HasColumnName("rang");

               entity.Property(e => e.Rib)
                   .HasColumnName("rib")
                   .HasMaxLength(24)
                   .IsUnicode(false);

               entity.Property(e => e.Sexe)
                   .HasColumnName("sexe")
                   .HasMaxLength(1)
                   .IsUnicode(false);

               entity.Property(e => e.SituationVital).HasColumnName("situation_vital");

               entity.Property(e => e.Telephone)
                   .HasColumnName("telephone1")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.Telephone2)
                   .HasColumnName("telephone2")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.TypeAffilie)
                   .HasColumnName("type_affilie")
                   .HasMaxLength(1)
                   .IsUnicode(false);

               entity.Property(e => e.Ville)
                   .HasColumnName("ville")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.Email)
               .HasColumnName("email")
               .HasMaxLength(100)
               .IsUnicode(false);
           });

            builder.Entity<Qp>(entity =>
          {
              entity.HasKey(e => e.NDossier)
                  .HasName("pk_n_dossier");

              entity.ToTable("Qps");

              entity.Property(e => e.NDossier)
                  .HasColumnName("N_dossier")
                  .HasMaxLength(50)
                  .IsUnicode(false);

              entity.Property(e => e.CodeEchance).HasColumnName("code_echance_");

              entity.Property(e => e.DatePaiementReel)
                  .HasColumnName("Date_Paiement_Reel")
                  .HasColumnType("date")
                  .IsUnicode(false);

              entity.Property(e => e.DatePaiementTech)
                  .HasColumnName("Date_Paiement_Tech")
                  .HasColumnType("date")
                  .IsUnicode(false);

              entity.Property(e => e.FraisEngage).HasColumnName("Frais_engage");

              entity.Property(e => e.NCin)
                  .HasColumnName("N_CIN")
                  .HasMaxLength(20)
                  .IsUnicode(false);

              entity.Property(e => e.Observation)
                  .HasMaxLength(500)
                  .IsUnicode(false);

              entity.Property(e => e.Rang).HasColumnName("rang");

              entity.Property(e => e.RembAmo).HasColumnName("Remb_AMO");

              entity.Property(e => e.RembMpsc).HasColumnName("Remb_MPSC");

              entity.Property(e => e.TotalRemb).HasColumnName("Total_Remb");

              entity.HasOne(d => d.CodeEchanceNavigation)
                  .WithMany(p => p.Qp)
                  .HasForeignKey(d => d.CodeEchance)
                  .HasConstraintName("fk_echance");

              entity.HasOne(d => d.NCinNavigation)
                  .WithMany(p => p.Qps)
                  .HasForeignKey(d => d.NCin)
                  .HasConstraintName("fk_cin_qp");

              entity.HasOne(d => d.IduserNavigation)
                  .WithMany(p => p.Qps)
                  .HasForeignKey(d => d.Iduser)
                  .HasConstraintName("fk_userQp");
          });

            builder.Entity<QpMois>(entity =>
           {
               entity.HasKey(e => e.IdPai)
                   .HasName("pk_pai_");

               entity.ToTable("qp_mois");

               entity.Property(e => e.IdPai).HasColumnName("id_pai");

               entity.Property(e => e.CinPaiement)
                   .HasColumnName("cin_paiement")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.CinQp)
                   .HasColumnName("cin_qp")
                   .HasMaxLength(20)
                   .IsUnicode(false);

               entity.Property(e => e.Code303)
                   .HasColumnName("code_303")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.Code304)
                   .HasColumnName("code_304")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.CodeEchanceQpMois).HasColumnName("code_echance_qp_mois");

               entity.Property(e => e.Date)
                   .HasColumnName("date_")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.DateSaisie)
                   .HasColumnName("date_saisie")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.IdUser).HasColumnName("id_user");

               entity.Property(e => e.Observation)
                   .HasColumnName("observation")
                   .HasMaxLength(200)
                   .IsUnicode(false);

               entity.Property(e => e.Qp)
                   .HasColumnName("QP")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.Rcar)
                   .HasColumnName("rcar")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.Property(e => e.TypePai)
                   .HasColumnName("type_pai")
                   .HasMaxLength(50)
                   .IsUnicode(false);

               entity.HasOne(d => d.CinQpNavigation)
                   .WithMany(p => p.QpMois)
                   .HasForeignKey(d => d.CinQp)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("fk_affilies_qp_mois");

               entity.HasOne(d => d.CodeEchanceQpMoisNavigation)
                   .WithMany(p => p.QpMois)
                   .HasForeignKey(d => d.CodeEchanceQpMois)
                   .HasConstraintName("fk_code_echance_qp_mois");

               entity.HasOne(d => d.IdUserNavigation)
                   .WithMany(p => p.QpMois)
                   .HasForeignKey(d => d.IdUser)
                   .HasConstraintName("fk_user_qp_mois");
           });

            builder.Entity<Echeance>(entity =>
            {
                entity.HasKey(e => e.CodeEchance)
                    .HasName("pk_code_echance_qp");

                entity.ToTable("echeance");

                entity.Property(e => e.CodeEchance)
                    .HasColumnName("code_echance");


                entity.Property(e => e.DateDebut)
                    .HasColumnName("date_debut")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.Property(e => e.DateFin)
                    .HasColumnName("date_fin")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserDebutNavigation)
                    .WithMany(p => p.Echeances)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("fk_userDebutEcheance");
            });

            builder.Entity<CumuleQp>(entity =>
            {
                entity.HasKey(e => e.id)
                   .HasName("pk_cumuleQp");

                entity.ToTable("cumule_qp");

                entity.Property(e => e.Cin)
                    .HasColumnName("cin")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateAffectation)
                    .HasColumnName("date_affectation")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.Property(e => e.Montant)
                    .HasColumnName("montant")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .HasColumnName("observation")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.CinNavigation)
                    .WithMany(p => p.CumuleQps)
                    .HasForeignKey(d => d.Cin)
                    .HasConstraintName("fk_affilieCumuleQp");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.CumuleQps)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_userCumuleQp");

            });

            builder.Entity<AvanceCheque>(entity =>
            {
                entity.HasKey(e => e.IdAvanceCheque)
                    .HasName("pk_avance_cheque");

                entity.ToTable("avance_cheque");

                entity.Property(e => e.IdAvanceCheque)
                    .HasColumnName("id_avance_cheque");


                entity.Property(e => e.CinAv)
                    .HasColumnName("cin_av")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateAvance)
                    .HasColumnName("date_avance_")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.Property(e => e.DateSaisie)
                    .HasColumnName("date_saisie")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.Property(e => e.MontantAv)
                    .HasColumnName("montant_av")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Obser)
                    .HasColumnName("obser")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserAvance)
                .HasColumnName("user_avance");

                entity.HasOne(d => d.CinAvNavigation)
                    .WithMany(p => p.AvanceCheques)
                    .HasForeignKey(d => d.CinAv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_avance_cheque_cin");

                entity.HasOne(d => d.UserAvanceNavigation)
                    .WithMany(p => p.AvanceCheques)
                    .HasForeignKey(d => d.UserAvance)
                    .HasConstraintName("fk_user_avance");
            });

            builder.Entity<AnnulerQp>(entity =>
          {
              entity.HasKey(e => e.idAnnulation)
                  .HasName("pk_annulationQp");

              entity.ToTable("Annuler_qp");

              entity.Property(e => e.DateAnnul)
                  .HasColumnName("date_annul")
                  .HasColumnType("date")
                  .IsUnicode(false);

              entity.Property(e => e.IdPaiAnnul).HasColumnName("id_pai_annul");

              entity.Property(e => e.IdUserAnnul).HasColumnName("id_user_annul");

              entity.HasOne(d => d.IdPaiAnnulNavigation)
                  .WithMany()
                  .HasForeignKey(d => d.IdPaiAnnul)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("fk_id_pai_annul_qp");


              entity.HasOne(d => d.IdUserAnnulNavigation)
                  .WithMany()
                  .HasForeignKey(d => d.IdUserAnnul)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("fk_user_annul_qp");
          });



            builder.Entity<LotMisAjour>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("pk_LotMisAjour");

                entity.ToTable("LotMisAjours");

                entity.Property(e => e.DateDebut)
                  .HasColumnName("DateDebut")
                  .HasColumnType("date")
                  .IsUnicode(false);


                entity.Property(e => e.UserDebut)
                .HasColumnName("UserDebut");


                entity.Property(e => e.DateEnvoie)
            .HasColumnName("DateEnvoie")
            .HasColumnType("date")
            .IsUnicode(false);



                entity.HasOne(d => d.IdUserDebutNavigation)
             .WithMany(p => p.LotMisAjours)
             .HasForeignKey(d => d.UserDebut)
             .OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("fk_UserDebutLotMAJ");

            });

            builder.Entity<TypeMisAjour>(entity =>
            {

                entity.HasKey(e => e.Id)
                       .HasName("pk_TypeMisAjour");
                entity.ToTable("TypeMisAjour");

                entity.Property(e => e.Intitule)
                 .HasColumnName("Intitule")
                 .HasMaxLength(50)
                 .IsUnicode(false);


            });


            builder.Entity<MisAjour>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .HasName("pk_misAjour");

                entity.ToTable("MisAJours");

                entity.Property(e => e.CinAffilie)
                    .HasColumnName("CinAffilie")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateMaj)
                    .HasColumnName("DateMaj")
                    .HasColumnType("date")
                    .IsUnicode(false);

                entity.Property(e => e.TypeMaj)
                    .HasColumnName("TypeMaj")
                    .IsUnicode(false);

                entity.Property(e => e.Info)
                    .HasColumnName("Info")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserMaj).HasColumnName("UserMaj");

                entity.Property(e => e.NumLotMaj)
               .HasColumnName("NumLotMaj")
               .IsUnicode(false);

                entity.Property(e => e.AvcSCarte)
               .HasColumnName("AvcSCarte")
               .HasMaxLength(2)
               .IsUnicode(false);

                entity.Property(e => e.NumCarte)
               .HasColumnName("NumCarte")
               .HasMaxLength(10)
               .IsUnicode(false);

                entity.Property(e => e.EnCours)
               .HasColumnName("EnCours")
               .HasMaxLength(2)
               .IsUnicode(false);

                entity.Property(e => e.infoIdentifiant)
               .HasColumnName("infoIdentifiant")
               .HasMaxLength(100)
               .IsUnicode(false);


                entity.HasOne(d => d.CinAvNavigation)
                    .WithMany(p => p.MisAjours)
                    .HasForeignKey(d => d.CinAffilie)
                    .HasConstraintName("fk_affilieMisAjour");

                entity.HasOne(d => d.UserMajNavigation)
                    .WithMany(p => p.MisAjours)
                    .HasForeignKey(d => d.UserMaj)
                    .HasConstraintName("fk_userMisAjour");

                entity.HasOne(d => d.TypeMisAjourNavigation)
               .WithMany(p => p.MisAjours)
               .HasForeignKey(d => d.TypeMaj)
               .HasConstraintName("fk_TypeMaj");

                entity.HasOne(d => d.LotMisAjourNavigation)
               .WithMany(p => p.MisAjours)
               .HasForeignKey(d => d.NumLotMaj)
               .HasConstraintName("fk_NumLotMaj");

            });



            builder.Entity<RejetMaj>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_RejmisAjour");

               entity.ToTable("RejetMajs");

               entity.Property(e => e.Motif)
                 .HasColumnName("Motif")
                 .HasMaxLength(200)
                 .IsUnicode(false);

               entity.Property(e => e.Boite)
                   .HasColumnName("Boite")
                   .IsUnicode(false);

               entity.Property(e => e.DateRejet)
                   .HasColumnName("DateRejet")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.Observation)
             .HasColumnName("Observation")
             .HasMaxLength(200)
             .IsUnicode(false);

               entity.Property(e => e.UserRej)
               .HasColumnName("UserRej");

               entity.Property(e => e.IdMaj)
              .HasColumnName("IdMaj")
              .IsUnicode(false);


               entity.HasOne(d => d.IdUserRejNavigation)
                   .WithMany(p => p.RejetMajs)
                   .HasForeignKey(d => d.UserRej)
                   .HasConstraintName("fk_userRejMisAjour");

               entity.HasOne(d => d.IdMajNavigation)
               .WithMany(p => p.RejetMajs)
               .HasForeignKey(d => d.IdMaj)
               .HasConstraintName("fk_MajRejete");

           });


            builder.Entity<CorrigeRejet>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_CorrigeMisAjour");

               entity.ToTable("CorrigeRejets");

               entity.Property(e => e.idRej)
                 .HasColumnName("idRej");


               entity.Property(e => e.UserCorrigeRejet)
                   .HasColumnName("UserCorrigeRejet");


               entity.Property(e => e.DateCorrige)
                   .HasColumnName("DateCorrige")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.numLot)
             .HasColumnName("numLot")
             .IsUnicode(false);


               entity.HasOne(d => d.IdUserCorrigeRejNavigation)
                   .WithMany(p => p.CorrigeRejets)
                   .HasForeignKey(d => d.UserCorrigeRejet)
                   .HasConstraintName("fk_userCorrigeRejMisAjour");

               entity.HasOne(d => d.idRejNavigation)
               .WithMany(p => p.CorrigeRejets)
               .HasForeignKey(d => d.idRej)
               .HasConstraintName("fk_NumLotCorrigeMaj");

           });




            builder.Entity<Carte>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_Carte");

               entity.ToTable("Cartes");

               entity.Property(e => e.cinAff)
                 .HasColumnName("cinAff")
                  .HasMaxLength(20)
                  .IsUnicode(false);


               entity.Property(e => e.DateArrive)
                   .HasColumnName("DateArrive")
                    .HasColumnType("date")
                   .IsUnicode(false);


               entity.Property(e => e.DateEnvoie)
                   .HasColumnName("DateEnvoie")
                   .HasColumnType("date")
                   .IsUnicode(false);

               entity.Property(e => e.NomPoretur)
                 .HasColumnName("NomPoretur")
                .IsUnicode(false);

                  entity.Property(e => e.CinPorteur)
                 .HasColumnName("CinPorteur")
                .IsUnicode(false);

                  entity.Property(e => e.Disponible)
                 .HasColumnName("Disponible")
                .IsUnicode(false);


               entity.HasOne(d => d.cinAffNavigation)
                   .WithMany(p => p.Cartes)
                   .HasForeignKey(d => d.cinAff)
                   .HasConstraintName("fk_CinCarte");

                entity.HasOne(m => m.UseReceptionNavigation)
                    .WithMany(t => t.CartesReceptions)
                    .HasForeignKey(m => m.UserReception)
                    .HasConstraintName("fk_UseReceptionCarte");

                entity.HasOne(m => m.UserEnvoieNavigation)
                    .WithMany(t => t.CartesEnvoies)
                    .HasForeignKey(m => m.UserEnvoie)
                    .HasConstraintName("fk_UserEnvoieCarte");


           });




 builder.Entity<Enfant>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_Enfant");

               entity.ToTable("Enfants");

               entity.Property(e => e.Nom)
                 .HasColumnName("Nom")
                .IsUnicode(false);

                  entity.Property(e => e.Prenom)
                 .HasColumnName("Prenom")
                .IsUnicode(false);

                  entity.Property(e => e.Cin)
                 .HasColumnName("Cin")
                 .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.cinAff)
                 .HasColumnName("cinAff")
                  .HasMaxLength(20)
                  .IsUnicode(false);

                entity.Property(e => e.DateNaissance)
                   .HasColumnName("DateNaissance")
                    .HasColumnType("date")
                   .IsUnicode(false);

                     entity.Property(e => e.Sexe)
                 .HasColumnName("Sexe")
                  .HasMaxLength(1)
                  .IsUnicode(false);

                 entity.Property(e => e.Observation)
                 .HasColumnName("Observation")
                  .HasMaxLength(50)
                  .IsUnicode(false);

                      entity.Property(e => e.Rang)
                     .HasColumnName("Rang");
                  



               entity.HasOne(d => d.cinAffNavigation)
                   .WithMany(p => p.Enfants)
                   .HasForeignKey(d => d.cinAff)
                   .HasConstraintName("fk_CinAffEnfant");

           });



            builder.Entity<Conjoint>(entity =>
           {
               entity.HasKey(e => e.Cin)
                  .HasName("pk_Conjoint");

               entity.ToTable("Conjointes");

               entity.Property(e => e.Nom)
                 .HasColumnName("Nom")
                .IsUnicode(false);

                  entity.Property(e => e.Prenom)
                 .HasColumnName("Prenom")
                .IsUnicode(false);

                  entity.Property(e => e.Cin)
                 .HasColumnName("Cin")
                 .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.cinAff)
                 .HasColumnName("cinAff")
                  .HasMaxLength(20)
                  .IsUnicode(false);

                entity.Property(e => e.DateNaissance)
                   .HasColumnName("DateNaissance")
                    .HasColumnType("date")
                   .IsUnicode(false);

                     entity.Property(e => e.Sexe)
                 .HasColumnName("Sexe")
                  .HasMaxLength(1)
                  .IsUnicode(false);

                    entity.Property(e => e.Observation)
                 .HasColumnName("Observation")
                  .HasMaxLength(50)
                  .IsUnicode(false);

                      entity.Property(e => e.Rang)
                     .HasColumnName("Rang");



               entity.HasOne(d => d.cinAffNavigation)
                   .WithMany(p => p.Conjoints)
                   .HasForeignKey(d => d.cinAff)
                   .HasConstraintName("fk_CinAffConjoint");

           });







        builder.Entity<DgsnReponse>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_DgsnReponse");

               entity.ToTable("DgsnReponses");

               entity.Property(e => e.CinConj)
                 .HasColumnName("CinConj")
                .IsUnicode(false);

                entity.Property(e => e.DateEnvoie)
                   .HasColumnName("DateEnvoie")
                    .HasColumnType("date")
                   .IsUnicode(false);

                entity.Property(e => e.DateReponse)
                   .HasColumnName("DateReponse")
                    .HasColumnType("date")
                   .IsUnicode(false);

                  entity.Property(e => e.Reponse)
                 .HasColumnName("Reponse")
                 .HasMaxLength(200)
                .IsUnicode(false);

             entity.Property(e => e.IdLotDgsn)
               .HasColumnName("IdLotDgsn")
               .IsUnicode(false);


               entity.HasOne(d => d.CinConjNavigation)
                   .WithMany(p => p.DgsnReponses)
                   .HasForeignKey(d => d.CinConj)
                   .HasConstraintName("fk_ConjointDgsn");

                     entity.HasOne(d => d.IdLotDgsnNavigation)
                   .WithMany(p => p.DgsnReponses)
                   .HasForeignKey(d => d.IdLotDgsn)
                   .HasConstraintName("fk_LotDgsn");


           });




            builder.Entity<LotDgsn>(entity =>
           {
               entity.HasKey(e => e.id)
                  .HasName("pk_LotDgsn");

               entity.ToTable("LotDgsns");

               entity.Property(e => e.UserDebutDgsn)
                 .HasColumnName("UserDebutDgsn");

              entity.Property(e => e.UserEnvoieDgsn)
                 .HasColumnName("UserEnvoieDgsn");

                entity.Property(e => e.DateDebut)
                   .HasColumnName("DateDebut")
                    .HasColumnType("date")
                   .IsUnicode(false);

                entity.Property(e => e.Datefin)
                   .HasColumnName("Datefin")
                    .HasColumnType("date")
                   .IsUnicode(false);



               entity.HasOne(d => d.UserDebutDgsntNavigation)
                   .WithMany(p => p.UserDebuts)
                   .HasForeignKey(d => d.UserDebutDgsn)
                   .HasConstraintName("fk_lotDgsnUserDebutDgsn");

                     entity.HasOne(d => d.UserEnvoieDgsnNavigation)
                   .WithMany(p => p.UserEvoies)
                   .HasForeignKey(d => d.UserEnvoieDgsn)
                   .HasConstraintName("fk_LotDgsnUserEnvoieDgsn");


           });



        }
    }
}
