using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanhiaAereas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanhiaAereas", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localizacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacaos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Markups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PercentualAereo = table.Column<float>(type: "float", nullable: false),
                    PercentualCarro = table.Column<float>(type: "float", nullable: false),
                    PercentualHotel = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markups", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aeroportos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroportos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeroportos_Localizacaos_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(type: "longtext", nullable: false),
                    Marca = table.Column<string>(type: "longtext", nullable: false),
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<float>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Localizacaos_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Localizacaos_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aereos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AeroportoOrigemId = table.Column<int>(type: "int", nullable: false),
                    AeroportoDestinoId = table.Column<int>(type: "int", nullable: false),
                    CompanhiaAereaId = table.Column<int>(type: "int", nullable: false),
                    Partida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Chegada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Classe = table.Column<string>(type: "longtext", nullable: false),
                    Preco = table.Column<float>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aereos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aereos_Aeroportos_AeroportoDestinoId",
                        column: x => x.AeroportoDestinoId,
                        principalTable: "Aeroportos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aereos_Aeroportos_AeroportoOrigemId",
                        column: x => x.AeroportoOrigemId,
                        principalTable: "Aeroportos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aereos_CompanhiaAereas_CompanhiaAereaId",
                        column: x => x.CompanhiaAereaId,
                        principalTable: "CompanhiaAereas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false),
                    Capacidade = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Preco = table.Column<float>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quartos_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aereos_AeroportoDestinoId",
                table: "Aereos",
                column: "AeroportoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aereos_AeroportoOrigemId",
                table: "Aereos",
                column: "AeroportoOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Aereos_CompanhiaAereaId",
                table: "Aereos",
                column: "CompanhiaAereaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aeroportos_LocalizacaoId",
                table: "Aeroportos",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_LocalizacaoId",
                table: "Carros",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocalizacaoId",
                table: "Hotels",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_HotelId",
                table: "Quartos",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aereos");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Markups");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Aeroportos");

            migrationBuilder.DropTable(
                name: "CompanhiaAereas");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Localizacaos");
        }
    }
}
