using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 1f;


    private void Start()
    {
        health = maxhealth;
    }
    private void Update()
    {

    }


    public void damage(float damagevalue)
    {

        health -= damagevalue;

        if (health == 0)
        {
            Destroy(gameObject);
            
        }
        
    }
}
