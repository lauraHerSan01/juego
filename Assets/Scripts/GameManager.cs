using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // Guardar la puntuación actual como "Puntuacion" (por si algo no la guardó antes)
        if (ScoreManager.Instance != null)
            PlayerPrefs.SetInt("Puntuacion", ScoreManager.Instance.score);

        // Actualizar record (seguro)
        int current = PlayerPrefs.GetInt("Puntuacion", 0);
        int record = PlayerPrefs.GetInt("Record", 0);
        if (current > record) PlayerPrefs.SetInt("Record", current);

        // Cargar la escena GameOver (asegúrate que la escena "GameOver" está en Build Settings)
        SceneManager.LoadScene("GameOver");
    }

    // Opción para reiniciar (desde UI)
    public void Restart()
    {
        isGameOver = false;
        SceneManager.LoadScene("Juego");
    }
}
