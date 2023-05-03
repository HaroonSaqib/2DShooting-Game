using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //For Movement and Flip
    float inputHorizontal;
    float inputVertical;
    bool facingToRight = true;
    public Transform gun;
    //Vector3 localScale;
   

    // For Bullet Fire
    public Transform bulletspawnPoint;
    public GameObject bulletprefab;
    public float bulletspeed = 10f;
    public Rigidbody2D rb;
    public float speed = 0.5f;

    //For Ground Check and Jump
    private bool isGrounded;
    public Transform groundCheck;
    public float CheckRadious;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;
    
    //For FallDetector and Respawn of Scenes
    Vector3 respawnPoint;
    public GameObject fallDetector;

    //For Killing Player(Health)
   


    void Start()
    {
        GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
        respawnPoint = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        jump();
        shoot();
        movement();
        

       // fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletprefab, bulletspawnPoint.position, bulletspawnPoint.rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = bulletspawnPoint.up * bulletspeed;
        }
    }

    public void movement()
    { 

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, 20f);
        //}

       

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if(inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * 40f, 0f));
        }
        if(inputHorizontal > 0 && !facingToRight )
        {
            flip();
            //We won't use this method if we don't want to change the scale each fram bcz it will make slower the execution
            //rb.transform.localScale = new Vector3(1, 1, 1);
        }
        if(inputHorizontal <0 && facingToRight)
        {
            flip();
            //rb.transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    void flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;

        facingToRight = !facingToRight;

    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadious,whatIsGround);
    }


    void jump()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * speed;
            extraJumps--;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * speed;

        }
    }









    // to respawn the player on collision with FallDetector and Next Scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
           
        }
        else if(collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
        else if(collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

}





//Movement Extra Code

//if (Input.GetKey(KeyCode.RightArrow))
//{
//    transform.position += new Vector3(speed, 0, 0);
//}
//if (Input.GetKey(KeyCode.LeftArrow))
//{
//    transform.position -= new Vector3(speed, 0, 0);
//}




//if (Input.GetKey(KeyCode.UpArrow))
//{
//    rb.AddForce(new Vector3(0f, 1000f, 0f));
//    Debug.Log("In jump");
//}



//public void jump(float jspeed)
//{

//    rb.AddForce(transform.up * jspeed);
//}