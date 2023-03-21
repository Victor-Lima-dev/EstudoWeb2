using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudoWeb2.Migrations
{
    /// <inheritdoc />
    public partial class adicionarmaterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //adicionar materias com suas respectivas descrições, matematica, portugues, ingles, etc
            migrationBuilder.Sql("INSERT INTO Materias (Nome, Descricao) VALUES ('Matematica', 'Matematica é uma ciência que estuda a quantidade, a forma e a organização da matéria, bem como as relações entre elas. É uma ciência formal, pois utiliza um sistema de símbolos e regras para descrever e interpretar fenômenos naturais.')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome, Descricao) VALUES ('Portugues', 'Português é uma língua romance falada por mais de 250 milhões de pessoas em todo o mundo, sendo a língua oficial de Portugal, Brasil, Angola, Moçambique, Guiné-Bissau, Cabo Verde, São Tomé e Príncipe, Timor-Leste, Macau, Guiné Equatorial, Brasil e Paraguai.')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome, Descricao) VALUES ('Ingles', 'Inglês é uma língua indo-europeia que se tornou a língua franca do mundo. É a língua oficial de mais de 60 países, incluindo os Estados Unidos, o Reino Unido, Canadá, Austrália, Nova Zelândia, Irlanda, África do Sul, Jamaica e Filipinas.')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome, Descricao) VALUES ('Historia', 'História é a ciência que estuda o passado humano, ou seja, o conjunto de fatos e acontecimentos ocorridos no tempo, desde a origem do homem até os dias atuais.')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome, Descricao) VALUES ('Geografia', 'Geografia é uma ciência que estuda a superfície da Terra e os fenômenos que nela ocorrem. É uma ciência social, pois estuda a relação entre o homem e o espaço, e também uma ciência exata, pois utiliza métodos e técnicas de outras ciências, como a matemática, a física e a química.')");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //deletar materias, um só
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome = 'Matematica'");
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome = 'Portugues'");
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome = 'Ingles'");
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome = 'Historia'");
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome = 'Geografia'");
            
        }
    }
}
