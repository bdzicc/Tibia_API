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


        [TestMethod]
        public async Task InvalidCharacterNameShouldReturnError()
        {
            //Arrange
            var charName = "invalidcharactername";

            //Act
            var resp = await _tibapicontroller.GetCharInfoAsync(charName);

            //Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(400, ((ObjectResult)resp).StatusCode);
            Assert.AreEqual("Invalid character name.", ((ObjectResult)resp).Value);
        }


        [TestMethod]
        public async Task ValidCharacterNameShouldReturnSuccessResponse()
        {
            //Arrange
            var charName = "Sunrise";

            //Act
            var resp = await _tibapicontroller.GetCharInfoAsync(charName);

            //Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(200, ((ObjectResult)resp).StatusCode);
            Assert.IsTrue(Convert.ToString(((ObjectResult)resp).Value)?.Contains($"\"Name\": \"{charName}\""));
        }
    }
}
