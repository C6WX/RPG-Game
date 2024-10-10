using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Dice diceScript;

    public double playerHealth = 20f;
    public float playerLevel = 1f;
    public float playerXP = 0f;
    public int luck = 20;


    // Start is called before the first frame update
    void Start()
    {
        diceScript = GameObject.FindObjectOfType<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diceScript.lastRoller == "Enemy")
        {
            if (diceScript.damageCalculated == true)
            {
                playerHealth = playerHealth - diceScript.enemyDamage;
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
            }
           
        }
    }
}
