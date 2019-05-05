using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour
{
    [SerializeField]
    NextSceneToLoad scene;
    [SerializeField]
    Text gameResult;

    private void Start()
    {
        gameResult.text = GameScore.FinalResult();
    }

    public void QuitGame()
    {
        Utils.EndGameApp();
    }
    
    /// <summary>
    /// Resets game
    /// </summary>
    public void ResetGame()
    {
        GameScore.ResetScore();
        Utils.SwitchAndLoadScene(scene.SceneBuildIndex);
    }
}
