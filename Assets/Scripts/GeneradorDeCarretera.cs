using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeCarretera : MonoBehaviour
{
    [Header("Tus Prefabs de Carretera")]
    public GameObject[] prefabsDeTramos;

    [Header("Configuración Crítica")]
    public float alturaDelTramo = 10.0595f; 
    public int tramosEnPantalla = 5;        

    private List<GameObject> tramosActivos = new List<GameObject>();

    void Start()
    {
        float mitadTramo = alturaDelTramo / 2f;

        GenerarTramo(mitadTramo, 0);

        for (int i = 1; i < tramosEnPantalla; i++)
        {
            GenerarTramo(mitadTramo + i * alturaDelTramo);
        }
    }

    void Update()
    {
        LimpiarLista();

        if (tramosActivos.Count < tramosEnPantalla)
        {
            if (tramosActivos.Count == 0) return;

            GameObject ultimoTramo = tramosActivos[tramosActivos.Count - 1];

            float nuevaPosicionY = ultimoTramo.transform.position.y + alturaDelTramo;

            
            GenerarTramo(nuevaPosicionY);
        }
    }

    void GenerarTramo(float posicionY, int indiceFijo = -1)
    {
        int indexAleatorio;

        if (indiceFijo != -1)
        {
            indexAleatorio = indiceFijo; 
        }
        else
        {
            indexAleatorio = UnityEngine.Random.Range(1, prefabsDeTramos.Length);
        }

        GameObject tramoElegido = prefabsDeTramos[indexAleatorio];

        // Instanciarlo en el mundo
        Vector3 posicionSpawn = new Vector3(0, posicionY, 0);
        GameObject nuevoTramo = Instantiate(tramoElegido, posicionSpawn, Quaternion.identity);

        // Añadirlo a nuestra lista de control
        tramosActivos.Add(nuevoTramo);
    }

    void LimpiarLista()
    {
        if (tramosActivos.Count > 0 && tramosActivos[0] == null)
        {
            tramosActivos.RemoveAt(0);
        }
    }
}