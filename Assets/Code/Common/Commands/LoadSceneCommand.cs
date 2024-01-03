using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : ICommand
{
    private readonly string _sceneToLoad;

    public LoadSceneCommand(string sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;
    }

    public async Task Execute()
    {
        var loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
        loadingScreen.Show();
        await LoadScene(_sceneToLoad);
        await Task.Delay(2000);
        loadingScreen.Hide();
    }

    private async Task LoadScene(string sceneName)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

        //Mientas la carga no este lista, se espera a que termine esperando al siguiente frame.
        while (!loadSceneAsync.isDone)
        {
            await Task.Yield();
        }
        //Esperamos un frame mas para evitar posibles fallos
        await Task.Yield();
    }
}
