using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetDestruction : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 8f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    public void jetDestroy(float destructionValue)
    {
        health -= destructionValue;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
