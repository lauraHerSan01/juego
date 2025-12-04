using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("Puntuacion", 0);
        int highScore = PlayerPrefs.GetInt("Record", 0);

        scoreText.text = "Puntuacion: " + lastScore;
        highScoreText.text = "Record: " + highScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Juego");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
