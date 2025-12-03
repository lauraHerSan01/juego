using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Puntos: " + score;
    }
}
