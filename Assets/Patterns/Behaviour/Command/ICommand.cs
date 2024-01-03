using System.Threading.Tasks;

namespace Patterns.Behaviour.Command
{
    public interface ICommand
    {
        Task Execute();
    }
}
