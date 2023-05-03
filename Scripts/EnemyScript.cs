using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 2f;
  
    Transform target;
    Rigidbody2D rb;
    Vector2 moveDirection;
   [SerializeField] float moveSpeed =5f;
    


    

    private void Start()
    {
        health = maxhealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
     
       
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 4) 
       {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

    }
 


    public void damage(float damagevalue)
    {
        
       health -= damagevalue; 
        
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.name == "bullet")
    //    {
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}
