using System.Threading.Tasks;

namespace YevhenUshakov.TestProject.Data
{
    public interface IDatabaseInitializer
    {
        Task Initialize();
    }
}
