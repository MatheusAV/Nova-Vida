using Microsoft.EntityFrameworkCore;
using NovaVidaDomain.Models;
using NovaVidaInfra.Common;
using NovaVidaInfra.Repositories;

namespace NovaVidaRepository.Seeds
{
    public class SeedsRunner : BaseRepository
    {
        public SeedsRunner(DbContextApplication rep) : base(rep)
        {
        }

        public async Task InitializeAsync()
        {
            await InitializeProfessores(_rep);
            await InitializeAlunos(_rep);
            await _rep.SaveChangesAsync();
        }


        private async Task InitializeProfessores(DbContextApplication dbContext)
        {
            var professoresCadastrados = await dbContext.Professores.AnyAsync();
            if (professoresCadastrados)
            {
                return;
            }

            var listaDeProfessores = new List<Professor>
            {

                    new Professor { Nome = "Prof. Ana Teixeira", DataContratacao = new DateTime(2022, 1, 10), Departamento = "Matemática", Materia = "Cálculo" },
                    new Professor { Nome = "Prof. Bruno Gomes", DataContratacao = new DateTime(2022, 2, 15), Departamento = "Física", Materia = "Física Quântica" },
                    new Professor { Nome = "Prof. Carlos Silva", DataContratacao = new DateTime(2022, 3, 20), Departamento = "Literatura", Materia = "Literatura Brasileira" },
                    new Professor { Nome = "Prof. Diana Rocha", DataContratacao = new DateTime(2022, 4, 25), Departamento = "História", Materia = "História Antiga" },
                    new Professor { Nome = "Prof. Eduardo Pereira", DataContratacao = new DateTime(2022, 5, 30), Departamento = "Biologia", Materia = "Biologia Celular" },
                    new Professor { Nome = "Prof. Fernanda Costa", DataContratacao = new DateTime(2022, 6, 5), Departamento = "Química", Materia = "Química Orgânica" },
                    new Professor { Nome = "Prof. Gustavo Martins", DataContratacao = new DateTime(2022, 7, 10), Departamento = "Artes", Materia = "História da Arte" },
                    new Professor { Nome = "Prof. Helena Souza", DataContratacao = new DateTime(2022, 8, 15), Departamento = "Informática", Materia = "Programação" },
                    new Professor { Nome = "Prof. Igor Santos", DataContratacao = new DateTime(2022, 9, 20), Departamento = "Filosofia", Materia = "Ética" },
                    new Professor { Nome = "Prof. Joana Albuquerque", DataContratacao = new DateTime(2022, 10, 25), Departamento = "Educação Física", Materia = "Anatomia Humana" }

            };

            await dbContext.Professores.AddRangeAsync(listaDeProfessores);

        }


        private async Task InitializeAlunos(DbContextApplication dbContext)
        {
            try
            {
                if (await dbContext.Alunos.AnyAsync())
                {
                    return; // Se já existem alunos, não adiciona mais
                }

                var professores = await dbContext.Professores.ToListAsync();
                var alunos = new List<Aluno>();
                Random random = new Random();

                foreach (var professor in professores)
                {
                    // Criar alunos com nomes derivados do nome do professor
                    alunos.AddRange(GenerateAlunosForProfessor(professor, random));
                }

                await dbContext.Alunos.AddRangeAsync(alunos);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private List<Aluno> GenerateAlunosForProfessor(Professor professor, Random random)
        {
            try
            {                
                string[] suffixes = { " Jr.", " Neto", " Filho", " I", " II" };
               
                string[] firstNames = { "Matheus", "João", "Ana", "Lucas", "Sofia" };                
                string lastName = professor.Nome.Split(' ').Last();

                var alunos = new List<Aluno>();
                for (int i = 0; i < 5; i++)
                {
                    var aluno = new Aluno
                    {
                        Nome = $"{firstNames[i]} {lastName}{suffixes[random.Next(suffixes.Length)]}",
                        DataVencimento = new DateTime(2022, i + 1, 10), // Evita datas idênticas
                        ValorMensalidade = 950 + (i * 30), // Varia o valor da mensalidade
                        IdProfessor = professor.ProfessorId
                    };
                    alunos.Add(aluno);
                }
                return alunos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
