
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameOver { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // Pausar juego
        Time.timeScale = 0f;

        // (Opcional) Puedes mostrar UI GameOver aquí
        Debug.Log("GAME OVER");

        // Desactivar spawners en la escena si quieres (busca por tag "Spawner")
        var spawners = FindObjectsOfType<MonoBehaviour>();
        foreach (var s in spawners)
        {
            if (s.GetType().Name.Contains("Spawner"))
                s.enabled = false;
        }
    }

    // Reiniciar (llamar desde UI botón o debug)
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
