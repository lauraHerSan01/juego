using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 7f;

    // Límites del movimiento en X
    public float leftLimit = 3.3f;
    public float rightLimit = 6.3f;

    void Update()
    {
        float moveX = 0f;

        // Flechas izquierda/derecha
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            moveX = -speed;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            moveX = speed;

        // Movimiento con deltaTime
        Vector3 newPos = transform.position + new Vector3(moveX * Time.deltaTime, 0, 0);

        // Límite exacto entre 3.3 y 6.3
        newPos.x = Mathf.Clamp(newPos.x, leftLimit, rightLimit);

        transform.position = newPos;
    }
}
