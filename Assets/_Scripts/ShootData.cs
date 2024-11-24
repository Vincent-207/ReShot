using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootData : MonoBehaviour
{
    public static ShootData Instance;
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        previousSceneName = "Tutorial";
        DontDestroyOnLoad(gameObject);

        SpawnArrows();
    }
    public static List<Vector2> positions = new List<Vector2>();
    public static List<Vector2> directions = new List<Vector2>();
    public static string previousSceneName;
    public static void printStuff()
    {
        Debug.Log(positions);
    }

    private void SpawnArrows()
    {
        Debug.Log("Positions length: " + positions.Count);
    }

    public static void loadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneName, LoadSceneMode.Single);
    }

    public void loadStartingScene()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
