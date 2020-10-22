using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "affilies",
                columns: table => new
                {
                    cin = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Matricule = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    NPension = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prenom = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    date_naissance = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    telephone1 = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    telephone2 = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    sexe = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    adresse = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ville = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    code_postale = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    rib = table.Column<string>(unicode: false, maxLength: 24, nullable: true),
                    rang = table.Column<int>(nullable: true),
                    situation_vital = table.Column<int>(nullable: true),
                    type_affilie = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    num_adherent = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_affile", x => x.cin);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMisAjour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intitule = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_TypeMisAjour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conjointes",
                columns: table => new
                {
                    Cin = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Nom = table.Column<string>(unicode: false, nullable: true),
                    Prenom = table.Column<string>(unicode: false, nullable: true),
                    cinAff = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Sexe = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Observation = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Rang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Conjoint", x => x.Cin);
                    table.ForeignKey(
                        name: "fk_CinAffConjoint",
                        column: x => x.cinAff,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(unicode: false, nullable: true),
                    Prenom = table.Column<string>(unicode: false, nullable: true),
                    Cin = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    cinAff = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Sexe = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Observation = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Rang = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Enfant", x => x.id);
                    table.ForeignKey(
                        name: "fk_CinAffEnfant",
                        column: x => x.cinAff,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avance_cheque",
                columns: table => new
                {
                    id_avance_cheque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cin_av = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    montant_av = table.Column<double>(unicode: false, maxLength: 20, nullable: false),
                    date_avance_ = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    user_avance = table.Column<string>(nullable: true),
                    date_saisie = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    obser = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avance_cheque", x => x.id_avance_cheque);
                    table.ForeignKey(
                        name: "fk_avance_cheque_cin",
                        column: x => x.cin_av,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_avance",
                        column: x => x.user_avance,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cartes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cinAff = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DateArrive = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    DateEnvoie = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    NomPoretur = table.Column<string>(unicode: false, nullable: true),
                    CinPorteur = table.Column<string>(unicode: false, nullable: true),
                    Disponible = table.Column<bool>(unicode: false, nullable: false),
                    UserReception = table.Column<string>(nullable: true),
                    UserEnvoie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Carte", x => x.id);
                    table.ForeignKey(
                        name: "fk_UserEnvoieCarte",
                        column: x => x.UserEnvoie,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UseReceptionCarte",
                        column: x => x.UserReception,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_CinCarte",
                        column: x => x.cinAff,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cumule_qp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cin = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    montant = table.Column<double>(unicode: false, maxLength: 50, nullable: false),
                    observation = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IdUser = table.Column<string>(nullable: true),
                    date_affectation = table.Column<DateTime>(type: "date", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cumuleQp", x => x.id);
                    table.ForeignKey(
                        name: "fk_affilieCumuleQp",
                        column: x => x.cin,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_userCumuleQp",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "echeance",
                columns: table => new
                {
                    code_echance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date_debut = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    date_fin = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_code_echance_qp", x => x.code_echance);
                    table.ForeignKey(
                        name: "fk_userDebutEcheance",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotDgsns",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserDebutDgsn = table.Column<string>(nullable: true),
                    UserEnvoieDgsn = table.Column<string>(nullable: true),
                    DateDebut = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Datefin = table.Column<DateTime>(type: "date", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_LotDgsn", x => x.id);
                    table.ForeignKey(
                        name: "fk_lotDgsnUserDebutDgsn",
                        column: x => x.UserDebutDgsn,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_LotDgsnUserEnvoieDgsn",
                        column: x => x.UserEnvoieDgsn,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotMisAjours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateDebut = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    UserDebut = table.Column<string>(nullable: true),
                    DateEnvoie = table.Column<DateTime>(type: "date", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_LotMisAjour", x => x.Id);
                    table.ForeignKey(
                        name: "fk_UserDebutLotMAJ",
                        column: x => x.UserDebut,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "qp_mois",
                columns: table => new
                {
                    id_pai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cin_qp = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    date_ = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    QP = table.Column<double>(unicode: false, maxLength: 50, nullable: true),
                    rcar = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    type_pai = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    code_echance_qp_mois = table.Column<int>(nullable: true),
                    code_303 = table.Column<double>(unicode: false, maxLength: 50, nullable: true),
                    code_304 = table.Column<double>(unicode: false, maxLength: 50, nullable: true),
                    id_user = table.Column<string>(nullable: true),
                    date_saisie = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    observation = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    cin_paiement = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pai_", x => x.id_pai);
                    table.ForeignKey(
                        name: "fk_affilies_qp_mois",
                        column: x => x.cin_qp,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_code_echance_qp_mois",
                        column: x => x.code_echance_qp_mois,
                        principalTable: "echeance",
                        principalColumn: "code_echance",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_qp_mois",
                        column: x => x.id_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qps",
                columns: table => new
                {
                    N_dossier = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Date_Paiement_Tech = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Date_Paiement_Reel = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    N_CIN = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Frais_engage = table.Column<double>(nullable: true),
                    Remb_AMO = table.Column<double>(nullable: true),
                    Remb_MPSC = table.Column<double>(nullable: true),
                    Total_Remb = table.Column<double>(nullable: true),
                    Observation = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    rang = table.Column<int>(nullable: true),
                    code_echance_ = table.Column<int>(nullable: true),
                    Iduser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_n_dossier", x => x.N_dossier);
                    table.ForeignKey(
                        name: "fk_echance",
                        column: x => x.code_echance_,
                        principalTable: "echeance",
                        principalColumn: "code_echance",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_userQp",
                        column: x => x.Iduser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cin_qp",
                        column: x => x.N_CIN,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DgsnReponses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CinConj = table.Column<string>(unicode: false, nullable: true),
                    DateEnvoie = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    DateReponse = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Reponse = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    IdLotDgsn = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_DgsnReponse", x => x.id);
                    table.ForeignKey(
                        name: "fk_ConjointDgsn",
                        column: x => x.CinConj,
                        principalTable: "Conjointes",
                        principalColumn: "Cin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_LotDgsn",
                        column: x => x.IdLotDgsn,
                        principalTable: "LotDgsns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MisAJours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CinAffilie = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DateMaj = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    TypeMaj = table.Column<int>(unicode: false, nullable: false),
                    Info = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    UserMaj = table.Column<string>(nullable: true),
                    NumLotMaj = table.Column<int>(unicode: false, nullable: false),
                    AvcSCarte = table.Column<bool>(unicode: false, maxLength: 2, nullable: false),
                    NumCarte = table.Column<int>(unicode: false, maxLength: 10, nullable: false),
                    EnCours = table.Column<bool>(unicode: false, maxLength: 2, nullable: false),
                    infoIdentifiant = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_misAjour", x => x.Id);
                    table.ForeignKey(
                        name: "fk_affilieMisAjour",
                        column: x => x.CinAffilie,
                        principalTable: "affilies",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_NumLotMaj",
                        column: x => x.NumLotMaj,
                        principalTable: "LotMisAjours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_TypeMaj",
                        column: x => x.TypeMaj,
                        principalTable: "TypeMisAjour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userMisAjour",
                        column: x => x.UserMaj,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annuler_qp",
                columns: table => new
                {
                    idAnnulation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_pai_annul = table.Column<int>(nullable: true),
                    id_user_annul = table.Column<string>(nullable: true),
                    date_annul = table.Column<DateTime>(type: "date", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_annulationQp", x => x.idAnnulation);
                    table.ForeignKey(
                        name: "fk_id_pai_annul_qp",
                        column: x => x.id_pai_annul,
                        principalTable: "qp_mois",
                        principalColumn: "id_pai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_annul_qp",
                        column: x => x.id_user_annul,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RejetMajs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Boite = table.Column<int>(unicode: false, nullable: false),
                    DateRejet = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    Observation = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    UserRej = table.Column<string>(nullable: true),
                    IdMaj = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_RejmisAjour", x => x.id);
                    table.ForeignKey(
                        name: "fk_MajRejete",
                        column: x => x.IdMaj,
                        principalTable: "MisAJours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userRejMisAjour",
                        column: x => x.UserRej,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorrigeRejets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idRej = table.Column<int>(nullable: false),
                    UserCorrigeRejet = table.Column<string>(nullable: true),
                    DateCorrige = table.Column<DateTime>(type: "date", unicode: false, nullable: false),
                    numLot = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_CorrigeMisAjour", x => x.id);
                    table.ForeignKey(
                        name: "fk_userCorrigeRejMisAjour",
                        column: x => x.UserCorrigeRejet,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_NumLotCorrigeMaj",
                        column: x => x.idRej,
                        principalTable: "RejetMajs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__affilies__D837D024EF0DEB99",
                table: "affilies",
                column: "cin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annuler_qp_id_pai_annul",
                table: "Annuler_qp",
                column: "id_pai_annul");

            migrationBuilder.CreateIndex(
                name: "IX_Annuler_qp_id_user_annul",
                table: "Annuler_qp",
                column: "id_user_annul");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_avance_cheque_cin_av",
                table: "avance_cheque",
                column: "cin_av");

            migrationBuilder.CreateIndex(
                name: "IX_avance_cheque_user_avance",
                table: "avance_cheque",
                column: "user_avance");

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_UserEnvoie",
                table: "Cartes",
                column: "UserEnvoie");

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_UserReception",
                table: "Cartes",
                column: "UserReception");

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_cinAff",
                table: "Cartes",
                column: "cinAff");

            migrationBuilder.CreateIndex(
                name: "IX_Conjointes_cinAff",
                table: "Conjointes",
                column: "cinAff");

            migrationBuilder.CreateIndex(
                name: "IX_CorrigeRejets_UserCorrigeRejet",
                table: "CorrigeRejets",
                column: "UserCorrigeRejet");

            migrationBuilder.CreateIndex(
                name: "IX_CorrigeRejets_idRej",
                table: "CorrigeRejets",
                column: "idRej");

            migrationBuilder.CreateIndex(
                name: "IX_cumule_qp_cin",
                table: "cumule_qp",
                column: "cin");

            migrationBuilder.CreateIndex(
                name: "IX_cumule_qp_IdUser",
                table: "cumule_qp",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DgsnReponses_CinConj",
                table: "DgsnReponses",
                column: "CinConj");

            migrationBuilder.CreateIndex(
                name: "IX_DgsnReponses_IdLotDgsn",
                table: "DgsnReponses",
                column: "IdLotDgsn");

            migrationBuilder.CreateIndex(
                name: "IX_echeance_User",
                table: "echeance",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_cinAff",
                table: "Enfants",
                column: "cinAff");

            migrationBuilder.CreateIndex(
                name: "IX_LotDgsns_UserDebutDgsn",
                table: "LotDgsns",
                column: "UserDebutDgsn");

            migrationBuilder.CreateIndex(
                name: "IX_LotDgsns_UserEnvoieDgsn",
                table: "LotDgsns",
                column: "UserEnvoieDgsn");

            migrationBuilder.CreateIndex(
                name: "IX_LotMisAjours_UserDebut",
                table: "LotMisAjours",
                column: "UserDebut");

            migrationBuilder.CreateIndex(
                name: "IX_MisAJours_CinAffilie",
                table: "MisAJours",
                column: "CinAffilie");

            migrationBuilder.CreateIndex(
                name: "IX_MisAJours_NumLotMaj",
                table: "MisAJours",
                column: "NumLotMaj");

            migrationBuilder.CreateIndex(
                name: "IX_MisAJours_TypeMaj",
                table: "MisAJours",
                column: "TypeMaj");

            migrationBuilder.CreateIndex(
                name: "IX_MisAJours_UserMaj",
                table: "MisAJours",
                column: "UserMaj");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_qp_mois_cin_qp",
                table: "qp_mois",
                column: "cin_qp");

            migrationBuilder.CreateIndex(
                name: "IX_qp_mois_code_echance_qp_mois",
                table: "qp_mois",
                column: "code_echance_qp_mois");

            migrationBuilder.CreateIndex(
                name: "IX_qp_mois_id_user",
                table: "qp_mois",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Qps_code_echance_",
                table: "Qps",
                column: "code_echance_");

            migrationBuilder.CreateIndex(
                name: "IX_Qps_Iduser",
                table: "Qps",
                column: "Iduser");

            migrationBuilder.CreateIndex(
                name: "IX_Qps_N_CIN",
                table: "Qps",
                column: "N_CIN");

            migrationBuilder.CreateIndex(
                name: "IX_RejetMajs_IdMaj",
                table: "RejetMajs",
                column: "IdMaj");

            migrationBuilder.CreateIndex(
                name: "IX_RejetMajs_UserRej",
                table: "RejetMajs",
                column: "UserRej");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annuler_qp");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "avance_cheque");

            migrationBuilder.DropTable(
                name: "Cartes");

            migrationBuilder.DropTable(
                name: "CorrigeRejets");

            migrationBuilder.DropTable(
                name: "cumule_qp");

            migrationBuilder.DropTable(
                name: "DgsnReponses");

            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Qps");

            migrationBuilder.DropTable(
                name: "qp_mois");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RejetMajs");

            migrationBuilder.DropTable(
                name: "Conjointes");

            migrationBuilder.DropTable(
                name: "LotDgsns");

            migrationBuilder.DropTable(
                name: "echeance");

            migrationBuilder.DropTable(
                name: "MisAJours");

            migrationBuilder.DropTable(
                name: "affilies");

            migrationBuilder.DropTable(
                name: "LotMisAjours");

            migrationBuilder.DropTable(
                name: "TypeMisAjour");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
