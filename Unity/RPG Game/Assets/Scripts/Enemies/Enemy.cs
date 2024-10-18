using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Dice diceScript;
    LevelManager levelScript;
    Player playerScript;

    public int enemyDiceSides;
    public float enemyHealth;
    private int enemyDifficulty;
    public int enemyMaxDamage;
    public bool enemyRolled = false;
    public int enemyRollResult;


    // Start is called before the first frame update
    void Start()
    {
        diceScript = GameObject.FindObjectOfType<Dice>();
        levelScript = GameObject.FindObjectOfType<LevelManager>();
        playerScript = GameObject.FindObjectOfType<Player>();

        //randomly generates the enemies' difficulty based on the current level
        enemyDifficulty = Random.Range(1, levelScript.currentLevel);
        Debug.Log("enemy difficulty = " + enemyDifficulty);

        //the enemy difficulty affects the enemies' stats
        switch (enemyDifficulty)
        {
            case 1:
                enemyDiceSides = 20;
                enemyHealth = 10;
                enemyMaxDamage = 15;
                break;
            case 2:
                enemyDiceSides = 20;
                enemyHealth = 15;
                enemyMaxDamage = 20;
                break;
        }
    }

    void Update()
    {
        EnemyDiceRoll();
        EnemyHealthCalculation();
        EnemyDeath();

        //make a switch that changes the enemies stats based on the difficulty given to the enemy
       
    }


    public void EnemyDiceRoll()
    {
        if (diceScript.playerRolled == true)
        {
            //the enemy difficulty determines the amount of sides the dice has
            //enemyDiceSides = 20 - enemyDifficulty;
            enemyRollResult = Random.Range(1, enemyDiceSides);
            Debug.Log("Enemy rolled a " + enemyDiceSides + " sided dice and rolled a " + enemyRollResult);
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
            playerScript.playerXP = playerScript.playerXP + 10;
            //Give the player 10 health
            playerScript.playerHealth = playerScript.playerHealth + 10;
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
