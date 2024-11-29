// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class HideRollButtons : MonoBehaviour
// {
//     Dice diceScript;
//     
//     // Start is called before the first frame update
//     private void Start()
//     {
//         diceScript = GameObject.FindObjectOfType<Dice>();
//         CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
//     }
//
//     // Update is called once per frame
//     private void Update()
//     {
//         if (diceScript.playerRolled == true)
//         {
//             CanvasGroup.alpha = 0;
//         }
//         else
//         {
//             CanvasGroup.alpha = 1;
//         }
//     }
// }
