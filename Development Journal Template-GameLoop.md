# RPG - Game Loop

Fundementals of Game Development

Callum Wade

2404781

## Research
```Markdown
### What sources or references have you identified as relevant to this task?

- Since I was adding new int and float variables to the game, I researched different operators that i could use in if statements and equations.
```

```Markdown
#### Sources
For the dodge chance and critical hit chance, I had to use lots different operators for different if statements and equations which lead me to research them using the websites on arithmatic operators and comparison operators by w3schools (C# Operators, s.d.), (C# Comparison Operators, s.d.).

The operators shown on both websites that I ended up using are - (subtraction), + (addition), <= (less than or equal to), == (equal to) and != (not equal too).

I liked using this website as it made it really simple to find which operators I needed for my problems and with examples on how I could use them witin my code. 
```

```Markdown
# Game Source
Team Fortress 2 is a first person shooter game developed by Valve Corporation. The game uses critical hits to give the players a chance to deal high damage to the enemy they are fighting(Team Fortress 2, 2007)

When shooting at another player within the game, each bullet that hits the enemy has a 2% chance to deal three times the weapon's base damage. The chance of dealing a critical hit is also modified by a bonus percentage based on the damage that the player has dealt within the last 20 seconds which scales from 0% at 0 damage to 10% at 800 damage.

I found this implementation of critical hit damage to be very interesting because the player is able to affect the chance of the critcal chance by dealing damage instead of having a stat that they change by getting new equipment like RPG games do.
```

## Implementation

### What was the process of completing the task? What influenced your decision making?

-To complete the task, I started by making a critical hit variable, a dodge chance variable and a armour rating variable.

<br>

```csharp
    public int critcalHitChance = 20;
    public int dodgeChance = 10;
    public int armourRating = 2;
```
*Figure 1. An example of the variables I created for the task

- Next I started by implementing the dodge chance to the player's health calculation script and I made a dodge dice roll so the player can roll to dodge

<br>

```csharp
public void HealthCalculation()
{
    //After the enemy has rolled, the player's health is reduced based on the enemie's damage
    if (diceScript.lastRoller == "Enemy" && diceScript.damageCalculated == true)
    {
        dodgeUI.SetActive(true);
        if (dodge != -1)
        {
            //if the player succeeds with dodging, they take no damage
            if (dodge <= dodgeChance)
            {
                Debug.Log("Player Dodged");
                dodgeSuccess = "succeeded";
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
                //sets dodge back to -1 which is used as a replacement for null
                dodge = -1;
                dodgeUI.SetActive(false);
                return;
            }
            //if the player doesn't succeed with dodging, they take damage
            else
            {
                dodgeSuccess = "failed";
                //reduces the enemies damage based on the player's armour
                diceScript.enemyDamage = diceScript.enemyDamage - armourRating;
                //damages the player based on the enemies damage
                playerHealth = playerHealth - diceScript.enemyDamage;
                Debug.Log("Player Health = " + playerHealth);
                diceScript.damageCalculated = false;
                diceScript.lastRoller = null;
                //sets dodge back to -1 which is used as a replacement for null
                dodge = -1;
                dodgeUI.SetActive(false);
                PlayerDeath();
            }
        }
    }
}
```

*Figure 2. The Health Calculation script with the dodge variable implemented in*

```csharp
   //the player rolls a dice to see if they can dodge the enemies attack
   public void RollForDodge()
   {
       dodge = Random.Range(0, 100);
       Debug.Log("Dodge Rolled " + dodge);
       playerRolledDodge = true;
   }
```

*Figure 3. The RollForDodge script that allows the player to roll a dice to determine if they dodge the damage they are about to take*

- Next I implemented the critical hit chance variable to the player damage calculation script and made a roll for critical hit script so that the player can roll a dice to determine if they deal critical damage or not.

```csharp
public void PlayerDamageCalculation()
{      
    if (diceRolled == true && playerRolledCrit == true)
    {
        if (criticalHit <= playerScript.critcalHitChance)
        {
            criticalHitSuccess = "succeeded";
            Debug.Log("Critical Hit");
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
            damage = (diceResult / diceSides) * maxDamage;
            //increases the damage if the player rolls a crit
            damage = damage * 1.5f;
            Debug.Log("Damage = " + damage);
            damageCalculated = true;
            diceRolled = false;
            playerRolledCrit = false;
            criticalUI.SetActive(false);
        }
        else
        {
            criticalHitSuccess = "failed";
            //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
            damage = (diceResult / diceSides) * maxDamage;
            Debug.Log("Damage = " + damage);
            damageCalculated = true;
            diceRolled = false;
            playerRolledCrit = false;
            criticalUI.SetActive(false);
        }            
    }
}
```

*Figure 4. The PlayerDamageCalculation script with the critical hit variable implemented*

```csharp
 public void RollForCriticalHit()
 {
     criticalHit = Random.Range(0, 100);
     Debug.Log("Critical Hit Rolled " + criticalHit);
     playerRolledCrit = true;
 }
```
*Figure 5. The RollForCriticalHit script that allows the player to roll a dice to determine if they deal extra damage to the enemy or not*

- Lastly I implemented the armour rating variable so that the damage the player takes is reduced by the amount of armour the player has.

```csharp
diceScript.enemyDamage = diceScript.enemyDamage - armourRating;
```

*Figure 6. The script that reduces the damage that the player is about to take by the amount of armour the player has*

### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

- I added buttons for both the RollForDodge script and also the RollForCriticalHit script which dissapear when they aren't usable. This helped reach the outcome for this task since it meant that the player wouldn't get as confused by all the buttons on the screen.

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

- When changing the variables from double to ints and float so that they worked with the new variables, an error occurred that kept returning the enemies damage as 0 after it went through the calculation. I sorted this issue out by adding (float) before the variables to make sure each one is set to float variables

## Outcome

Here you can put links required for delivery of the task, ensure they are properly labelled appropriately and the links function. The required components can vary between tasks, you can find a definative list in the Assessment Information. Images and code snippets can be embedded and annotated if appropriate.

- [Video Link](https://youtu.be/pYL_tw9V-fk)
- [Github Link](https://github.com/C6WX/RPG-Game)
- [Itch.io Link](https://c6wx.itch.io/idle-dice)

## Critical Reflection

### What did or did not work well and why?

- I think after finishing the task, everything ended up working very well, especially the dodge chance. I think this worked very well because smoothly it works during gameplay and how much it adds to the gameplay instead of the player just being helpless to the damage that the enemy is about to deal. 

- One thing that didn't go well would have to be the the critical hit chance while working on this task. This is because it caused lots of errors with my damage equation leading me to have to change variable types to be able to implement the critical hits.

### What would you do differently next time?

- Next time I think I would plan all the variables I would need for this project first so that I don't have to keep chaging each of them whenever I add a new one.

## Bibliography

Critical hits - Official TF2 Wiki | Official Team Fortress Wiki (s.d.) At: https://wiki.teamfortress.com/wiki/Critical_hits (Accessed  18/10/2024).

C# Operators (s.d.) At: https://www.w3schools.com/cs/cs_operators.php (Accessed  18/10/2024).

C# Comparison Operators (s.d.) At: https://www.w3schools.com/cs/cs_operators_comparison.php (Accessed  18/10/2024).

## Declared Assets

https://assetstore.unity.com/packages/2d/characters/bandits-pixel-art-104130

https://assetstore.unity.com/packages/2d/characters/hero-knight-pixel-art-165188
