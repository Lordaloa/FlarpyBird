using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject ResetCanvas;
    public TextMeshProUGUI highscoreText;


    public void Start() {
        highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
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

    [ContextMenu("ResetPrompt")]
    public void resetPrompt() {
        Debug.Log("ResetPrompt");
        MainCanvas.SetActive(false);
        ResetCanvas.SetActive(true);
    }

    [ContextMenu("CancelReset")]
    public void cancelReset() {
        Debug.Log("CancelReset");
        MainCanvas.SetActive(true);
        ResetCanvas.SetActive(false);
    }

    [ContextMenu("Reset")]
    public void reset() {
        Debug.Log("Reset");
        PlayerPrefs.SetInt("highscore",0);
        highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        MainCanvas.SetActive(true);
        ResetCanvas.SetActive(false);
    }
}
