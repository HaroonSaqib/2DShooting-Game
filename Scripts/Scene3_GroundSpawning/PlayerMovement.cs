using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    public Rigidbody2D rb;
    public float speed;
    bool facingRight = true;
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public Animator myAnimator;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadious;
    public LayerMask whatISGround;
    private int extraJumps;
    public int extraJumpsValue;
    public float jumpSpeed;

    [SerializeField] public float health, maxHealth = 5;

    public Healthbar healthbar;

    bool moveLeft;
    bool moveRight;

   

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
      // healthbar.setMaxHealth(maxHealth);
        GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
        moveRight = false;
        moveLeft = false;
    }

    public void pointerDownight()
    {
        moveRight = true;
    }
    public void pointerUpRight()
    {
        moveRight = false;
    }
    public void pointerDownLeft()
    {
        moveLeft = true;
    }
    public void pointerUpLeft()
    {
        moveRight = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Movement1();
        movement();
       // jump();
    
    }

    public void movement()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        //if(inputHorizontal != 0)
        //{

        //   rb.AddForce(new Vector2(inputHorizontal * 30f, 0f));
        //    ani.enabled = true;
        //}
        if(Input.GetKey(KeyCode.RightArrow))
        {
            myAnimator.SetBool("isRunning", true);
            backgroundMoveRight();

        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("isRunning", true);
            backgroundMoveLeft();
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            myAnimator.SetBool("isCrouching", true);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            myAnimator.SetBool("isCrouching", false);
        }
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if(inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    myAnimator.SetTrigger("isJumping");
        //    rb.velocity = new Vector2(rb.velocity.x, 10f);
        //}
        myAnimator.SetBool("isJumping", !isGrounded);
    }


    public void backgroundMoveRight()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);    
    }

    public void backgroundMoveLeft()
    {
        backgroundRenderer.material.mainTextureOffset -= new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
    public void Flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;

        facingRight = !facingRight;
    }


    public void jump()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKey(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpSpeed; 
            extraJumps--;
        }
        if (Input.GetKey(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    //private void FixedUpdate()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatISGround);
    //}





    public void playerDamage(float damageValue)
    {
        health -= damageValue;
        healthbar.SetHealth(health);

        if (health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }


  //public  void Movement1()
  //  {
  //      if(moveLeft)
  //      {
  //          myAnimator.SetBool("isRunning", true);
  //          backgroundMoveLeft();
  //          Debug.Log("button Clicked");
  //      }
  //      if(moveRight)
  //      {
  //          myAnimator.SetBool("isRunning", true);
  //          backgroundMoveRight();
  //      }
  //      //else
  //      //{
  //      //    myAnimator.SetBool("isRunning", false);
  //      //}
  //  }

    void Jumpbutton()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10f);
        //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatISGround);
        //    myAnimator.SetBool("isJumping", !isGrounded);

        //    if (isGrounded)
        //    {
        //        extraJumps = extraJumpsValue;
        //    }
        //    if (extraJumps > 0 )
        //    {
        //        rb.velocity = Vector2.up * jumpSpeed;
        //        extraJumps--;
        //    }
        //    if ( isGrounded == true && isGrounded == true)
        //    {
        //        rb.velocity = Vector2.up * jumpSpeed;
        //    }
    }






}
