using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float destroyY = -12f;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        float speed = GlobalSpeedManager.Instance.globalSpeed;
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }
}
