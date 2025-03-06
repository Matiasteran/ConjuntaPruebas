namespace TDD.Models
{
    public class RaizNewtonRaphson
    {
        private const double Tolerance = 1e-6
            ;
        public double numero { get; set; }
        public double Sqrt()
        {
            if (numero < 0)
            {
                throw new ArgumentException("No se puede calcular la raíz de un número negativo");
            }

            double x = numero;
            while (Math.Abs(x * x - numero) > Tolerance)
            {
                x = x - (x * x - numero) / (2 * x);
            }
            return x;
        }
    }
}
