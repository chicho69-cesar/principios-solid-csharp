/*I - Principio de segregacion de interfaces: Esta es basicamente la practica
de no tener interfaces muy grandes, esto con el fin de que las clases
que van a implementar estas interfaces no tengan metodos o propiedades
de mas, las cuales no tengan razon para implementarlas.*/

namespace Solid {
    public class Program {
        public static void Main() {
            UserService userService = new UserService();
            userService.Add(new User());
            userService.Update(new User());

            SaleService saleService = new SaleService();
            saleService.Add(new Sale());
        }
    }

    public class UserService : IBasicActions<User>, IEditableActions<User> {
        public User Get(int id) {
            Console.WriteLine("Obtenemos el usuario con id " + id);
            return new User();
        }

        public List<User> GetList() {
            Console.WriteLine("Obtenemos a todos los usuarios");
            return new List<User>();
        }

        public void Add(User entity) {
            Console.WriteLine("Agregamos al usuario");
        }

        public void Update(User entity) {
            Console.WriteLine("Modificamos al usuario");
        }

        public void Delete(User entity) {
            Console.WriteLine("Eliminamos al usuario");
        }
    }

    public class SaleService : IBasicActions<Sale> {
        public Sale Get(int id) => new Sale();

        public List<Sale> GetList() => new List<Sale>();

        public void Add(Sale entity) {
            Console.WriteLine("Agregamos una nueva venta");
        }
    }

    public interface IBasicActions<T> {
        public T Get(int id);
        public List<T> GetList();
        public void Add(T entity);
    }

    public interface IEditableActions<T> {
        public void Update(T entity);
        public void Delete(T entity);
    }

    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Sale {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}