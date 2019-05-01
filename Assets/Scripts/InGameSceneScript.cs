using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameSceneScript : MonoBehaviour
{
    #region Serialized Fields
    // Scriptable objects
    [SerializeField]
    NextSceneToLoad scene;

    // Sprites
    [SerializeField]
    Sprite RockImg;
    [SerializeField]
    Sprite PaperImg;
    [SerializeField]
    Sprite ScissorsImg;
    [SerializeField]
    Sprite QuestionMarkImg;

    // Image objects refernces
    [SerializeField]
    Image playerMoveImg;
    [SerializeField]
    Image computerMoveImg;

    // Score Text
    [SerializeField]
    Text playerScoreTxt;
    [SerializeField]
    Text computerScoreTxt;
    #endregion

    private RockPaperScissorsEnum PlayerMove { get; set; }
    private RockPaperScissorsEnum ComputerMove { get; set; }
    private bool IsProcessingMoves { get; set; }
    private int CurrentBattleIndex { get; set; }

    void Start()
    {
        IsProcessingMoves = false;
        ComputerMove = RockPaperScissorsEnum.UnknownMove;
        PlayerMove = RockPaperScissorsEnum.UnknownMove;
        CurrentBattleIndex = 0;
    }

    void Update()
    {
        if(CurrentBattleIndex < GameScore.NumberOfMatches) // Battle on going
        {
            InGameLoop();
        }
        else // Game over
        {
            LoadGameOverScene();
        }
    }

    private void InGameLoop()
    {
        // If Player already made a move, then don't get input
        if (!IsProcessingMoves)
        {
            PlayerMove = GetPlayerMove();
            // If player made a move, start procossing moves
            if (PlayerMove != RockPaperScissorsEnum.UnknownMove)
            {
                IsProcessingMoves = true;
                ComputerMoveAndProcessGame();
            }
        }
    }

    /// <summary>
    /// Gets players move 
    /// </summary>
    /// <returns></returns>
    private RockPaperScissorsEnum GetPlayerMove()
    {
        if (Input.GetKeyDown(InputConfig.Rock))
        {
            return RockPaperScissorsEnum.Rock;
        }
        else if (Input.GetKeyDown(InputConfig.Paper))
        {
            return RockPaperScissorsEnum.Paper;
        }
        else if (Input.GetKeyDown(InputConfig.Scissors))
        {
            return RockPaperScissorsEnum.Scissors;
        }
        else
        {
            return RockPaperScissorsEnum.UnknownMove;
        }
    }

    /// <summary>
    /// Main action after player a move
    /// CPU istantly makes a moves, thus game will process results and determines the winner
    /// </summary>
    private void ComputerMoveAndProcessGame()
    {
        // CPU makes a move
        ComputerMove = (RockPaperScissorsEnum)UnityEngine.Random.Range(0, 3); 
        // Display Moves
        DisplayMove(ComputerMove, computerMoveImg);
        DisplayMove(PlayerMove, playerMoveImg);
        // Process result
        if (GameResultForPlayer == GameResultEnum.Won)
        {
            GameScore.PlayerWon();
        }
        else if(GameResultForPlayer == GameResultEnum.Lost)
        {
            GameScore.ComputerWon();
        }
        else
        {
            // Tie Senario
        }
        DisplayResult(); // Display scores
        Invoke("EndProcessAndResetGame", 2.2f); // Reset game in about 2 seconds
    }

    /// <summary>
    /// Display the player's/CPU's move in screen
    /// </summary>
    /// <param name="move">"Hand sign" aka the move</param>
    /// <param name="img">The player's/CPU's move displayer to load the sprite to</param>
    private void DisplayMove(RockPaperScissorsEnum move, Image img)
    {
        switch (move)
        {
            case RockPaperScissorsEnum.Rock:
                {
                    img.sprite = RockImg;
                    break;
                }
            case RockPaperScissorsEnum.Paper:
                {
                    img.sprite = PaperImg;
                    break;
                }
            case RockPaperScissorsEnum.Scissors:
                {
                    img.sprite = ScissorsImg;
                    break;
                }
        }
    }

    /// <summary>
    /// Display both players current scores
    /// </summary>
    private void DisplayResult()
    {
        playerScoreTxt.text = GameScore.GetPlayerScore().ToString();
        computerScoreTxt.text = GameScore.GetComputerScore().ToString();
    }

    /// <summary>
    /// Getter property only that checks if human player won,Lost Or got a tie
    /// </summary>
    private GameResultEnum GameResultForPlayer
    {
        get
        {
            int processMoves = (int)PlayerMove - (int)ComputerMove;
            if (processMoves == 1 || /* Counter values are always bigger than 1 from the previous enum value */
                processMoves == -2 /* An expection that a player can also win: Rock(0) - Scissors(2) = -2 */ )
            {
                return GameResultEnum.Won;
            }
            else if(processMoves == 0 /* Both players made the same move */)
            {
                return GameResultEnum.Tie;
            }
            else // In any other case, Player lost
            {
                return GameResultEnum.Lost;
            }
        }
    }

    /// <summary>
    /// End process of game and lets player insert input again in Update function
    /// Also Resets both players moves
    /// </summary>
    private void EndProcessAndResetGame()
    {
        IsProcessingMoves = false;
        playerMoveImg.sprite = QuestionMarkImg;
        computerMoveImg.sprite = QuestionMarkImg;
        ComputerMove = RockPaperScissorsEnum.UnknownMove;
        PlayerMove = RockPaperScissorsEnum.UnknownMove;
        CurrentBattleIndex++; // Incrament to the next battle
    }

    /// <summary>
    /// Loads Game Over screen
    /// </summary>
    public void LoadGameOverScene()
    {
        Utils.SwitchAndLoadScene(scene.SceneName);
    }
}
