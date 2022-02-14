using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patriomonio.Teste.Utils
{
    public class CriptografiaTestes
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_Bcrypt()
        {
            //Pre-Condição (Arrange)
            var senha = Criptografia.GerarHash("12345678");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");
            //Procedimento (Act)
            var retorno = regex.IsMatch(senha);
            //Resultado Esperado (Assert)
            Assert.True(retorno);

        }

        [Fact]
        public void Deve_Retornar_Comparacao_Valida()
        {
            //Arrange
            var senha = "123456789";
            var hashBanco = "$2a$11$QMNp7Ofs3XboNhuT7bLmZOBUUU4mzmM1cCzcqHqB9GFrtSAFYTJyC";
            //Act
            var comparacao = Criptografia.ValidarHash(senha, hashBanco);
            //Assert
            Assert.True(comparacao);
        }
    }
}
