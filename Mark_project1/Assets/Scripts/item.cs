using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //set a random speed between 3 and 7
        speed = Random.Range(3, 7);
    }

    // Update is called once per frame
    void Update()
    {
        //after spawning, item will move downward at a random speed
        transform.Translate(0, -speed * Time.deltaTime,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Groundry")
            Destroy(gameObject);
    }
}
