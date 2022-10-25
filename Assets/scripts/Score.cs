using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{    
    public Game Game;
    public Text scoreText;
    public Text bestScoreText;

    void Update()
    {
        scoreText.text = Game.Score.ToString();
        bestScoreText.text = $"Best Score {Game.BestScore}";
    }
}
