/*S - Principio de responsabilidad unica: Este principio nos dice que una
clase deberia de tener una sola responsabilidad, esto ayuda para que si
necesitas hacer un cambio sobre esa responsabilidad o funcionamiento 
solamente tengas que ir a un solo lugar.
Esto ayuda en la reutilizacion de codigo, en pruebas unitarias, darle
mantenimiento a tu codigo y sobre todo llevar a cabo los cambios facilmente.*/

namespace Solid {
    public class Program {
        public static void Main() {
            Beer beer = new("Modelo", "Corona", 5);
            BeerDB db = new(beer);
            BeerRequest beerRequest = new(beer);

            db.Save();
            beerRequest.Send();
        }
    }

    public class Beer {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Alcohol { get; set; }

        public Beer(string Name, string Brand, int Alcohol) {
            this.Name = Name;
            this.Brand = Brand;
            this.Alcohol = Alcohol;
        }
    }

    public class BeerDB {
        private Beer _beer;

        public BeerDB(Beer beer) {
            _beer = beer;
        }

        public void Save() {
            Console.WriteLine($"Guardamos {_beer.Name} y {_beer.Brand}");
        }
    }

    public class BeerRequest {
        private Beer _beer;

        public BeerRequest(Beer beer) {
            _beer = beer;
        }

        public void Send() {
            Console.WriteLine($"Enviamos {_beer.Name}, {_beer.Alcohol} y {_beer.Brand}");
        }
    }
}