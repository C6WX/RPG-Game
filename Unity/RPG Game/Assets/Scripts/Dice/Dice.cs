using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public float diceResult, diceSides;
    public bool diceRolled = false;
    public float maxDamage = 20f;
    public string lastRoller = null;
    public bool damageCalculated = false;
    public bool playerRolled = false;
    public float damage;
    public float enemyDamage;
    public string currentRoller = "Player";
    [HideInInspector] private bool playerRolledCrit = false;
    [HideInInspector] public int criticalHit = -1;
    [HideInInspector] public string criticalHitSuccess = null;

    private Enemy enemyScript;
    private Player playerScript;
    private GameObject criticalUI;

    // Start is called before the first frame update
    private void Start()
    {
        
        playerScript = GameObject.FindObjectOfType<Player>();
        criticalUI = GameObject.Find("Roll for critical hit");
        criticalUI.SetActive(false);
    }

    private void Update()
    {
        enemyScript = GameObject.FindObjectOfType<Enemy>();
        PlayerDamageCalculation();
        EnemyDamageCalculation();
    }

    public void PlayerDamageCalculation()
    {      
        if (diceRolled == true && playerRolledCrit == true)
        {
            if (criticalHit <= playerScript.critcalHitChance)
            {
                criticalHitSuccess = "succeeded";
                Debug.Log("Critical Hit");
                //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
                damage = (diceResult / diceSides) * maxDamage;
                //increases the damage if the player rolls a crit
                damage = damage * 1.5f;
                Debug.Log("Damage = " + damage);
                damageCalculated = true;
                diceRolled = false;
                playerRolledCrit = false;
                criticalUI.SetActive(false);
            }
            else
            {
                criticalHitSuccess = "failed";
                //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
                damage = (diceResult / diceSides) * maxDamage;
                Debug.Log("Damage = " + damage);
                damageCalculated = true;
                diceRolled = false;
                playerRolledCrit = false;
                criticalUI.SetActive(false);
            }            
        }
    }
    public void RollForCriticalHit()
    {
        criticalHit = Random.Range(0, 100);
        Debug.Log("Critical Hit Rolled " + criticalHit);
        playerRolledCrit = true;
    }

    public void EnemyDamageCalculation()
    {
        if (enemyScript.enemyRolled == true)
        {
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled          
            enemyDamage = ((float)enemyScript.enemyRollResult / (float)enemyScript.enemyDiceSides) * (float)enemyScript.enemyMaxDamage;
            Debug.Log("Enemy Damage = " + enemyDamage);
            damageCalculated = true;
            playerRolled = false;
            enemyScript.enemyRolled = false;
        }
    }

    public void RollD6()
    {
        diceSides = 6;
        //when the player hasn't rolled, the player can click to roll 
        if (playerRolled == false && playerScript.playerRolledDodge == true) 
        {
            int d6Result = Random.Range(1, 7);
            diceResult = d6Result;
            Debug.Log("D6 rolled a " + d6Result);
            diceRolled = true;
            lastRoller = "Player";
            playerScript.playerRolledDodge = false;
            criticalUI.SetActive(true);
        }        
    }

    public void RollD12()
    {
        diceSides = 12;
        //when the player hasn't rolled, the player can click to roll 
        if (playerRolled == false && playerScript.playerRolledDodge == true)
        {
            int d12Result = Random.Range(1, 13);
            diceResult = d12Result;
            Debug.Log("D12 rolled a " + d12Result);
            diceRolled = true;
            lastRoller = "Player";
            playerScript.playerRolledDodge = false;
            criticalUI.SetActive(true);
        }        
    }

    public void RollD20()
    {
        diceSides = 20;
        //when the player hasn't rolled, the player can click to roll 
        if (playerRolled == false && playerScript.playerRolledDodge == true)
        { 
            int d20Result = Random.Range(1, 21);
            diceResult = d20Result;
            Debug.Log("D20 rolled a " + d20Result);
            diceRolled = true;
            lastRoller = "Player";
            playerScript.playerRolledDodge = false;
            criticalUI.SetActive(true);
        }
    }
}
