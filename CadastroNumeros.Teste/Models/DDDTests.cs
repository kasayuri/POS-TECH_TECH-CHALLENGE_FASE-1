using CadastroNumeros.Domain.Models;
using Moq;
using System;
using Xunit;

namespace CadastroNumeros.Teste.Models
{
    public class DDDTests
    {
        private MockRepository mockRepository;



        public DDDTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private DDD CreateDDD()
        {
            return new DDD();
        }

        [Fact]
        public void IsValid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dDD = this.CreateDDD();
            string Codigo = null;

            // Act
            var result = dDD.IsValid(
                Codigo);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dDD = this.CreateDDD();

            // Act
            var result = dDD.ToString();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
