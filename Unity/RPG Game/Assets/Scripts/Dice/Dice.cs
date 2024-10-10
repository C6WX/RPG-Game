using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public float diceResult;
    public float diceSides;
    public bool diceRolled = false;
    public float maxDamage = 20f;
    public float damage;
    public string lastRoller = null;
    public bool damageCalculated = false;

    TMP_Text diceText;

    // Start is called before the first frame update
    void Start()
    {
        diceText = GetComponent<TMP_Text>();

        //RollD6();
        //RollD12();
        //RollD20();
    }

    void Update()
    {
        diceText.text = ("Dice result: " + diceResult.ToString());

        if (diceRolled == true)
        {
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
            double damage = ((double)diceResult / diceSides) * maxDamage;
            Debug.Log("Damage = " + damage);
            damageCalculated = true;
            diceRolled = false;
        }
    }

    public void RollD6()
    {
        diceSides = 6;
        int d6Result = Random.Range(1, 7);
        diceResult = d6Result;
        Debug.Log("D6 rolled a " + d6Result);
        diceRolled = true;
        lastRoller = "Player";
    }

    public void RollD12()
    {
        diceSides = 12;
        int d12Result = Random.Range(1, 13);
        diceResult = d12Result;
        Debug.Log("D12 rolled a " + d12Result);
        diceRolled = true;
        lastRoller = "Player";
    }

    public void RollD20()
    {
        diceSides = 20;
        int d20Result = Random.Range(1, 21);
        diceResult = d20Result;
        Debug.Log("D20 rolled a " + d20Result);
        diceRolled = true;
        lastRoller = "Player";
    }
}
