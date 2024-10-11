using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public float diceResult, diceSides;
    public bool diceRolled = false;
    public float maxDamage = 20f;
    //public float damage;
    public string lastRoller = null;
    public bool damageCalculated = false;
    public bool playerRolled = false;
    public double damage;
    public double enemyDamage;

    private TMP_Text diceText;
    private Enemy enemyScript;

    // Start is called before the first frame update
    private void Start()
    {
        diceText = GetComponent<TMP_Text>();
        enemyScript = GameObject.FindObjectOfType<Enemy>();
    }

    private void Update()
    {
        diceText.text = ("Dice result: " + diceResult.ToString());
        PlayerDamageCalculation();
        EnemyDamageCalculation();
    }

    public void PlayerDamageCalculation()
    {
        if (diceRolled == true)
        {
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
            damage = ((double)diceResult / diceSides) * maxDamage;
            Debug.Log("Damage = " + damage);
            damageCalculated = true;
            diceRolled = false;
        }
    }
    public void EnemyDamageCalculation()
    {
        if (enemyScript.enemyRolled == true)
        {
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
            enemyDamage = ((double)enemyScript.enemyRollResult / enemyScript.enemyDiceSides) * enemyScript.enemyMaxDamage;
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
        if (playerRolled == false) 
        {
            int d6Result = Random.Range(1, 7);
            diceResult = d6Result;
            Debug.Log("D6 rolled a " + d6Result);
            diceRolled = true;
            lastRoller = "Player";            
        }        
    }

    public void RollD12()
    {
        diceSides = 12;
        //when the player hasn't rolled, the player can click to roll 
        if (playerRolled == false)
        {
            int d12Result = Random.Range(1, 13);
            diceResult = d12Result;
            Debug.Log("D12 rolled a " + d12Result);
            diceRolled = true;
            lastRoller = "Player";
        }        
    }

    public void RollD20()
    {
        diceSides = 20;
        //when the player hasn't rolled, the player can click to roll 
        if (playerRolled == false)
        { 
            int d20Result = Random.Range(1, 21);
            diceResult = d20Result;
            Debug.Log("D20 rolled a " + d20Result);
            diceRolled = true;
            lastRoller = "Player";
        }
    }
}
