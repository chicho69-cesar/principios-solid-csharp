/*O - Principio de Abierto/Cerrado: Este principio consiste en dejar
establecida una entidad de software como una clase, una funcion, etc.
Esta deber quedar abierta para su extension pero cerrada para su 
modificacion, es decir, debemos de trabajar nuestros elementos con la 
intencion de que no tengamos que modificar nada de ellos pero donde
si podamos añadir mas elementos y que nuestro codigo siga funcionado*/

namespace Solid {
    public class Program {
        public static void Main() {
            IEnumerable<IDrink> drinks = new List<IDrink>() {
                new Water() { Name = "Ciel", Price = 12m, Invoice = 1m },
                new Alcohol() { Name = "Corona", Price = 20m, Invoice = 1.16m, Promo = 1.5m },
                new Sugary() { Name = "Sprite", Price = 14m, Invoice = 1m, Expiration = 2.25m }
            };

            var invoice = new Invoice();
            Console.WriteLine($"El total a pagar es: {invoice.GetTotal(drinks):C2}");
        }
    }

    public interface IDrink {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal GetPrice();
    }

    public class Water : IDrink {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }

        public decimal GetPrice() {
            return Price * Invoice;
        }
    }

    public class Alcohol : IDrink {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal Promo { get; set; }

        public decimal GetPrice() {
            return (Price * Invoice) - Promo;
        }
    }

    public class Sugary : IDrink {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal Expiration { get; set; }

        public decimal GetPrice() {
            return (Price * Invoice) - Expiration;
        }
    }

    public class Energizing : IDrink {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }

        public decimal GetPrice() {
            return Price * Invoice;
        }
    }

    public class Invoice {
        public decimal GetTotal(IEnumerable<IDrink> drinks) {
            decimal total = 0;

            foreach (IDrink drink in drinks) {
                total += drink.GetPrice();
            }

            return total;
        }
    }
}