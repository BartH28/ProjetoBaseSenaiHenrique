
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patriomonio.Teste.Controllers
{
    public class LoginControllerTestes
    {
        [Fact]
        public void Deve_Retornar_Usuario_Invalido()
        {
            //Arrage
            var fakerepo = new Mock<IUsuarioRepository>();
            fakerepo
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            var fakeviewmodel = new LoginViewModel();

            fakeviewmodel.Email = "henrique@email.com";
            fakeviewmodel.Senha = "123456789";

            var controller = new LoginController(fakerepo.Object);
            //Act
            var resultado = controller.Login(fakeviewmodel);
            //Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_Usuario_Valido()
        {
            //Arrage
            Usuario fakeusuario = new Usuario();
            fakeusuario.Email = "henrique@email.com";
            fakeusuario.Senha = "123456789";

            var fakerepo = new Mock<IUsuarioRepository>();
            fakerepo
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(fakeusuario);

            var fakeviewmodel = new LoginViewModel();

            fakeviewmodel.Email = "henrique@email.com";
            fakeviewmodel.Senha = "123456789";

            var controller = new LoginController(fakerepo.Object);
            //Act
            var resultado = controller.Login(fakeviewmodel);
            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
