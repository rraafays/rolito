# rolito
Patapon inspired adventure rhythm game system remade in unity and c#

# Goals
- replicate patapon's beat system
- traverse the scene on with the forward command
- attack enemies with the attack command

# Operation
Listen to the rhythm in the background, press 'f' on each beat for a forward input and 'a' for an attack input. The better the timing to the beat the better the sound and stronger the command, each command is 4 beats long. Inputs alone do not do anything, whole commands must be input within 4 beats.

- forward: f f f a
- attack: a a f a

Internally the game will rate the input depending on how on beat it was, 'F' for perfect forward, 'A' for perfect attack, lower case for good inputs and 'x' for a bad input.
