using UnityEngine;

public class GlobalSpeedManager : MonoBehaviour
{
    public static GlobalSpeedManager Instance;

    public float globalSpeed = 4f;      // velocidad inicial
    public float speedIncreaseRate = 0.5f; // incremento por segundo

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Incremento constante de velocidad
        globalSpeed += speedIncreaseRate * Time.deltaTime;
    }
}
