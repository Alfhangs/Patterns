using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
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

        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadGameSceneCommand());
    }
}
