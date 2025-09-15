using UnityEngine;

public class Bird : MonoBehaviour
{
    bool played = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!played)
        {
            GetComponent<AudioSource>().Play();
            played = true;
        }
    }
}
