using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ZombieAttackGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    public GameObject gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        IncreaseScore(0);
        gameOverObject.SetActive(false);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
