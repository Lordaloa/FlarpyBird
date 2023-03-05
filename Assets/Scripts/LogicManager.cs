using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highscoreText;
    public GameObject gameOverCanvas;
    public GameObject gameTutorialCanvas;

    public AudioSource PointSound;
    public AudioSource GameOverSound;
    public AudioSource NewGameSound;
    private bool isGameOver;

    private BirdScript bird;

    private int HighScore;


    public void Update()
    {
        highscoreText.text = HighScore.ToString();
        if (bird.getHasGameStarted()) {
            gameTutorialCanvas.SetActive(false);
        }
    }

    public void Start() {
        gameOverCanvas.SetActive(false);
        gameTutorialCanvas.SetActive(true);
        isGameOver = false;
        HighScore = PlayerPrefs.GetInt("highscore");
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }
    // Start is called before the first frame update
    [ContextMenu("AddScore")]
    public void addScore(int score) {
        playerScore += score;
        scoreText.text = playerScore.ToString();
        PointSound.Play();
        if (playerScore > HighScore) {
            HighScore = playerScore;
        }
    }


    [ContextMenu("RestartGame")]
    public void restartGame() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("ToMainMenu")]
    public void toMainMenu() {
        Debug.Log("ToMainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    [ContextMenu("StartGame")]
    public void startGame() {
        Debug.Log("Starting");
        SceneManager.LoadScene("MainGame");
    }

    [ContextMenu("QuitGame")]
    public void quitGame() {
        Debug.Log("Quiting");
        Application.Quit();
    }

     [ContextMenu("GameOver")]
    public void gameOver() {
        if (!isGameOver) {
            isGameOver = true;
            Debug.Log("Game Over");
            PlayerPrefs.SetInt("highscore",HighScore);
            gameOverCanvas.SetActive(true);
            GameOverSound.Play();
        }
    }
}
