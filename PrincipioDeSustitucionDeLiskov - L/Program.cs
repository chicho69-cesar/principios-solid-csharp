/*L - Principio de sustitucion de Liskov: Este principio nos dice que si
tienes una clase padre la cual hereda a una clase hija, la hija no debe
alterar el funcionamiento del padre.
En general este principio se explica teniendo una clase T, con dos clases
que heredan de ella, S1 y S2, cuando creamos un objeto de T que sea S1
y por ende este objeto puede cambiarse de S1 a S2 y este tendria que 
seguir funcionando de la forma que necesitemos*/

namespace Solid {
    public class Program {
        public static void Main() {
            LocalSale sale = new LocalSale(1200, "Cesar", 0.16m);
            sale.Generate();
            sale.CalculateTaxes();
        }
    }

    public abstract class AbstractSale {
        protected decimal amount;
        protected string customer;

        public abstract void Generate();
    }

    public abstract class SaleWithTax : AbstractSale {
        protected decimal taxes;
        public abstract void CalculateTaxes();
    }

    public class LocalSale : SaleWithTax {
        public LocalSale(decimal amount, string customer, decimal taxes) {
            this.amount = amount;
            this.customer = customer;
            this.taxes = taxes;
        }

        public override void Generate() {
            Console.WriteLine("Se genera la venta");
        }

        public override void CalculateTaxes() {
            Console.WriteLine("Se calculan los impuestos");
        }
    }

    public class ForeignSale : AbstractSale {
        public ForeignSale(decimal amount, string customer) {
            this.amount = amount;
            this.customer = customer;
        }

        public override void Generate() {
            Console.WriteLine("Se genera la venta");
        }
    }
}