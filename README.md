# rolito
Patapon inspired adventure rhythm game system remade in unity and c#

# Goals
- replicate Patapon's beat system
- traverse the scene on with the march command
- attack enemies with the attack command
- defend against enemies with the defend command

# Operation
Listen to the rhythm in the background, press 'f' on each beat for a forward input, 'a' for an attack input and 'd' to defend. The better the timing with the beat the better the sound and stronger the command, each command is 4 beats long. Inputs alone do not do anything, whole commands must be input within 4 beats.

- march: f f f a
- attack: a a f a
- defend: d d f a
- summon(unimplemented): s ss ss 

Internally the game will rate the input depending on how on beat it was, 'F' for perfect march, 'A' for perfect attack and so on, lower case for good inputs & bad inputs.
After a command the Patapon will sing back to the player which is also 4 beats long.
As the player enters inputs the complexity of the music will increase but the timings stay the same for ease.
