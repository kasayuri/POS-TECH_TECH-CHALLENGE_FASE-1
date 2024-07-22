using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace CadastroNumeros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_DDDs_DDDId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "_DDD",
                table: "DDDs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DDDs",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "DDDId",
                table: "Contatos",
                newName: "DDD");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_DDDId",
                table: "Contatos",
                newName: "IX_Contatos_DDD");

            migrationBuilder.AddColumn<string>(
                name: "Regiao",
                table: "DDDs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_DDDs_DDD",
                table: "Contatos",
                column: "DDD",
                principalTable: "DDDs",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData("DDDs", columns: new string[] { "Codigo", "Regiao" },
                values: new object[,]
                {
                    {11,"São Paulo (capital e região metropolitana)" },
                    {12,"São Paulo (Vale do Paraíba)" },
                    {13,"São Paulo(Baixada Santista)" },
                    {14,"São Paulo(Bauru e região)" },
                    {15,"São Paulo(Sorocaba e região)" },
                    {16,"São Paulo(Ribeirão Preto e região)" },
                    {17,"São Paulo(São José do Rio Preto e região)" },
                    {18,"São Paulo(Presidente Prudente e região)" },
                    {19,"São Paulo(Campinas e região)" },
                    {21,"Rio de Janeiro(capital e região metropolitana)" },
                    {22,"Rio de Janeiro(interior norte)" },
                    {24,"Rio de Janeiro(interior sul)" },
                    {27,"Espírito Santo(Vitória)" },
                    {28,"Espírito Santo(interior)" },
                    {31,"Minas Gerais(Belo Horizonte)" },
                    {32,"Minas Gerais(Juiz de Fora e região)" },
                    {33,"Minas Gerais(Governador Valadares e região)" },
                    {34,"Minas Gerais(Uberlândia e região)" },
                    {35,"Minas Gerais(Poços de Caldas e região)" },
                    {37,"Minas Gerais(Divinópolis e região)" },
                    {38,"Minas Gerais(Montes Claros e região)" },
                    {41,"Paraná(Curitiba)" },
                    {42,"Paraná(Ponta Grossa e região)" },
                    {43,"Paraná(Londrina e região)" },
                    {44,"Paraná(Maringá e região)" },
                    {45,"Paraná(Cascavel e região)" },
                    {46,"Paraná(Francisco Beltrão e região)" },
                    {47,"Santa Catarina(Joinville e região)" },
                    {48,"Santa Catarina(Florianópolis e região)" },
                    {49,"Santa Catarina(Chapecó e região)" },
                    {51,"Rio Grande do Sul(Porto Alegre)" },
                    {53,"Rio Grande do Sul(Pelotas e região)" },
                    {54,"Rio Grande do Sul(Caxias do Sul e região)" },
                    {55,"Rio Grande do Sul(Santa Maria e região)" },
                    {61,"Distrito Federal" },
                    {62,"Goiás(Goiânia)" },
                    {63,"Tocantins" },
                    {64,"Goiás(interior)" },
                    {65,"Mato Grosso(Cuiabá)" },
                    {66,"Mato Grosso(interior)" },
                    {67,"Mato Grosso do Sul" },
                    {68,"Acre" },
                    {69,"Rondônia" },
                    {71,"Bahia(Salvador)" },
                    {73,"Bahia(sul)" },
                    {74,"Bahia(norte)" },
                    {75,"Bahia(interior)" },
                    {77,"Bahia(sudeste)" },
                    {79,"Sergipe" },
                    {81,"Pernambuco(Recife)" },
                    {82,"Alagoas" },
                    {83,"Paraíba" },
                    {84,"Rio Grande do Norte" },
                    {85,"Ceará(Fortaleza)" },
                    {86,"Piauí(Teresina)" },
                    {87,"Pernambuco(interior)" },
                    {88,"Ceará(interior)" },
                    {89,"Piauí(interior)" },
                    {91,"Pará(Belém)" },
                    {92,"Amazonas(Manaus)" },
                    {93,"Pará(Santarém)" },
                    {94,"Pará(Marabá)" },
                    {95,"Roraima" },
                    {96,"Amapá" },
                    {97,"Amazonas(exceto Manaus)" },
                    {98,"Maranhão(São Luís)" },
                    { 99,"Maranhão(interior)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_DDDs_DDD",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Regiao",
                table: "DDDs");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "DDDs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DDD",
                table: "Contatos",
                newName: "DDDId");

            migrationBuilder.RenameIndex(
                name: "IX_Contatos_DDD",
                table: "Contatos",
                newName: "IX_Contatos_DDDId");

            migrationBuilder.AddColumn<string>(
                name: "_DDD",
                table: "DDDs",
                type: "VARCHAR(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_DDDs_DDDId",
                table: "Contatos",
                column: "DDDId",
                principalTable: "DDDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
