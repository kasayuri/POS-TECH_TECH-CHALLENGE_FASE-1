using CadastroNumeros.Domain.Models;
using Moq;
using System;
using Xunit;

namespace CadastroNumeros.Teste.Models
{
    public class ContatoTests
    {
        private MockRepository mockRepository;



        public ContatoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Contato CreateContato()
        {
            return new Contato();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contato = this.CreateContato();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
