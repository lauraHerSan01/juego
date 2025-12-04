
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 7f;
    public float leftLimit = 3.3f;
    public float rightLimit = 6.3f;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) moveX = -speed;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) moveX = speed;

        Vector3 newPos = transform.position + new Vector3(moveX * Time.deltaTime, 0, 0);
        newPos.x = Mathf.Clamp(newPos.x, leftLimit, rightLimit);
        transform.position = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
