using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    TMP_Text diceResultText;
    TMP_Text criticalHitText;
    Dice diceScript;

    TMP_Text playerHealthText;
    TMP_Text playerDodgeText;
    Player playerScript;

    TMP_Text enemyHealthText;
    TMP_Text enemyRollText;
    Enemy enemyScript;

    TMP_Text levelText;
    LevelManager levelScript;
    
    TMP_Text currentTurnText;
    
    // Start is called before the first frame update
    private void Start()
    {
        diceResultText = GetComponent<TMP_Text>();
        criticalHitText = GetComponent<TMP_Text>();
        diceScript = GameObject.FindObjectOfType<Dice>();

        playerHealthText = GetComponent<TMP_Text>();
        playerScript = GameObject.FindObjectOfType<Player>();

        enemyHealthText = GetComponent<TMP_Text>();
        enemyRollText = GetComponent<TMP_Text>();
        enemyScript = GameObject.FindObjectOfType<Enemy>();

        levelText = GetComponent<TMP_Text>();
        levelScript = GameObject.FindObjectOfType<LevelManager>();
        
        currentTurnText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    private void Update()
    { 
        switch(gameObject.tag)
        {
            case "DiceResult": 
                diceResultText.text = ("Player rolled: " + diceScript.diceResult.ToString()); 
                break;
            case "PlayerHealth":
                playerHealthText.text = ("Player Health: " + playerScript.playerHealth.ToString());
                break;
            case "EnemyHealth":
                enemyHealthText.text = ("Enemy Health: " + enemyScript.enemyHealth.ToString());
                break;
            case "EnemyRoll":
                enemyRollText.text = ("Enemy Rolled: " + enemyScript.enemyRollResult.ToString());
                break;
            case "PlayerDodge":
                enemyRollText.text = ("Dodge: " + playerScript.dodgeSuccess.ToString());
                break;
            case "CriticalHit":
                criticalHitText.text = ("Critical Hit: " + diceScript.criticalHitSuccess.ToString());
                break;
            case "LevelDisplay":
                levelText.text = ("Level: " + levelScript.currentLevel + "\n" + "Enemies Beaten: " + levelScript.enemiesBeaten);
                break;
            case "CurrentTurn":
                currentTurnText.text = ("Current Turn: " + diceScript.currentRoller);
                break;
        }    
    }
}
