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
    public int armourRating;
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
                if (dodge <= dodgeChance)
                {
                    Debug.Log("Player Dodged");
                    diceScript.damageCalculated = false;
                    diceScript.lastRoller = null;
                    dodge = -1;
                    dodgeUI.SetActive(false);
                    return;
                }
                else
                {
                    playerHealth = playerHealth - diceScript.enemyDamage;
                    Debug.Log("Player Health = " + playerHealth);
                    diceScript.damageCalculated = false;
                    diceScript.lastRoller = null;
                    dodge = -1;
                    dodgeUI.SetActive(false);
                    PlayerDeath();
                }
            }
        }
    }

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
        else
        {
            return;
        }
    }
}
