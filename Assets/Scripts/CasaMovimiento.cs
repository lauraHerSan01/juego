using UnityEngine;

public class CasaMovimiento : MonoBehaviour
{

    void Update()
    {
        float speed = GlobalSpeedManager.Instance.globalSpeed;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

}
