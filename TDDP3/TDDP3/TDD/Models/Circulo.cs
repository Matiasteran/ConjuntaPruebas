namespace TDD.Models
{
    public class Circulo
    {
        public double radio { get; set; }
        public double pi { get; set; }

        public double calcularArea()
        {
            return radio*radio*pi;
        }

        public Circulo() { }

    }
}
