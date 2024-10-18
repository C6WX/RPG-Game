using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    TMP_Text diceResultText;
    Dice diceScript;

    TMP_Text playerHealthText;
    Player playerScript;

    TMP_Text enemyHealthText;
    TMP_Text enemyRollText;
    Enemy enemyScript;

    // Start is called before the first frame update
    private void Start()
    {
        diceResultText = GetComponent<TMP_Text>();
        diceScript = GameObject.FindObjectOfType<Dice>();

        playerHealthText = GetComponent<TMP_Text>();
        playerScript = GameObject.FindObjectOfType<Player>();

        enemyHealthText = GetComponent<TMP_Text>();
        enemyRollText = GetComponent<TMP_Text>();
        enemyScript = GameObject.FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    private void Update()
    { 
        if (gameObject.tag == "DiceResult")
        {
            diceResultText.text = ("Player rolled: " + diceScript.diceResult.ToString());
        }
       
        if (gameObject.tag == "PlayerHealth")
        {
            playerHealthText.text = ("Player Health: " + playerScript.playerHealth.ToString());
        }

        if (gameObject.tag == "EnemyHealth")
        {
            enemyHealthText.text = ("Enemy Health: " + enemyScript.enemyHealth.ToString());
        }

        if (gameObject.tag == "EnemyRoll")
        {
            enemyRollText.text = ("Enemy Rolled: " + enemyScript.enemyRollResult.ToString());
        }
    }
}
