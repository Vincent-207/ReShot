using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnerLogic : MonoBehaviour
{
    public  GameObject arrow;
    void Awake()
    {
        int arrowCount = ShootData.positions.Count;
        

        for(int index = 0; index < arrowCount; index++)
        {
            Debug.Log("SpawnArrow");
            GameObject shotArrow = Instantiate(arrow, ShootData.positions[index], transform.rotation);
            ArrowScript shotArrowScript = shotArrow.GetComponent<ArrowScript>();
            shotArrowScript.setMoveDir(ShootData.directions[index]);
        }

        
    }

    
}
