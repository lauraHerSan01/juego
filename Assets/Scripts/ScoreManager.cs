using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [HideInInspector] public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("🔊 Sonido de punto")]
    public AudioSource audioSource;   // arrastra aquí tu AudioSource
    public AudioClip pointSound;      // arrastra el sonido aquí

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

        // ▶ Reproducir sonido
        if (audioSource != null && pointSound != null)
        {
            audioSource.PlayOneShot(pointSound);
        }

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
