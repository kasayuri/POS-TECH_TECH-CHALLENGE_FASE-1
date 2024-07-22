using CadastroNumeros.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace CadastroNumeros.Teste.Data
{
    public class AppDbContextTests
    {
        private MockRepository mockRepository;

        private Mock<DbContextOptions<AppDbContext>> mockDbContextOptions;

        public AppDbContextTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDbContextOptions = this.mockRepository.Create<DbContextOptions<AppDbContext>>();
        }

        private AppDbContext CreateAppDbContext()
        {
            return new AppDbContext(
                this.mockDbContextOptions.Object);
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var appDbContext = this.CreateAppDbContext();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
