using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 5f;
    public AudioClip jumpSound;

    private bool isJumping = false;
    private bool isDoubleJumping = false;
    private int jumpCount = 0;
    private bool canChangeColor = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public int playVal = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Player movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                if (!isJumping)
                {
                    isJumping = true;
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    PlayJumpSound();
                }
                else if (!isDoubleJumping)
                {
                    isDoubleJumping = true;
                    rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                    PlayJumpSound();
                }

                jumpCount++;
            }
        }

        // Color changing
        if (canChangeColor)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                spriteRenderer.color = Color.red;
                playVal = 1;

                Debug.Log("Player val = " + gameObject.name);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                spriteRenderer.color = Color.green;
                playVal = 2;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                spriteRenderer.color = Color.blue;
                playVal = 3;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isDoubleJumping = false;
            jumpCount = 0;
        }
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
