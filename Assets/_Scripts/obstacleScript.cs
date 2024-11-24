using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D col;
    ParticleSystem particles;
    SpriteRenderer rend;
    void Start()
    {
        col = transform.GetComponent<BoxCollider2D>();
        rend = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        col.enabled = false;
        rend.enabled = false;
    }

}
