using System;
using Reqnroll;
using TDD.Data;
using TDD.Models;
using FluentAssertions;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using ReqnrollProject1.NewFolder;


namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public InsertStepDefinitions(ScenarioContext scenarioContext)
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


        [Given("El usuario esta en la pagina")]
        public void GivenElUsuarioEstaEnLaPagina()
        {
            _driver.Navigate().GoToUrl("http://localhost:5015/Cliente");
            _test.Log(Status.Pass, "El usuairo navega a la pagina Crud de clientes");
        }

        [When("Llenar los campos dentro del Formulario")]
        public void GivenLlenarLosCamposDentroDelFormulario(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();
            _driver.FindElement(By.Id("btn-crear-cliente")).Click();
            _driver.FindElement(By.Id("inputCedula")).SendKeys(cliente[0].Cedula);
            _driver.FindElement(By.Id("inputApellidos")).SendKeys(cliente[0].Apellidos);
            _driver.FindElement(By.Id("inputNombres")).SendKeys(cliente[0].Nombres);
            _driver.FindElement(By.Id("inputFechaNacimiento")).SendKeys(cliente[0].FechaNacimiento.ToString());
            _driver.FindElement(By.Id("inputMail")).SendKeys(cliente[0].Mail);
            _driver.FindElement(By.Id("inputTelefono")).SendKeys(cliente[0].Telefono);
            _driver.FindElement(By.Id("inputDireccion")).SendKeys(cliente[0].Direccion);
            _test.Log(Status.Info, "El usuario rellena los campos");
        }

        [When("Dar click en el boton de guardar")]
        public void WhenRegistroIngresadpsEnLaBDD(DataTable dataTable)
        {         
            _driver.FindElement(By.Id("botonGuardar")).Click();
            _test.Log(Status.Info, "El usuario da click en guardar");

        }

        
        [Then("El resultado se ve reflejado en la tabla")]
        public void ThenElResultadoDelIngresoEnLaBDD(DataTable dataTable)
        {
            try
            {
                bool isErrorVisible = _driver.Url.Equals("http://localhost:5015/Cliente");
                Thread.Sleep(5000);
                if (isErrorVisible)
                {
                    _test.Log(Status.Pass, "Usuario Guardado");
                }
                else
                {
                    _test.Log(Status.Fail, "Usuario no Guardado");
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