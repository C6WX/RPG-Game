using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Dice diceScript;
    public GameObject dodgeUI;      

    public float playerHealth = 20f;
    public float playerLevel = 1f;
    public float playerXP = 0f;
    public int critcalHitChance = 20;
    public int dodgeChance = 10;
    public int armourRating = 2;
    [HideInInspector] public string dodgeSuccess = null;
    //-1 is used as null cant be used with an int so -1 acts as null
    [HideInInspector] public int dodge = -1;
    [HideInInspector] public bool playerRolledDodge = true;


    // Start is called before the first frame update
    private void Start()
    {
        diceScript = GameObject.FindObjectOfType<Dice>();
        dodgeUI = GameObject.Find("Roll for dodge");     
        dodgeUI.SetActive(false);       
    }
       
       

    // Update is called once per frame
    private void Update()
    {
        HealthCalculation();     
    }

    public void HealthCalculation()
    {
        //After the enemy has rolled, the player's health is reduced based on the enemie's damage
        if (diceScript.lastRoller == "Enemy" && diceScript.damageCalculated == true)
        {
            dodgeUI.SetActive(true);
            if (dodge != -1)
            {
                //if the player succeeds with dodging, they take no damage
                if (dodge <= dodgeChance)
                {
                    Debug.Log("Player Dodged");
                    dodgeSuccess = "succeeded";
                    diceScript.damageCalculated = false;
                    diceScript.lastRoller = null;
                    //sets dodge back to -1 which is used as a replacement for null
                    dodge = -1;
                    dodgeUI.SetActive(false);
                    return;
                }
                //if the player doesn't succeed with dodging, they take damage
                else
                {
                    dodgeSuccess = "failed";
                    //reduces the enemies damage based on the player's armour
                    diceScript.enemyDamage = diceScript.enemyDamage - armourRating;
                    //damages the player based on the enemies damage
                    playerHealth = playerHealth - diceScript.enemyDamage;
                    Debug.Log("Player Health = " + playerHealth);
                    diceScript.damageCalculated = false;
                    diceScript.lastRoller = null;
                    //sets dodge back to -1 which is used as a replacement for null
                    dodge = -1;
                    dodgeUI.SetActive(false);
                    PlayerDeath();
                }
            }
        }
    }

    //the player rolls a dice to see if they can dodge the enemies attack
    public void RollForDodge()
    {
        dodge = Random.Range(0, 100);
        Debug.Log("Dodge Rolled " + dodge);
        playerRolledDodge = true;
    }

    public void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Destroy(gameObject);
        }
    }
}
