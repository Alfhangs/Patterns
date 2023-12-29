using Battle;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInstaller : MonoBehaviour
{
    private async void Start()
    {
        DontDestroyOnLoad(LoadingScreen.instance.gameObject);
        LoadingScreen.instance.Show();

        await LoadScene("Gameplay");

        LoadingScreen.instance.Hide();
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
