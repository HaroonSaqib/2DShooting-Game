using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
        obstacle();
    }

   
    void obstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(0.22f, -0.393f), 0);
    }
}
