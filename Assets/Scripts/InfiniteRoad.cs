using UnityEngine;

public class InfiniteRoadPerfect : MonoBehaviour
{
    public float speed = 4f;
    public Transform[] roads;

    public float extraOffset = 1f; // Se destruye más abajo del borde

    private float roadHeight;
    private float globalY; // posición global del scroll

    void Start()
    {
        // Altura real de la carretera
        roadHeight = roads[0].GetComponent<SpriteRenderer>().bounds.size.y;

        // Acomodar las carreteras de forma PERFECTA
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i].position = new Vector3(
                roads[0].position.x,
                roads[0].position.y - (roadHeight * i),
                roads[0].position.z
            );
        }

        globalY = roads[0].position.y;
    }

    void Update()
    {
        // Movemos TODAS las carreteras con UNA MISMA posición global
        globalY -= speed * Time.deltaTime;

        for (int i = 0; i < roads.Length; i++)
        {
            float newY = globalY - (roadHeight * i);

            // Aquí aplicamos el offset extra
            if (newY <= -roadHeight - extraOffset)
            {
                globalY += roadHeight;
                newY = globalY - (roadHeight * i);
            }

            roads[i].position = new Vector3(
                roads[i].position.x,
                newY,
                roads[i].position.z
            );
        }
    }
}
