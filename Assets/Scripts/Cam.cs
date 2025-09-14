using UnityEngine;

public class Cam : MonoBehaviour
{
    public float magnitude = 5;

    void Update()
    {
        float noise = Mathf.PerlinNoise1D((Time.time));
        noise = (2 * noise - 1) * magnitude; // remap from 0,1 to -1,1
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, noise);
        Debug.Log(noise);
    }
}
