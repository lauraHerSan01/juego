using UnityEngine;

public class InfiniteRoadPerfect : MonoBehaviour
{
    public Transform[] roads;

    private float roadHeight;

    void Start()
    {
        roadHeight = roads[0].GetComponent<SpriteRenderer>().bounds.size.y;

        // Posicionarlas correctamente como antes
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i].position = new Vector3(
                roads[0].position.x,
                roads[0].position.y - (roadHeight * i),
                roads[0].position.z
            );
        }
    }

    void Update()
    {
        float speed = GlobalSpeedManager.Instance.globalSpeed;

        // Mover todas las carreteras hacia abajo
        foreach (Transform road in roads)
        {
            road.position += Vector3.down * speed * Time.deltaTime;

            // Si se salió completamente por abajo → reposicionarla hasta arriba
            if (road.position.y <= -roadHeight)
            {
                road.position += new Vector3(0, roadHeight * roads.Length, 0);
            }
        }
    }
}
