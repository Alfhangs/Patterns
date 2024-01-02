using Patterns.Decoupling.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInstaller : GeneralInstaller
{

    protected override async void DoStart()
    {
        await LoadNextScene();
    }
    protected override void DoInstallDependencies()
    {
    }

    private async Task LoadNextScene()
    {
        await LoadScene("Gameplay");

        ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
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