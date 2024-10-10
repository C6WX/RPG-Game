using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public float diceResult;

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
        diceText.text = ("Dice rolled: " + diceResult.ToString());
    }

    public void RollD6()
    {
        int d6Result = Random.Range(1, 7);
        diceResult = d6Result;
        Debug.Log("D6 rolled a " + d6Result);
    }

    public void RollD12()
    {
        int d12Result = Random.Range(1, 13);
        diceResult = d12Result;
        Debug.Log("D12 rolled a " + d12Result);
    }

    public void RollD20()
    {
        int d20Result = Random.Range(1, 21);
        diceResult = d20Result;
        Debug.Log("D20 rolled a " + d20Result);
    }
}
