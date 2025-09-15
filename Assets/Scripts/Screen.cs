using UnityEngine;

public class Screen : MonoBehaviour
{
    GameManager gm;
    SpriteRenderer sr;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float targetAlpha = 1 - ((float)gm.handSwipeCount / (float)gm.maxHandSwipeCount);
        float alpha = Mathf.MoveTowards(sr.color.a, targetAlpha, .1f*Time.deltaTime);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);

        Debug.Log(targetAlpha);
    }
}
