using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool GameOver;
    public static bool LevelCompleted;

    public controls Controls;
    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;
    private static int _score;
    public static int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (_score > BestScore)
            {
                BestScore = _score;
            }
        }
    }

    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set;  }

    public void OnPlayerDied()
    {
        //Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        GameOver = true;
        Score = 0;
        Debug.Log("Game over!");
    }

    public void OnPlayerReachedFinish()
    {
        LevelCompletedPanel.SetActive(true);
        LevelCompleted = true;
        LevelIndex++;
        Debug.Log("You won!");
    }
    public int LevelIndex
    {
       get => PlayerPrefs.GetInt(LevelIndexKey, 0);
       private set
       {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
       }
       
    }

    public static int BestScore
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        private set
        {
            PlayerPrefs.SetInt(BestScoreKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";
    private const string BestScoreKey = "BestScore";
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    private void Start()
    {
        //PlayerPrefs.SetInt(LevelIndexKey, value);
        LevelCompleted = false;
        GameOver = false;
        CurrentState = State.Playing;
        Time.timeScale = 1;
    }
    void Update()
    { 
        if ((LevelCompleted && LevelCompletedPanel.active == true) || 
            (GameOver && GameOverPanel.active == true))
        if (Input.GetMouseButton(0) & GameOverPanel == true)
        {  
            //SceneManager.LoadScene(0);
            ReloadLevel();
          
        }
        

    }
}
