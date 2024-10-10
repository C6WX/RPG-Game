using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Dice diceScript;

    public int enemyDiceSides;
    public double enemyHealth = 5;
    private int enemyDifficulty = 0;
    public int enemyMaxDamage = 15;
    public bool enemyRolled = false;
    public int enemyRollResult;


    // Start is called before the first frame update
    void Start()
    {
        diceScript = GameObject.FindObjectOfType<Dice>();
    }

    void Update()
    {
        EnemyDiceRoll();

        //After the player has rolled and the damage has been calculated, damage the enemy
        if (diceScript.lastRoller == "Player")
        {
            if (diceScript.damageCalculated == true)
            {
                enemyHealth = enemyHealth - diceScript.damage;
                Debug.Log(enemyHealth);
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
                Debug.Log("HI");
                diceScript.playerRolled = true;
            }
        }
    }


    public void EnemyDiceRoll()
    {
        if (diceScript.playerRolled == true)
        {
            //the enemy difficulty determines the amount of sides the dice has
            enemyDiceSides = 20 - enemyDifficulty;
            enemyRollResult = Random.Range(1, enemyDiceSides);
            Debug.Log("Enemy rolled a " + enemyDiceSides + "sided dice and rolled a " + enemyRollResult);
            diceScript.lastRoller = "Enemy";
            enemyRolled = true;
            //diceScript.playerRolled = false;
        }
    }
}
