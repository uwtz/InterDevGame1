using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length;
    Vector3 startPos;
    Camera cam;
    [Range(0,1)]
    public float hParallaxEffect;
    [Range(0, 1)]
    public float vParallaxEffect;

    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float hDist = (cam.transform.position.x * hParallaxEffect);
        float vDist = (cam.transform.position.y * vParallaxEffect);
        transform.position = new Vector3(startPos.x + hDist, startPos.y + vDist, transform.position.z);
    }
}
