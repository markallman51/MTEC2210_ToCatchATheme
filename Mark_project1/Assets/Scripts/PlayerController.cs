using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameManager gMan;
    public float speed;

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

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //the Destroy function deletes game objects
        //Having this function in OnTrigger will destroy anything they player touches
        
        if(col.gameObject.tag == "Coin")
        {
            gMan.IncrementScore(1);
            Destroy(col.gameObject);
        }
            

        if(col.gameObject.tag == "Death")
            Destroy(gameObject);
    }

    
}
