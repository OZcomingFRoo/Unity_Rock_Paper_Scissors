using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsScript : MonoBehaviour
{
    //Scriptable object
    [SerializeField]
    NextSceneToLoad StartScene;

    // Inputs to set
    [SerializeField]
    InputField rockInput;
    [SerializeField]
    InputField paperInput;
    [SerializeField]
    InputField scissorsInput;

    // Number of Matches relative objects 
    [SerializeField]
    Slider numberOfMatchesSlider;
    [SerializeField]
    Text numberOfMatchesPreviewDisplayer;

    void Start()
    {
        initUserInterface();
        numberOfMatchesSlider.onValueChanged.AddListener(value => numberOfMatchesPreviewDisplayer.text = ((int)value).ToString());
    }
    
    /// <summary>
    /// Displays the current values set in UI
    /// </summary>
    private void initUserInterface()
    {
        rockInput.text = InputConfig.Rock.ToString();
        paperInput.text = InputConfig.Paper.ToString();
        scissorsInput.text = InputConfig.Scissors.ToString();
        numberOfMatchesSlider.value = GameScore.NumberOfMatches;
        numberOfMatchesPreviewDisplayer.text = GameScore.NumberOfMatches.ToString();
    }

    /// <summary>
    /// Go backs to Start menu without saving the changes
    /// </summary>
    public void CancelSettings()
    {
        Utils.SwitchAndLoadScene(StartScene.SceneBuildIndex);
    }

    /// <summary>
    /// Confirms changes (if valid), and goes back to start menu
    /// </summary>
    public void ConfirmSettings()
    {
        Regex onlyInputLetters = new Regex("^[a-zA-Z]{3}$");
        if(onlyInputLetters.IsMatch(rockInput.text + paperInput.text + scissorsInput.text))
        {
            rockInput.text = rockInput.text.ToUpper();
            paperInput.text = paperInput.text.ToUpper();
            scissorsInput.text = scissorsInput.text.ToUpper();
            GameScore.NumberOfMatches = (byte)numberOfMatchesSlider.value;
            InputConfig.Rock = (KeyCode)Enum.Parse(typeof(KeyCode), rockInput.text);
            InputConfig.Paper = (KeyCode)Enum.Parse(typeof(KeyCode), paperInput.text);
            InputConfig.Scissors = (KeyCode)Enum.Parse(typeof(KeyCode), scissorsInput.text);
            Utils.SwitchAndLoadScene(StartScene.SceneBuildIndex);
        }
        else
        {
            initUserInterface();
        }
    }
}
