namespace TDD.Models
{
    public class Calculadora
    {
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }

        public int sumar()
        {
            return firstNumber + secondNumber;
        }
    }
}
