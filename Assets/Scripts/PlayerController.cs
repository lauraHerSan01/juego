using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadMovimiento = 8f; 
    public float limiteLateralX = 4f;

    private bool estaVivo = true;

    void Update()
    {
        if (!estaVivo) return;

        float inputX = Input.GetAxis("Horizontal");

        float nuevaPosicionX = transform.position.x + inputX * velocidadMovimiento * Time.deltaTime;

        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, -limiteLateralX, limiteLateralX);

        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!estaVivo) return; 

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("¡Choque con Obstáculo! Juego Terminado.");
            GameOver();
        }
    }


    void GameOver()
    {
        estaVivo = false;

        MoverTramo.velocidadGlobal = 0f;

        Time.timeScale = 0f;

    }
}