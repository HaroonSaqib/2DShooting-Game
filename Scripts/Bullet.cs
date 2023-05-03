using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 2;

    private void Start()
    {
        

    }
    void Awake()
    {
        Destroy(gameObject, life);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemycomponent))
        {
            enemycomponent.damage(1f);

            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "Enemy2")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.TryGetComponent<EnemyScript2>(out EnemyScript2 enemycomponent2))
        {
            enemycomponent2.damage(1f);
        }
        if(collision.gameObject.TryGetComponent<JetDestruction>(out JetDestruction jetComponent))
        {
            jetComponent.jetDestroy(1f);
        }
        Destroy(gameObject);
    }

}
