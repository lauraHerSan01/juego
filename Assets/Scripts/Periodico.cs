
using UnityEngine;

public class Periodico : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Toqué: " + collision.name);

        if (collision.CompareTag("Casa"))
        {
            Debug.Log("Casa detectada");
            ScoreManager.Instance.AddPoint();
            Destroy(gameObject);
        }
    }

}
