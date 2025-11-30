
using UnityEngine;

public class CasaSpawner : MonoBehaviour
{
    public GameObject[] casaPrefabs;
    public float spawnRate = 2f;
    public float spawnY = 10f;   // Siempre arriba de la pantalla
    public float laneX = -7f;    // Carril exacto donde deben aparecer

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnCasa();
            timer = 0;
        }
    }

    void SpawnCasa()
    {
        // Elegir una casa al azar
        int randomIndex = Random.Range(0, casaPrefabs.Length);

        // Posición EXACTA del spawn
        Vector3 spawnPos = new Vector3(laneX, spawnY, 0f);

        // Crear la casa
        Instantiate(casaPrefabs[randomIndex], spawnPos, Quaternion.identity);

        Debug.Log("Casa spawneada en: " + spawnPos);
    }
}
