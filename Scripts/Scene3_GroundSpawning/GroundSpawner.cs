using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground1, Ground2, Ground3;
    bool hasGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasGround)
        {
            spawnGround();
            hasGround = true;
        }
    }

    public void spawnGround()  
    {
        int randomNumber = Random.Range(1, 4); 

        if(randomNumber == 1)
        {
            Instantiate(Ground1, new Vector3(-27.92704f, -13.2f, 0), Quaternion.identity);
        }
        if(randomNumber == 2)
        {
            Instantiate(Ground2, new Vector3(12.1f, -13.2f, 0), Quaternion.identity);
        }
        if(randomNumber == 3)
        {
            Instantiate(Ground3, new Vector3(51.9f, -13.2f, 0), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Has Ground");
            hasGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasGround = false;
    }
}
