using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip[] audios;
    AudioClip currentClip;

    float prevTime = 0f;
    float waitTime = 3f;
    
    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        currentClip = audios[0];
        audioPlayer.PlayOneShot(currentClip);
    }

    private void Update()
    {
        if (Time.time-prevTime >= currentClip.length + waitTime)
        {
            currentClip = audios[Random.Range(0, audios.Length)];
            Debug.Log($"Playing: {currentClip.name}");
            audioPlayer.PlayOneShot(currentClip);

            waitTime = Random.Range(0, 6);
            prevTime = Time.time;
        }
    }
}
