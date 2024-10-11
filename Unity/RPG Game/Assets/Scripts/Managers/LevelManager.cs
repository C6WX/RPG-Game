using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int enemiesBeaten = 0;
    public int currentLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When the player beats 10 enemies, they go to the next level
        if (enemiesBeaten == 10)
        {
            currentLevel++;
            enemiesBeaten = 0;
        }
    }
}
