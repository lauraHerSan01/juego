
using System.Collections.Generic;
using UnityEngine;

public class ImprovedObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 1.5f;
    public float spawnY = 10f;

    // Carriles
    private float[] lanes = new float[] { 3.4f, 6.3f };

    // Spawn rules
    public int consecutiveLimit = 2;    // cuantas veces seguidas se permite el mismo carril
    public float minVerticalSpacing = 8; // distancia mínima vertical entre obstáculos en mismo carril
    public int maxPerLane = 3; // máximo de obstáculos vivos por carril
    public float spawnCheckRadius = 0.8f; // radio para OverlapCircle que detecta si hay algo en el spawn

    private float timer = 0f;
    private int lastLaneIndex = -1;
    private int lastLaneCount = 0;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0f;
            SpawnRandom();
        }
    }

    void SpawnRandom()
    {
        // intentos para buscar un carril válido
        int maxAttempts = 6;
        int chosenLane = -1;

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int laneIndex = Random.Range(0, lanes.Length);

            // Evitar exceso de repeticiones
            if (laneIndex == lastLaneIndex && lastLaneCount >= consecutiveLimit)
                continue;

            // Contar obstaculos vivos en ese carril
            int countInLane = CountObstaclesInLane(lanes[laneIndex]);
            if (countInLane >= maxPerLane)
                continue;

            // Checar si hay un obstáculo muy cerca en Y en el spawn point
            Vector2 checkPos = new Vector2(lanes[laneIndex], spawnY);
            Collider2D hit = Physics2D.OverlapCircle(checkPos, spawnCheckRadius, LayerMask.GetMask("Default")); // asume Default layer o ajusta
            if (hit != null)
            {
                // si detecta algo, saltar
                continue;
            }

            chosenLane = laneIndex;
            break;
        }

        // Si no encontró lane válido tras intentos, elige el que tenga menos objetos
        if (chosenLane == -1)
        {
            chosenLane = GetLeastCrowdedLaneIndex();
        }

        // Instanciar obstáculo aleatorio en el carril elegido
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(lanes[chosenLane], spawnY + Random.Range(0f, 1.5f), 0f); // pequeño offset vertical aleatorio
        GameObject ob = Instantiate(obstaclePrefabs[randomIndex], spawnPos, Quaternion.identity);

        // asegurar tag y script (opcional)
        ob.tag = "Obstacle";
        if (ob.GetComponent<ObstacleMovement>() == null)
            ob.AddComponent<ObstacleMovement>();

        // actualizar historial de lanes
        if (chosenLane == lastLaneIndex) lastLaneCount++;
        else { lastLaneIndex = chosenLane; lastLaneCount = 1; }

        Debug.Log("Spawn Obstacle at lane " + lanes[chosenLane] + " y=" + spawnPos.y);
    }

    int CountObstaclesInLane(float laneX)
    {
        int count = 0;
        var all = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < all.Length; i++)
        {
            if (Mathf.Abs(all[i].transform.position.x - laneX) < 0.5f)
                count++;
        }
        return count;
    }

    int GetLeastCrowdedLaneIndex()
    {
        int best = 0;
        int bestCount = CountObstaclesInLane(lanes[0]);
        for (int i = 1; i < lanes.Length; i++)
        {
            int c = CountObstaclesInLane(lanes[i]);
            if (c < bestCount) { best = i; bestCount = c; }
        }
        return best;
    }

    // Gizmo para ver spawn checks
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < lanes.Length; i++)
        {
            Gizmos.DrawWireSphere(new Vector3(lanes[i], spawnY, 0f), spawnCheckRadius);
        }
    }
}
