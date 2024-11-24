using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 moveDir;
    [SerializeField]
     float moveSpeed;
    void Start()
    {
        //get dir to 
        
    }


    public void setMoveDir(Vector2 direction)
    {
        moveDir = direction;
        if(direction == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0,0,-90);
        }
        else if(direction == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        else if(direction == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(direction == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * transform.up;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("Hit player, kill them");
            PlayerController playerScript = collision.transform.GetComponent<PlayerController>();
            playerScript.Die();
            return;
        }
        else if(collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("Hit obstalce, destroying self");
            obstacleScript obstacleLogic = collision.transform.GetComponent<obstacleScript>();
            obstacleLogic.hit();

            Destroy(transform.gameObject);
        }
        else if (collision.transform.CompareTag("StaticGameobject"))
        {
            Debug.Log("Hit wall, destroying self");
            Destroy(gameObject);
        }
        else if(collision.transform.CompareTag("ReflectProjectiles"))
        {
            Debug.Log("Hit Reflector, turning around");

            transform.rotation = transform.rotation * Quaternion.Euler(0,0,180);
        }
    }

    void die()
    {

    }
}
