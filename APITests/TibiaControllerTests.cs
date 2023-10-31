using Microsoft.AspNetCore.Mvc;
using TibiaAPI.Controllers;

namespace APITests
{
    [TestClass]
    public class TibiaControllerTests
    {
        private TibiaController _tibapicontroller;
        public TibiaControllerTests()
        {
            _tibapicontroller = new TibiaController();
        }

        [TestMethod]
        public async Task NoCharacterNameShouldReturnError()
        {
            //Arrange
            var charName = string.Empty;

            //Act
            var resp = await _tibapicontroller.GetCharInfoAsync(charName);

            //Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(400, ((ObjectResult)resp).StatusCode);
            Assert.AreEqual("Character name must be provided.", ((ObjectResult)resp).Value);
        }
    }
}
