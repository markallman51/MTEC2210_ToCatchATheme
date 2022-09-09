using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

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
    }
}
