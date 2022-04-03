using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerSource;
    public bool canDoubleJump;
    public bool doubleSpeed;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float doubleJumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float runDistance = 0.0f;
    public float walkDistance = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Get Rigid Body Component
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
        // Modify Gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Allow player jump if it is On Ground and space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerSource.PlayOneShot(jumpSound, 1.0f);
            canDoubleJump = true;
        } else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump)
            {
                canDoubleJump = false;
                dirtParticle.Stop();
                playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
                playerAnim.Play("Running_jump",3,0f);
                playerAnim.SetTrigger("Jump_trig");
                playerSource.PlayOneShot(jumpSound, 1.0f);
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // player collides the ground resent isOnGround to true
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!gameOver)
            {
                dirtParticle.Play();
            }
            isOnGround = true;
        }
        // player collides with obstacle reset gameOver to true
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            // Debug.Log("Game Over!");
            playerSource.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
