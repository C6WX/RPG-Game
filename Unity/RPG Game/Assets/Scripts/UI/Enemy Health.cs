using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    TMP_Text enemyHealthText;
    Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealthText = GetComponent<TMP_Text>();
        enemyScript = GameObject.FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = ("Enemy Health: " + enemyScript.enemyHealth.ToString());
    }
}
