using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RollD6();
        RollD12();
        RollD20();
    }

    public void RollD6()
    {
        int d6Result = Random.Range(1, 7);
        Debug.Log("D6 rolled a " + d6Result);
    }

    public void RollD12()
    {
        int d12Result = Random.Range(1, 13);
        Debug.Log("D12 rolled a " + d12Result);
    }

    public void RollD20()
    {
        int d20Result = Random.Range(1, 21);
        Debug.Log("D20 rolled a " + d20Result);
    }
}
