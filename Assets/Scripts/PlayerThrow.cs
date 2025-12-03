using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject periodicoPrefab;
    public Transform spawnPoint;
    public float throwSpeed = 8f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LanzarPeriodico();
        }
    }

    void LanzarPeriodico()
    {
        GameObject p = Instantiate(periodicoPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();

        // Lanzarlo hacia la izquierda
        rb.linearVelocity = new Vector2(-throwSpeed, 0);
    }
}
