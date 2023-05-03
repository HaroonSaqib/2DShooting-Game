using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBullet : MonoBehaviour
{
    public float life = 2;
    



    private void Awake()
    {
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerKilling>(out PlayerKilling playercomponent))
        {
            playercomponent.playerDamage(1f);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
