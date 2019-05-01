using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneScript : MonoBehaviour
{
    [SerializeField]
    NextSceneToLoad inGameScene;
    [SerializeField]
    NextSceneToLoad settingsScene;

    public void LoadGame()
    {
        Utils.SwitchAndLoadScene(inGameScene.SceneName);
    }

    public void GoToSettingMenu()
    {
        Utils.SwitchAndLoadScene(settingsScene.SceneBuildIndex);
    }

    public void ExitGame()
    {
        Utils.EndGameApp();
    }
}
