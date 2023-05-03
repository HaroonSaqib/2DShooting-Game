using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtsacleMovement : MonoBehaviour
{

    Transform target;
    [SerializeField] float moveSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("ObstacleCrusher").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        obstacleMovement();
    }

    void obstacleMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ObstacleCrusher" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerkilling))
        {
            playerkilling.playerDamage(1f);
        }
    }
}
