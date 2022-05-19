using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenDeleteMethodIsRun : UsersTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método Delete.")]
        public async Task Is_Possible_Run_Delete_Method()
        {
            #region Testando o retorno True do Delete
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(true);

            _service = _serviceMock.Object;

            var _result = await _service.Delete(UserId);
            Assert.True(_result);
            #endregion

            #region Testando o retorno False do Delete
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);

            _service = _serviceMock.Object;

            _result = await _service.Delete(UserId);
            Assert.False(_result);
            #endregion
        }
    }
}
