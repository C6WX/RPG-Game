# RPG - Dice

Fundementals of Game Development

Callum Wade

2404781

## Research

```markdown
### What sources or references have you identified as relevant to this task?

- Since i made a dice rolling script, i wanted to further my research into Random.Range within C#. To do this i looked on the unity documentation website.
```

#### Sources
```markdown
- An opening paragraph about the source stating the author, developer or organisation, this paragraph should explain the source's influence, credentials, critical reception, awards, reputation or any issues with the source. For example, if the source is not reputable. If the source is a game, the issues that occurred during development or if had a poor launch.
- List the aspects analysed in reference to the current task.
- An ending paragraph stating what you enjoyed or disliked, what you agreed with or not agree with.

Making a dice roll within C# uses Random.Range which i have learnt during previous work i have done inside of unity. However i still learnt more on Random.Range to see how far it can go when programming. This lead me to read the unity documentation on Random.Range. (Technologies, s.d.)

Within the website I found it interesting how Random.Range can be used for things such as getting random numbers to determine an objects position within a Vector3.

I liked that the website showed me another way I could use Random.Range but i felt that only showing one way of using it felt like too little of an example of it's use.

#### Game Source
Five Nights At Freddys is a horror game developed by Scott Cawthon. Within the programming of the game, Random.Range is used to determine the characters movement(Five Nights at Freddy's, 2014).

Within the game, enemies have to move closer to the player to make the player lose. The way they are programmed is so that, based on the difficulty each enemy is set to, a number between 1 and 20 is selected to be there movement number, if the number that the Random.Range choses is less then the movement number, then the character can move closer to the player, if it's not below the number then they can't move. In the custom mode the player can change the enemie's difficulty up to 20 which means evertime the enemy gets a chance to move, they can move.

I find this to be a great and really interesting use of how a single bit of code can be used as the main piece of code for a whole game and how advanced a single piece of code can become when used right.

```

## Implementation

### What was the process of completing the task? What influenced your decision making?

- To complete the task i started with making the six sided dice by making a public void for the first dice. Within the void i used a Random.Range(1,7) so that it generated a number like if you rolled a six sided dice. I assigned the result from the the Random.Range with an int variable called d6Result. The next line was a Debug.Log that sent the number generated to the log.

<br>

```csharp
    public void RollD6()
    {
        int d6Result = Random.Range(1, 7);
        Debug.Log("D6 rolled a " + d6Result);
    }
```
*Figure 1. An example of the script used for rolling the six sided dice*

-Then i just copied the code for the other two dices but changed the variables and values to match the dice that they will be used for.

<br>

```csharp
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
```
*Figure 2. An example of the script used for the D12 and D20*

- Then i just used a void Start to call all the voids to roll all the dices at once

<br>

```csharp
void Start()
{
    RollD6();
    RollD12();
    RollD20();
}
```
* *
### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

- A new thing i did, different from the task is adding buttons to roll each seperate dice manually.

<br>

<img src="Buttons example.png" width="100" height="100">
<br>
*Figure 4. An example of the buttons i created to manually roll each dice.*

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

- Within the project I had one difficulty with a changing the text one the buttons. This is because the way you change the text had changed since i last used it. I overcame this by asking how someone else, who had did it, did it.

## Critical Reflection

### What did or did not work well and why?

- Apart from the small problem with the button text, I think everything went well with this task. This would be because I have previosly done something similar to this in a personal project.

### What would you do differently next time?

- Next time I would work more on the game idea before starting the task so the end script would link more to my idea for the game i want it to end up turning into.

## Bibliography

Technologies, U. (s.d.) Unity - Scripting API: Random.Range. At: https://docs.unity3d.com/ScriptReference/Random.Range.html (Accessed  04/10/2024).

