
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 2f;
    public float spawnY = 10f;

    private float timer = 0f;

    // Carriles permitidos
    private float[] lanes = new float[] { 3.4f, 6.3f };

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        // Seleccionar prefab aleatorio
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        // Seleccionar carril aleatorio
        float laneX = lanes[Random.Range(0, lanes.Length)];

        // Posición exacta
        Vector3 spawnPos = new Vector3(laneX, spawnY, 0f);

        // Crear obstáculo
        Instantiate(obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);

        Debug.Log("Obstáculo spawneado en: " + spawnPos);
    }
}
