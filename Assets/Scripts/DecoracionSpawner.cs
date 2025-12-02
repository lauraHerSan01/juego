
using UnityEngine;

public class DecoracionSpawner : MonoBehaviour
{
    public GameObject[] decorPrefabs;

    public float spawnRate = 1.2f;      // cada cuánto aparece 1 decoración
    public float spawnY = 10f;          // siempre arriba
    public float minX = -8.5f;
    public float maxX = 0.5f;

    public float minSpacingY = 2f;      // separación mínima vertical
    public float checkRadius = 0.6f;    // para evitar empalmes

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer = 0f;
            TrySpawnDecoracion();
        }
    }

    void TrySpawnDecoracion()
    {
        int attempts = 0;

        while (attempts < 10)  // intenta varias veces hasta encontrar un buen lugar
        {
            attempts++;

            float randomX = Random.Range(minX, maxX);
            float randomY = spawnY + Random.Range(0f, 4f);

            Vector2 pos = new Vector2(randomX, randomY);

            // Revisar si choca con casas o decoraciones
            Collider2D hit = Physics2D.OverlapCircle(pos, checkRadius);

            if (hit != null && (hit.CompareTag("Casa") || hit.CompareTag("Decoracion")))
            {
                // si está ocupado ese espacio → intentar otra posición
                continue;
            }

            // Instanciar prefab aleatorio
            int index = Random.Range(0, decorPrefabs.Length);

            GameObject obj = Instantiate(decorPrefabs[index], pos, Quaternion.identity);
            obj.tag = "Decoracion";

            // Asegurar movimiento
            if (obj.GetComponent<DecoracionMovimiento>() == null)
                obj.AddComponent<DecoracionMovimiento>();

            // Si llegó aquí, se hizo spawn correctamente
            return;
        }
    }

    // Gizmo para guiar
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minX, spawnY, 0), new Vector3(maxX, spawnY, 0));
    }
}
