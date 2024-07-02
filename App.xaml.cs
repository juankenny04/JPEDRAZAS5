using Semana5.DataAccess;

namespace Semana5
{
    public partial class App : Application
    {
        public static PersonaRepository PersonaRepository { get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Views.Home();
            PersonaRepository = personaRepository;
        }
    }
}
