using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlAutumn : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.


    public float moveForce = 300f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 3f;             // The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;           // Array of clips for when the player jumps.
    public float jumpForce = 300f;         // Amount of force added when the player jumps.


    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;          // Whether or not the player is grounded.
    private Animator anim;                  // Reference to the player's animator component.

    //ulang jika mati
    public bool restart;
    Vector2 start;

    public Text scoreText;
    public int totalScoreA = 0;
    public int totalHeartA = 3;
    public int totalFish1A = 0;
    public int totalFish2A = 0;
    private int totalFinishA = 0;

    public Image[] heartPlaceholders;
    public Sprite iconHeart;
    public Sprite iconHeartGrey;
    public GameObject Win, Lose;

    public void SavePlayer()
    {
        SaveSystemAutumn.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerDataAutumn data = SaveSystemAutumn.LoadPlayer();

        totalScoreA = data.totalScoreA;
        totalHeartA = data.totalHeartA;
        totalFish1A = data.totalFish1A;
        totalFish2A = data.totalFish2A;

        Vector3 positionA;
        positionA.x = data.positionA[0];
        positionA.y = data.positionA[1];
        positionA.z = data.positionA[2];
        transform.position = positionA;

    }

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        Time.timeScale = 1f;
        start = transform.position;
        UpdateScoreText();
    }

    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //restart
        if (restart == true)
        {
            transform.position = start;
            restart = false;
        }
        //win or lose
        if (totalHeartA <= 0)
        {
            Time.timeScale = 0f;
            Lose.SetActive(true);
        }
        else if (totalFinishA >= 1)
        {
            Time.timeScale = 0f;
            Win.SetActive(true);
        }

    }

    public void OnChangeHeartTotal(int heartTotalA)
    {
        for (int i = 0; i < heartPlaceholders.Length; ++i)
        {
            if (i < heartTotalA)
                heartPlaceholders[i].sprite = iconHeart;
            else
                heartPlaceholders[i].sprite = iconHeartGrey;
        }
    }

    private void UpdateScoreText()
    {
        string scoreMessage = "" + totalScoreA;
        scoreText.text = scoreMessage;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Fish1"))
        {
            totalFish1A++;
            totalScoreA += 50;
            UpdateScoreText();
            Destroy(hit.gameObject);
        }
        if (hit.CompareTag("Fish2"))
        {
            totalFish2A++;
            totalScoreA += 100;
            UpdateScoreText();
            Destroy(hit.gameObject);
        }
        if (hit.CompareTag("Enemies"))
        {
            totalHeartA--;
            OnChangeHeartTotal(totalHeartA);
            restart = true;
        }
        if (hit.CompareTag("Finish"))
        {
            totalFinishA++;
            Destroy(hit.gameObject);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {

            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        }
        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
        {

            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x)
            * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (jump)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
    }


    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
