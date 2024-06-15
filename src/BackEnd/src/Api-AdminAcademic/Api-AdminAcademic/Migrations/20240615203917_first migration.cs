using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_AdminAcademic.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schedules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCarrera = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cursos_carreras_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alumnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alumnos_roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_docentes_roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alumnosXcursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlumno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnosXcursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alumnosXcursos_alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnosXcursos_cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "docentesXcursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDocente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentesXcursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_docentesXcursos_cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_docentesXcursos_docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnos_IdRol",
                table: "alumnos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_alumnosXcursos_IdAlumno",
                table: "alumnosXcursos",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_alumnosXcursos_IdCurso",
                table: "alumnosXcursos",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_IdCarrera",
                table: "cursos",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_docentes_IdRol",
                table: "docentes",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_docentesXcursos_IdCurso",
                table: "docentesXcursos",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_docentesXcursos_IdDocente",
                table: "docentesXcursos",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_IdRol",
                table: "usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumnosXcursos");

            migrationBuilder.DropTable(
                name: "docentesXcursos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "alumnos");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
