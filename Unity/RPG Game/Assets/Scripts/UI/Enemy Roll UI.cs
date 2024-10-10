using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyRollUI : MonoBehaviour
{
    TMP_Text enemyRollText;
    Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyRollText = GetComponent<TMP_Text>();
        enemyScript = GameObject.FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRollText.text = ("Enemy Rolled: " + enemyScript.enemyRollResult.ToString());
    }
}
