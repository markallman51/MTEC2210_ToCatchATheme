using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject itemPrefab;

    public Transform left;
    public Transform right;

    private float xPos;
    private float prevXPos;
    public float tooCloseOffset = 2;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating calls a function at a given interval
        //takes in a function name as a string, delay before first call, and
        //delay between each call
        InvokeRepeating("SpawnItem", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {
        
        //set offset to determine tooCloseness
        float tooCloseLeft = prevXPos - tooCloseOffset;
        float tooCloseRight = prevXPos + tooCloseOffset;
        
        //get a random x positon between the left and right boundary
        xPos = Random.Range(left.position.x, right.position.x);

        //if the new random x position is too close to the old one, reroll
        while(xPos > tooCloseLeft && xPos < tooCloseRight)
            xPos = Random.Range(left.position.x, right.position.x);


        //create a Vector2 as a random spawn point. y pos will be the same
        //either way so it can be static
        Vector2 spawnPos = new Vector2(xPos, right.position.y);

        //Instantiate() function create a game object
        //takes in a GameObject, a location(based on world pos). and a rotation
        //here, Vector3.zero is (I assume) shorthand for (0, 0, 0)
        //and Quaternion.identity just means no rotation.
        Instantiate(itemPrefab, spawnPos, Quaternion.identity);

        //set current x position to previous for the next call
        prevXPos = xPos;
    }
}
