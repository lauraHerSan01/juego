using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [HideInInspector] public int score = 0;
    public TextMeshProUGUI scoreText; // asignar en la escena del juego

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        score = 0;
        UpdateUI();
    }

    public void AddPoint()
    {
        score++;
        UpdateUI();

        // Guardar puntuación actual y record
        PlayerPrefs.SetInt("Puntuacion", score);

        int record = PlayerPrefs.GetInt("Record", 0);
        if (score > record)
            PlayerPrefs.SetInt("Record", score);
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Puntos: " + score;
    }
}
