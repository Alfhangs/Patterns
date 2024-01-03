using Patterns.Behaviour.Command;
using System.Threading.Tasks;
using Patterns.Decoupling.ServiceLocator;
using UI;

public class HideScreenFadeCommand : ICommand
{
    public async Task Execute()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.GetService<ScreenFade>().Hide();
        await Task.Delay(2000);
    }
}
