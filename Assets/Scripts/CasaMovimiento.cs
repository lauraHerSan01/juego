using UnityEngine;

public class CasaMovimiento : MonoBehaviour
{
    public float moveSpeed = 4f;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }
}
