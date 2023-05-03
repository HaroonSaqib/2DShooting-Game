using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireAnimation : MonoBehaviour
{
    public Animator ani;
    public float life = 0.5f;
    
    
    
    
    
    

    [SerializeField] GameObject explosion;

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            explosion.SetActive(true);
            GameObject explode = Instantiate(explosion, collision.transform.position, Quaternion.identity);
            ani.enabled = true;
            Destroy(collision.gameObject);
            Destroy(explode, life);

            
                //After Distruction of Player Loading the Same Scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 - 1);
            
        }
        
    }
  
    
    void Start()
    {
        ani.enabled = false;
       explosion.SetActive(false);
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
