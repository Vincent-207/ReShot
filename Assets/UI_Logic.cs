using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Logic : MonoBehaviour
{
   public void loadPrev()
   {
        SceneManager.LoadScene(ShootData.previousSceneName, LoadSceneMode.Single);
   }

   public void loadStartingScene()
   {
        ShootData.positions = new List<Vector2>();
        ShootData.directions = new List<Vector2>();
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
   }
}
