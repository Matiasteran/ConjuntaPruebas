using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestingCliente
{
    public class UnitTest1 : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string BaseUrl = "http://localhost:5015/Cliente";

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void Create_ReturnCreateView()
        {
            _driver.Navigate().GoToUrl("http://localhost:5015/Cliente/Create");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("inputCedula")).SendKeys("1726203936");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputApellidos")).SendKeys("Reyes");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputNombres")).SendKeys("Ariel");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputFechaNacimiento")).SendKeys("01/01/2025");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("inputMail")).SendKeys("ariel@gmail.com");
            _driver.FindElement(By.Id("inputTelefono")).SendKeys("0939304595");
            _driver.FindElement(By.Id("inputDireccion")).SendKeys("Guayllabamba");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("botonGuardar")).Click();
            Thread.Sleep(1000);
            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }

        [Fact]
        public void Test_ActualizarCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);

            var editarBoton = _driver.FindElement(By.Id("btn-editar-1"));
            editarBoton.Click();

            _wait.Until(d => d.FindElement(By.TagName("form"))); 
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).Clear();
            _driver.FindElement(By.Name("Cedula")).SendKeys("1726203936");
            _driver.FindElement(By.Name("Apellidos")).Clear();
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Perez gonzales");
            _driver.FindElement(By.Name("Nombres")).Clear();
            _driver.FindElement(By.Name("Nombres")).SendKeys("Juan Jose");
            _driver.FindElement(By.Name("FechaNacimiento")).Clear();
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("02/02/2000");
            _driver.FindElement(By.Name("Mail")).Clear();
            _driver.FindElement(By.Name("Mail")).SendKeys("juan.perez@example.com");
            _driver.FindElement(By.Name("Telefono")).Clear();
            _driver.FindElement(By.Name("Telefono")).SendKeys("0912345678");
            _driver.FindElement(By.Name("Direccion")).Clear();
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);

            var submitButton = _wait.Until(d => d.FindElement(By.Id("actualizar")));
            Thread.Sleep(1000);
            submitButton.SendKeys(Keys.PageDown);
            submitButton.SendKeys(Keys.PageDown);
            submitButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            submitButton.Click();
            Thread.Sleep(1000);

            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }

        [Fact]
        public void Test_EliminarCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);
            Thread.Sleep(1000);
            var eliminarBoton = _wait.Until(d => d.FindElement(By.Id("btn-eliminar-1")));
            Thread.Sleep(1000);
            eliminarBoton.SendKeys(Keys.PageDown);
            eliminarBoton.SendKeys(Keys.PageDown);
            eliminarBoton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            eliminarBoton.Click();


            var confirmDeleteButton = _wait.Until(d => d.FindElement(By.Id("delete-button")));
            Thread.Sleep(1000);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            confirmDeleteButton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            confirmDeleteButton.Click();
            Thread.Sleep(1000);

            _wait.Until(d => d.Url == BaseUrl);
            Assert.Equal(BaseUrl, _driver.Url);
        }
        [Fact]
        public void Test_VerDetallesCliente()
        {
            _driver.Navigate().GoToUrl(BaseUrl);


           var detallesBoton = _wait.Until(d => d.FindElement(By.Id("btn-detalles-1")));
            Thread.Sleep(1000);
            detallesBoton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            detallesBoton.SendKeys(Keys.PageDown);
            detallesBoton.SendKeys(Keys.PageDown);
            Thread.Sleep(1000);
            detallesBoton.Click();
            Thread.Sleep(1000);

        }
    }
}
