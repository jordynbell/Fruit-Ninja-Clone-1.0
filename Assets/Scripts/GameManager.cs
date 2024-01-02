using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPanelScoreText;
    public TextMeshProUGUI gameOverPanelHighscoreText;

    [Header("Fruit Slice Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;

    [Header("Bomb Slice Sounds")]
    public AudioClip bombSound;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        audioSource = GetComponent<AudioSource>();

        gameOverPanel.SetActive(false);

        GetHighscore();

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;

        audioSource.PlayOneShot(bombSound);

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighscoreText.text = "Best: " + PlayerPrefs.GetInt("Highscore").ToString();
        gameOverPanel.SetActive (true);
    }

    public void GoToScene(int sceneId)
    {
        SceneManager.LoadScene(0);
    }

    public void PlayRandomSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

}
