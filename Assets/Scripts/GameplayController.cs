using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private GameObject bird;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameoverPanel, pausePanel;

    [SerializeField]
    private Image medal;

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }

    public void Instruction()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
        bird.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowDiePanel(int score)
    {
        gameoverPanel.SetActive(true);
        endScoreText.text = score.ToString();
        if (GameManager.instance != null)
        {

            int highScore = GameManager.instance.GetHighScore();
            if (highScore < score)
            {
                highScore = score;
            }
            bestScoreText.text = highScore.ToString();
            GameManager.instance.SetHighScore(highScore);

            // TODO: change icon medal
            if (highScore < 1)
            {
                medal.sprite = Resources.Load("orange medal", typeof(Sprite)) as Sprite;
            }
            else if (highScore < 2)
            {
                medal.sprite = Resources.Load("white medal", typeof(Sprite)) as Sprite;
            }
            else
            {
                medal.sprite = Resources.Load("yellow medal", typeof(Sprite)) as Sprite;
            }
        }
    }

    public void RestartAndResume() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        if (BirdController.instance != null && BirdController.instance.isAlive)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
