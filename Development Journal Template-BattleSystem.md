# Battle System 

Fundementals of Game Development

Callum Wade 

2404781

## Research

### What sources or references have you identified as relevant to this task?

- Since I was making a battle system, I researched into accessing variables from other scripts and using double variables. When working on the stats of each characted, I constantly needed to access varaibles from other scripts that would need changing. As for the double variables, I used them in my damage calculation. 

#### Sources

- An opening paragraph about the source stating the author, developer or organisation, this paragraph should explain the source's influence, credentials, critical reception, awards, reputation or any issues with the source. For example, if the source is not reputable. If the source is a game, the issues that occurred during development or if had a poor launch.
- List the aspects analysed in reference to the current task.
- An ending paragraph stating what you enjoyed or disliked, what you agreed with or not agree with.

```Markdown

I needed to access variables from a different script so that they could be changed within the script I was currently working on. I had previously accessed variables from other scripts in past projects I had done but I needed a refresher on it. This led me to read a gamedevbeginner website on accessing variables from other scripts. (French, 2020)

Within the website, I found that the section of using a get component on a different object was able to help remind me of how it is done since that was the method I used to use in my other projects. I also found the section on static variables very interesting as I used to use static variables lots to allow variables to be accessed across scripts but after reading about them as it turns out that using static variables can cause problems later of when programming as only one of a variable can be a static variable. If you were to have multiple of a singe variable, you will need to change each reference of the static variable in each script till it works. 

I found the guide to be simple, which is good because it is easy to find what you need to find. However it is written in an unproffesional format which can make it hard for some people to follow.


# Game Source

An example of a game that uses a battle system is Baldur's Gate 3, a RPG game developed by Larian Studios(Baldur's Gate 3 2023).

Baldur's Gate 3 uses a battle system that is completely based off a roll of the dice. Within the game, a roll of a dice decided many things that happen incuding the damage that the player deals, the chance of the player's attack hitting and if the player gets a critical hit.

I find the use of a dice to determine most things within the game to make the gameplay very interesting as it means that no playthrough will ever be the same unless somehow you roll the same number for every single dice roll, which is basically impossible.


```

## Implementation

### What was the process of completing the task? What influenced your decision making?

- For the first step, amending the dice class, I made the dice return an int value.
<br>

```csharp
public void RollD6()
{
    diceSides = 6;
    //when the player hasn't rolled, the player can click to roll 
    if (playerRolled == false) 
    {
        int d6Result = Random.Range(1, 7);
        diceResult = d6Result;
        Debug.Log("D6 rolled a " + d6Result);
        diceRolled = true;
        lastRoller = "Player";            
    }        
}
```
*Figure 1. An of how I scripted the dice roll and making it return an in value*

- To create the pawn class, which in my game is the basic enemy, i assigned the enemy health, max damage and difficulty stats
<br>

```csharp

 public int enemyDiceSides;
 public double enemyHealth = 5;
 private int enemyDifficulty = 0;
 public int enemyMaxDamage = 15;
 public bool enemyRolled = false;
 public int enemyRollResult;

```
*Figure 2. The script I used to assign the enemies' stats.*

- To add a battle system and work out health after attacking, I made an equation that worked out damage based on the dice roll, then I made it so that after the player rolled the dice, the result of the roll would go through the equation, then the result would be subtracted off the enemies health. I also made this work for the enemy so that when the enemy rolls, the same thing happens but the damage is subtracted from the player's health.
<br>

```csharp

public void PlayerDamageCalculation()
{
    if (diceRolled == true)
    {
        //works out the damage based on the dice result and the amount of sides the dice has and the max damage to make the damage equal no matter the dice rolled
        damage = ((double)diceResult / diceSides) * maxDamage;
        Debug.Log("Damage = " + damage);
        damageCalculated = true;
        diceRolled = false;
    }
}

```
*Figure 3. The script that works out the damage based on the dice roll for the player*

```csharp

public void HealthCalculation()
{
    //After the enemy has rolled, the player's health is reduced based on the enemie's damage
    if (diceScript.lastRoller == "Enemy")
    {
        if (diceScript.damageCalculated == true)
        {
            playerHealth = playerHealth - diceScript.enemyDamage;
            Debug.Log("Player Health = " + playerHealth);
            diceScript.damageCalculated = false;
            diceScript.lastRoller = null;
        }

    }
}

```
*Figure 4. The script that works out the enemies' health after calculating the damage that they will take*

### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

- Instead of just having whatever the dice rolled be the damage, I used an equation that determined the damage based on the amount of sides on the dice, the result of the roll and the max damage that each roller can deal in one role. This adds some balance to the game and also allows for a max damage stat for both the player and the enemy that can both increase and decrease with a leveling system.

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

- A technical difficulty I had when completing this task was from the amount of variables that needed to be accessed from other scripts. This caused quite a bit of confusion and slowing of progress as I had to spend a lot of time looking back on other scripts and changing variable names and types so that they will work in the other scripts too.


## Critical Reflection

### What did or did not work well and why?

- What went well was that after all the messing about with accessing variables from other scripts and renaming variables, the script worked well and as intended.   
- What didn't go well was that due to me using more complex solutions to problems while working, the scripts didn't turn out as tidy as they could have.

### What would you do differently next time?

- I would spend more time planning, if i was to do this again, so that my code would be simpler and tidier.

## Bibliography

French, J. (2020) How to get a variable from another script in Unity (the right way). At: https://gamedevbeginner.com/how-to-get-a-variable-from-another-script-in-unity-the-right-way/ (Accessed  11/10/2024).
<br>

