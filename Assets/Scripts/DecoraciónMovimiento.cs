using UnityEngine;

public class DecoracionMovimiento : MonoBehaviour
{
    public float speed = 4f; // Igual que tus casas

    void Update()
    {
        float speed = GlobalSpeedManager.Instance.globalSpeed;
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -15f)
            Destroy(gameObject);
    }
}
