using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject1.NewFolder;
using TDD.Data;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class EditarStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public EditarStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReports.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }
        [Given("El usuario esta en la pagina para hacer el crud-editar")]
        public void GivenElUsuarioEstaEnLaPaginaParaHacerElCrud_Editar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5015/Cliente");
            _test.Log(Status.Pass, "El usuairo navega a la pagina Crud de clientes");
        }

        [When("Llenar los campos dentro del Formulario editar")]
        public void WhenLlenarLosCamposDentroDelFormularioEditar(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();
            _driver.FindElement(By.Id("btn-editar-1")).Click();
            _driver.FindElement(By.Id("Cedula")).Clear();
            _driver.FindElement(By.Id("Cedula")).SendKeys(cliente[0].Cedula);
            _driver.FindElement(By.Id("Apellidos")).Clear();
            _driver.FindElement(By.Id("Apellidos")).SendKeys(cliente[0].Apellidos);
            _driver.FindElement(By.Id("Nombres")).Clear();
            _driver.FindElement(By.Id("Nombres")).SendKeys(cliente[0].Nombres);
            _driver.FindElement(By.Id("FechaNacimiento")).Clear();
            _driver.FindElement(By.Id("FechaNacimiento")).SendKeys(cliente[0].FechaNacimiento.ToString());
            _driver.FindElement(By.Id("Mail")).Clear();
            _driver.FindElement(By.Id("Mail")).SendKeys(cliente[0].Mail);
            _driver.FindElement(By.Id("Telefono")).Clear();
            _driver.FindElement(By.Id("Telefono")).SendKeys(cliente[0].Telefono);
            _driver.FindElement(By.Id("Direccion")).Clear();
            _driver.FindElement(By.Id("Direccion")).SendKeys(cliente[0].Direccion);
            _test.Log(Status.Info, "El usuairo rellena los campos");
        }

        [When("Dar click en el boton de guardar del formulario editar")]
        public void WhenDarClickEnElBotonDeGuardarDelFormularioEditar()
        {
            Thread.Sleep(10000);
            var submit = _driver.FindElement(By.Id("actualizar"));
            submit.Click();
            _test.Log(Status.Info, "El usuairo da click al boton actualizar");
        }

        [Then("Verificar la url de la pagina")]
        public void ThenVerificarLaUrlDeLaPagina()
        {
            try
            {
                bool isErrorVisible = _driver.Url.Equals("http://localhost:5015/Cliente");
                Thread.Sleep(10000);
                if (isErrorVisible)
                {
                    _test.Log(Status.Pass, "Usuario Actualizado");
                }
                else
                {
                    _test.Log(Status.Fail, "Usuario no Actualizado");
                }
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Error: {ex.Message}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
