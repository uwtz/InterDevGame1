using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float magnitude = 100f;
    bool goUp, goLeft, goDown, goRight;
    Animator animator;
    GameManager gm;
    public Rigidbody2D rb;

    private void Start()
    {
        goUp = goLeft = goDown = goRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void Update()
    {
        if (gm.gameState == GameManager.GameState.Fly)
        {
            Vector3 input = new Vector3();
            if (Input.GetKey(KeyCode.W) && goUp) { input.y += 1; }
            if (Input.GetKey(KeyCode.A) && goLeft) { input.x -= 1; }
            if (Input.GetKey(KeyCode.S) && goDown) { input.y -= 1; }
            if (Input.GetKey(KeyCode.D) && goRight) { input.x += 1; }
            input.Normalize();
            input *= magnitude * Time.deltaTime;
            rb.AddForce(input);
            //transform.position += input;

            //animator.SetBool("IsSpinning", input.magnitude > 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Up")) { goUp = false; }
        if (col.CompareTag("Left")) { goLeft = false; }
        if (col.CompareTag("Down")) { goDown = false; }
        if (col.CompareTag("Right")) { goRight = false; }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Up")) { goUp = true; }
        if (col.CompareTag("Left")) { goLeft = true; }
        if (col.CompareTag("Down")) { goDown = true; }
        if (col.CompareTag("Right")) { goRight = true; }
    }
    
}
