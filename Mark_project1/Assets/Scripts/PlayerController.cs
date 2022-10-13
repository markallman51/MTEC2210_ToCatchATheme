using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameManager gMan;
    public float speed;

    public SpriteRenderer zombie;

    public AudioClip[] brainMunch;
    public AudioClip dead;

    public Animator animator;

    //private bool playerDied = false;
    //reference to player sprite's rigid body
    //public Rigidbody2D rb;

    //force applied to jump
    //public float jumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = Input.GetAxisRaw("Horizontal");
        transform.Translate(xVel * speed * Time.deltaTime, 0, 0);
        /*
        Horizontal is an input built into Unity. It starts at 0.
        When the 'a' key is pressed, it's -1
        When the 'd' key is pressed, it's 1
        When nothing is pressed, it's 0
        We can plug a variable set to Horizontal into the movement calculation
        to automate left/right movement.
        Assuming there's a "Vertical" that works with up/down movement with
        'w' and 's'

        When each key is pressed, the var will incrememnt or decrement until it
        reaches 1 or -1. GetAxis will take in each value unit it gets to the goal,
        which gives movement a feeling of acceleration. GetAxisRaw will skip the
        increments or decrements and go straight to 1 or -1, so that movement will
        always be at top speed.
        */

        /*JUMP CODE(INACTIVE, REQUIRES RIGID BODY AND ASSIGNMENT)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //function for applying force. parameters are a vector2 of force applied on X and Y axis, and ForceMode, which is how the force is applied
            //Vector2.up is a shorthand for (0,1). This is useful since we only need upward force
            //By defaule, AddForce applies force additively. ForceMode Impulse makes it apply force all at once
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        */
        

        /*
        To flip the sprite for movement, I instinctively went for a "GetKeyDown bool" apporach, but we aren't using GetKeyDown
        Because we are using Horizontal, we can use that to flip the sprite instead
        Horizontal switches to -1 for left and 1 for right, so we can use the value of Horizontal to check what direction the player is facing
         */

        if(xVel > 0)
            zombie.flipX = false;

        if(xVel < 0)
            zombie.flipX = true;

        /*
        In our Animator, we use the float "Moving" to determine when to transition from idle animation to walking animation.
        Here, we'll change the value of Moving based on if the player is moving or not.
        */
        if (xVel == 0)
            animator.SetBool("Moving", false);
        else
            animator.SetBool("Moving", true);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //the Destroy function deletes game objects
        //Having this function in OnTrigger will destroy anything they player touches
        
        //when the player collects a brain(player sprite collides with brain sprite):
        //-score +1
        //-use PointSound function to play a munch sound
        //destroy the brain
        if(col.gameObject.tag == "Coin")
        {
            gMan.IncrementScore(1);
            gMan.PointSound(brainMunch);
            Destroy(col.gameObject);
        }

        //when the player dies(player sprite collides with bullet sprite):
        //-use DeathSound function to play the gunshot
        //destroy player
        if (col.gameObject.tag == "Death")
        {
            gMan.DeathSound(dead);
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //playerDied = true;
        }

        if(col.gameObject.tag == "Item")
        {
            Debug.Log("Switch'er up!");
            Destroy(col.gameObject);
        }
            
    }

    
}
