/*D - Principio de inversion de dependencias: Este principio nos dice 
que los modulos de alto nivel no deben de depender de los modulos de bajo
nivel mas solamente deben de depender de abstracciones.*/

using System.Text.Json;

namespace Solid {
    public class Program {
        public static void Main(string[] args) {
            Init();
        }

        public static async void Init() {
            string origin = @"C:\Cursos\Curso Programacion en C#\Apartado 4 - Conceptos avanzados C#\Principios SOLID\PrincipioDeInversionDeDependencias - D\posts.json";
            string dbPath = @"C:\Cursos\Curso Programacion en C#\Apartado 4 - Conceptos avanzados C#\Principios SOLID\PrincipioDeInversionDeDependencias - D\db.json";
            string httpOrigin = @"https://jsonplaceholder.typicode.com/todos/";

            IInfo info = new InfoByFile(origin);

            Monitor monitor = new Monitor(origin, info);
            monitor.Show();

            FileDB fileDB = new FileDB(dbPath, origin, info);
            await fileDB.Save();
        }
    }

    public class Monitor {
        private string _origin;
        private IInfo _info;

        public Monitor(string origin, IInfo info) {
            _origin = origin;
            _info = info;
        }

        public async void Show() {
            var posts = await _info.Get();

            foreach (var post in posts) {
                Console.WriteLine(post.title);
            }
        }
    }

    public class InfoByFile : IInfo {
        private string _path;

        public InfoByFile(string path) {
            _path = path;
        }

        public async Task<IEnumerable<Post>> Get() {
            var contentStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            IEnumerable<Post> posts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream);
            return posts;
        }
    }

    public class InfoByRequest : IInfo {
        private string _url;

        public InfoByRequest(string url) {
            _url = url;
        }

        public async Task<IEnumerable<Post>> Get() {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_url);
            var stream = await response.Content.ReadAsStreamAsync();
            List<Post> posts = await JsonSerializer.DeserializeAsync<List<Post>>(stream);
            return posts;
        }
    }

    public class FileDB {
        private string _path;
        private string _origin;
        private IInfo _info;

        public FileDB(string path, string origin, IInfo info) {
            this._path = path;
            this._origin = origin;
            this._info = info;
        }

        public async Task Save() {
            var posts = await _info.Get();
            string json = JsonSerializer.Serialize(posts);
            await File.WriteAllTextAsync(_path, json);
        }
    }

    public interface IInfo {
        public Task<IEnumerable<Post>> Get();
    }

    public class Post {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}