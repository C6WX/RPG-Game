using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int enemy1Health = 5;
    private int enemyDifficulty = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnemyDiceRoll()
    {
        //the enemy difficulty determines the amount of sides the dice has
        int diceSides = 20 - enemyDifficulty;
        int enemyRollResult = Random.Range(1, diceSides);
        Debug.Log("Enemy rolled a " + diceSides + "sided dice and rolled a " + enemyRollResult);
    }
}
