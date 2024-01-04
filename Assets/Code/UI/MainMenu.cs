using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Patterns.Structural.Composite.Command;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnStartPressedButton);
    }

    private void OnStartPressedButton()
    {
        var loadSceneCommand = new LoadGameSceneCommand();
        /*var compositeCommand = new CompositeCommand();
        compositeCommand.AddCommand(new LoadSceneCommand("Game"));
        compositeCommand.AddCommand(new StartBattleCommand());
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(compositeCommand);*/
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(loadSceneCommand);
    }
}
