using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    String nextSceneName;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            transitionScene();
        }
    }
    void transitionScene()
    {
        if(nextSceneName != null)
        {
            ShootData.previousSceneName = nextSceneName;
            SceneManager.LoadScene(nextSceneName);

        }
        
    }
}
