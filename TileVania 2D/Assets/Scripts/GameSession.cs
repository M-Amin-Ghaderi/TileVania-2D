using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;

        if (gameSessionCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + playerLives;
        scoreText.text = "Score: " + playerScore;
    }

    public void AddToScore(int scoreAmount)
    {
        playerScore += scoreAmount;
        scoreText.text = "Score: " + playerScore;
        
    }


    public void ProccessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
            
        }
        else
        {
            RestartSession();
        }
    }

    public void TakeLife()
    {
        playerLives--;
        livesText.text = "Lives: " + playerLives;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }

    public void RestartSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
