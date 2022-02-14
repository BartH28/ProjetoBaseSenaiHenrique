

using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Xunit;

namespace Patriomonio.Teste.Controllers
{
    public class EquipamentoControllerTestes
    {
        [Fact]
        public void Deve_Retornar_Um_Equipamento_Pelo_Id()
        {
            //Arrange
            var fakerepo = new Mock<IEquipamentoRepository>();

            fakerepo
                .Setup(x => x.BuscarPorID(It.IsAny<int>())).Returns((Equipamento)null);


            var fakeid = 2;
            //Act
            var controller = new EquipamentosController(fakerepo.Object);

            var GetEquipamentoFake = controller.GetEquipamento(fakeid);

            bool resultado = false; 
            if (GetEquipamentoFake != null)
            {
                resultado = true;
            }


            //Assert
            Assert.True(resultado);
        }
    }
}
