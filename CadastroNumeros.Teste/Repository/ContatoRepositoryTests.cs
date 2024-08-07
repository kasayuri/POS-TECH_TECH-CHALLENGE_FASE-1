﻿using CadastroNumeros.Domain.Models;
using CadastroNumeros.Implementations;
using CadastroNumeros.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroNumeros.Repository.Tests
{
    public class ContatoRepositoryTests
    {
        private DbContextOptions<AppDbContext> CreateInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task CriarContato_DeveAdicionarContatoNaDatabase()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = "Carlos Silva",
                    Idade = 28,
                    Email = "carlos.silva@example.com",
                    Telefone = "987654321",
                    CodigoDdd = 21
                };

                var result = await repository.CriarContato(contato);

                Assert.NotNull(result);
                Assert.Equal("Carlos Silva", result.Nome);
                Assert.Equal(1, context.Contatos.Count());
                Assert.Equal("Carlos Silva", context.Contatos.Single().Nome);
            }
        }

        [Fact]
        public async Task RetornarContato_DeveRetornarOContatoPeloId()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ana Souza",
                    Idade = 25,
                    Email = "ana.souza@example.com",
                    Telefone = "123456789",
                    CodigoDdd = 31
                };

                context.Contatos.Add(contato);
                context.SaveChanges();

                var result = await repository.RetornarContato(contato.Id);

                Assert.NotNull(result);
                Assert.Equal("Ana Souza", result.Nome);
            }
        }

        [Fact]
        public async Task ListarContatos_DeveRetornarTodosOsContatos()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contatos = new List<Contato>
                {
                    new Contato { Id = Guid.NewGuid(), Nome = "Pedro Lima", Idade = 30, Email = "pedro.lima@example.com", Telefone = "111111111", CodigoDdd = 11 },
                    new Contato { Id = Guid.NewGuid(), Nome = "Maria Silva", Idade = 35, Email = "maria.silva@example.com", Telefone = "222222222", CodigoDdd = 21 }
                };

                context.Contatos.AddRange(contatos);
                context.SaveChanges();

                var result = await repository.ListarContatos();

                Assert.Equal(2, result.Count());
            }
        }

        [Fact]
        public async Task ListarContatosPorDdd_DeveRetornarOsContatosFiltrandoPeloDdd()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contatos = new List<Contato>
                {
                    new Contato { Id = Guid.NewGuid(), Nome = "Pedro Lima", Idade = 30, Email = "pedro.lima@example.com", Telefone = "111111111", CodigoDdd = 11 },
                    new Contato { Id = Guid.NewGuid(), Nome = "Maria Silva", Idade = 35, Email = "maria.silva@example.com", Telefone = "222222222", CodigoDdd = 21 },
                    new Contato { Id = Guid.NewGuid(), Nome = "José Almeida", Idade = 40, Email = "jose.almeida@example.com", Telefone = "333333333", CodigoDdd = 11 }
                };

                context.Contatos.AddRange(contatos);
                context.SaveChanges();

                var result = await repository.ListarContatosPorDdd(11);

                Assert.Equal(2, result.Count());
                Assert.All(result, c => Assert.Equal(11, c.CodigoDdd));
            }
        }

        [Fact]
        public async Task AtualizarContato_DeveAtualizarUmContatoNaDatabase()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pedro Lima",
                    Idade = 30,
                    Email = "pedro.lima@example.com",
                    Telefone = "111111111",
                    CodigoDdd = 11
                };

                context.Contatos.Add(contato);
                context.SaveChanges();

                contato.Nome = "Pedro Silva";
                await repository.AtualizarContato(contato);

                var updatedContato = await context.Contatos.FindAsync(contato.Id);
                Assert.Equal("Pedro Silva", updatedContato.Nome);
            }
        }

        [Fact]
        public async Task DeletarContato_DeveRemoverUmContatoDaDatabase()
        {
            var options = CreateInMemoryOptions();

            using (var context = new AppDbContext(options))
            {
                var repository = new ContatoRepository(context);
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ana Souza",
                    Idade = 25,
                    Email = "ana.souza@example.com",
                    Telefone = "123456789",
                    CodigoDdd = 31
                };

                context.Contatos.Add(contato);
                context.SaveChanges();

                await repository.DeletarContato(contato.Id);

                var deletedContato = await context.Contatos.FindAsync(contato.Id);
                Assert.Null(deletedContato);
            }
        }
    }
}
