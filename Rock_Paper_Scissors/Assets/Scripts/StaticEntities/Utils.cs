using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static void SwitchAndLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public static void SwitchAndLoadScene(int scenebuildIndex)
    {
        SceneManager.LoadScene(scenebuildIndex, LoadSceneMode.Single);
    }
    public static void EndGameApp()
    {
        Application.Quit();
    }
}
