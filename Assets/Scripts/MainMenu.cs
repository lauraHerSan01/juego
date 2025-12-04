using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // Mostrar el highscore guardado
        int highScore = PlayerPrefs.GetInt("Record", 0);
        highScoreText.text = "Record: " + highScore;
    }

    public void PlayGame()
    {
        Debug.Log("BOTÓN FUNCIONA");
        SceneManager.LoadScene("Juego");
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
