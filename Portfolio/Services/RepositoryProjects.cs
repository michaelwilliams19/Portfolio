using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IRepositoryProjects
    {
        List<ProyectViewModel> GetAllProyects();
    }

    public class RepositoryProjects : IRepositoryProjects
    {
        public List<ProyectViewModel> GetAllProyects()
        {
            return new List<ProyectViewModel>()
            {
                new ProyectViewModel()
                {
                    Titulo = "C&S Informatica S.A",
                    Descripcion = "Consultora de servicios",
                    Link = "https://cys.com.ar",
                    ImagenURL = "/images/reddit.png"
                },
                 new ProyectViewModel()
                {
                    Titulo = "Axoft S.A",
                    Descripcion = "Tango software",
                    Link = "https://axoft.com.ar",
                    ImagenURL = "/images/amazon.png"
                },
                  new ProyectViewModel()
                {
                    Titulo = "SOUTHWORKS",
                    Descripcion = "Software factory",
                    Link = "https://southworks.com",
                    ImagenURL = "/images/steam.png"
                },
                  new ProyectViewModel()
                {
                    Titulo = "PRUEBA",
                    Descripcion = "Software factory",
                    Link = "https://southworks.com",
                    ImagenURL = "/images/steam.png"
                }
            };
        }
    }
}
