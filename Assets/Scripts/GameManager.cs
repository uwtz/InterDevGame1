using UnityEngine;


public class GameManager : MonoBehaviour
{
    PlayerMove player;
    Animator heliAnimator;

    Animator handRightAnimator;
    Animator handLeftAnimator;
    enum HandsState { Up, Down };
    HandsState handsState = HandsState.Down;
    public int handSwipeCount = 0;
    public int maxHandSwipeCount = 7;

    public enum GameState { Launch, Fly };
    public GameState gameState = GameState.Launch;

    AudioSource audioPlayer;
    public AudioClip handrub;
    public AudioClip woosh;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        heliAnimator = GameObject.Find("Player").GetComponent<Animator>();
        handRightAnimator = GameObject.Find("HandRight").GetComponent<Animator>();
        handLeftAnimator = GameObject.Find("HandLeft").GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (gameState == GameState.Launch)
        {
            float t = handRightAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            float tt = t > 1 ? 1 : t;

            if (tt > .8f) // limit how often the trigger can be set
            {
                if (Input.GetKeyDown(KeyCode.W) && handsState == HandsState.Down)
                {
                    audioPlayer.PlayOneShot(handrub);
                    handRightAnimator.SetTrigger("Up");
                    handLeftAnimator.SetTrigger("Down");
                    handsState = HandsState.Up;
                    handSwipeCount++;
                    heliAnimator.SetFloat("Spd", 1.5f);
                }
                else if (Input.GetKeyDown(KeyCode.S) && handsState == HandsState.Up)
                {
                    audioPlayer.PlayOneShot(handrub);
                    handRightAnimator.SetTrigger("Down");
                    handLeftAnimator.SetTrigger("Up");
                    handsState = HandsState.Down;
                    handSwipeCount++;
                    heliAnimator.SetFloat("Spd", -1.5f);
                }
            }
        }

    }

    public void SetHeliAnimatorSpd(float f)
    {
        heliAnimator.SetFloat("Spd", f);
        if (handSwipeCount >= maxHandSwipeCount)
        {
            audioPlayer.PlayOneShot(woosh);
            player.rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            player.rb.gravityScale = .01f;
            heliAnimator.SetFloat("Spd", 1f);
            gameState = GameState.Fly;
        }
    }

    private void LateUpdate()
    {
        handRightAnimator.ResetTrigger("Up");
        handRightAnimator.ResetTrigger("Down");
        handLeftAnimator.ResetTrigger("Up");
        handLeftAnimator.ResetTrigger("Down");
    }
}
