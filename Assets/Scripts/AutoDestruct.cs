using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float destroyY = -12f; // Punto donde desaparece

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }
}
