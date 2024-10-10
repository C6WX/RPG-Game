using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Dice diceScript;

    public float enemyHealth = 5;
    private int enemyDifficulty = 1;


    // Start is called before the first frame update
    void Start()
    {
        diceScript = GameObject.FindObjectOfType<Dice>();
    }

    void Update()
    {
        if (diceScript.lastRoller == "Player")
        {
            if (diceScript.damageCalculated == true)
            {
                enemyHealth = enemyHealth - diceScript.damage;
                Debug.Log(enemyHealth);
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
                Debug.Log("HI");
            }
            
        }
    }


    public void EnemyDiceRoll()
    {
        //the enemy difficulty determines the amount of sides the dice has
        int diceSides = 20 - enemyDifficulty;
        int enemyRollResult = Random.Range(1, diceSides);
        Debug.Log("Enemy rolled a " + diceSides + "sided dice and rolled a " + enemyRollResult);
        diceScript.lastRoller = "Enemy";
    }
}
