using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceResult : MonoBehaviour
{
    TMP_Text diceResultText;
    Dice diceScript;

    // Start is called before the first frame update
    void Start()
    {
        diceResultText = GetComponent<TMP_Text>();
        diceScript = GameObject.FindObjectOfType<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        diceResultText.text = ("Enemy Health: " + diceScript.diceResult.ToString());
    }
}
