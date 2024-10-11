using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Dice diceScript;
    LevelManager levelScript;

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
        levelScript = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        EnemyDiceRoll();
        EnemyHealthCalculation();
        EnemyDeath();
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

    public void EnemyHealthCalculation() 
    {
        //After the player has rolled and the damage has been calculated, damage the enemy
        if (diceScript.lastRoller == "Player")
        {
            if (diceScript.damageCalculated == true)
            {
                enemyHealth = enemyHealth - diceScript.damage;
                Debug.Log("Enemy Health = " + enemyHealth);
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
                diceScript.playerRolled = true;
            }
        }
    }

    public void EnemyDeath()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            levelScript.enemiesBeaten++;
            Destroy(gameObject);
        }
    }
}
