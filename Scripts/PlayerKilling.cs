using System.Collections ;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKilling : MonoBehaviour
{
   [SerializeField] float health ,maxHealth = 6f;

    public Healthbar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
