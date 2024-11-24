using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    bool doJump = false;
    Rigidbody2D playerRB;
    [SerializeField]
    GameObject arrow;
    public float shootTimerLength;
    float shootTimer;
    int arrowsShot = 0;
    public Vector2[] shootPositions;
    SpriteRenderer playerSR;
    [SerializeField]
    LayerMask groundLayers;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = transform.GetComponent<Rigidbody2D>();
        playerSR = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        
        Vector2 shootDirection = getShootDir();
        if(shootDirection != Vector2.zero)
        {
            ShootArrow(shootDirection);
        }

        Debug.DrawRay(transform.position, shootDirection * 10, Color.red);

        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;

        }

        //move player
        if(doJump && isGrounded())
        {
            //jump
            playerRB.AddForce(new Vector2(0, jumpForce));
            doJump = false;
        }

        playerRB.AddForce(moveDir, ForceMode2D.Force);
        
    }

    bool isGrounded()
    {
        float playerHeight = playerSR.size.y;
        float offset = 0.1f;
        RaycastHit2D groundRay = Physics2D.Raycast(transform.position, Vector2.down, playerHeight + offset, groundLayers);

        if(groundRay.collider == null)
        {
            return false;
        }
        else{
            Debug.Log("Col: " + groundRay.collider);
            return true;
        }
    }

    void ShootArrow(Vector2 direction)
    {
        // instaniate
        float increase = 2.0f;
        Vector3 shootPos = new Vector3(transform.position.x + (increase * direction.x), transform.position.y + (increase * direction.y), transform.position.z);
        GameObject shotArrow = Instantiate(arrow, shootPos, transform.rotation);
        ArrowScript shotArrowScript = shotArrow.GetComponent<ArrowScript>();
        shotArrowScript.setMoveDir(direction);

        // save values
        ShootData.positions.Add(shootPos);
        ShootData.directions.Add(direction);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Spikes"))
        {
            Die();
        }
    }
    Vector2 getShootDir()
    {
       // return Vector2.zero;
        if(shootTimer <= 0)
        {
            
            if(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Shoot Right ");
                shootTimer = shootTimerLength;
                return Vector2.right;
            }
            else if(Input.GetKeyDown(KeyCode.J))
            {
                shootTimer = shootTimerLength;
                 Debug.Log("Shoot Left ");
                return Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.I))
            {
                shootTimer = shootTimerLength;
                return Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.K))
            {
                shootTimer = shootTimerLength;
                return Vector2.down;
            }


        }
        else{
            shootTimer -= Time.deltaTime;
        }

        return Vector2.zero;
    }

    public void Die()
    {
        //load scene
        Debug.Log("Player Dieing");
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
    }
}
