using UnityEngine;

public class Hand : MonoBehaviour
{
    GameManager gm;
    public void CallSetHeliAnimatorSpd(float f)
    {
        gm.SetHeliAnimatorSpd(f);
    }
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
