# Boxing Match

Create a class that will encapsulate a boxing match.

The `BoxingMatch` should have two `Boxer`s and a `Display` for the audience.

The program will be able to start the boxing match, which will run until one of the boxers is knocked out, or until both boxers throw 50 punches each. 
The `50` should be a parameter of the boxing match's  constructor.

# Boxer

The boxer have a 
 - name,
 - weight, 
 - hitpoints (integer), 
 - punch strengths for each of the four main punches (cross, jab, uppercut, hook).
 - agility for each of the four main punches (cross, jab, uppercut, hook).

## Throwing a punch

Once the boxing match starts the boxers take turns throwing punches.

For each punch, the punching boxer randomly selects a punch type, and notifies the receiving boxer that that type of punch is thrown, including the punch strength for t
he specific punch type (use events). The receiving boxer accepts the punch, and randomly defends against it. The defence entails generating a random number between 0 
and the agility value. The defence is then subtracted from the punches strength. If the result is zero or less than zero, the punch is a miss. If it's more than zero, it's a hit, 
and the value of the hit is subtracted from the receiving boxers hitpoints. If the hitpoints drop at or bellow zero, the boxer is knocked out.

The display is notified of the punches status (hit/miss) and its value, and of the cuurent hitpoints of the receiving boxer. If a knockout occurs, the display should show that as well.

After the punch is finished, the boxers change roles, i.e. the punching boxer becomes the receiving boxer, and vice versa.

## Example

Let's say we have a boxing match betwenn Tyson Fury
- 124 kg with 1000 hitpoints
- Strength of: 
  - Cross: 20
  - Jab: 10
  - Uppercut: 25
  - Hook: 20
- Agility for:
  - Cross: 15
  - Jab: 15
  - Uppercut: 30
  - Hook: 15
  
 and Andy Ruiz Jr.
- 128 kg with 1500 hitpoints
- Strength of: 
  - Cross: 26
  - Jab: 16
  - Uppercut: 21
  - Hook: 16
- Agility for:
  - Cross: 26
  - Jab: 26
  - Uppercut: 16
  - Hook: 21
  
Fury goes first, and generates a random number 0-3. He gets 0 - which means that he will throw an Cross for 20 points of damage.  
Ruiz recieves the punch and generates a random number between 0 and his Cross agility, which is 26. He gets 7, which means that actual power of the punch is 20-7=13.  
He updates his hitpoints to 1500-13=1487, and notifies that he has been hit for 13 damage, and now has 1487 hitpoints.  
  
Ruiz goes next, and generates a random number 0-3. He gets 2 - which means that he will throw an Uppercut for 21 points of damage.  
Fury recieves the punch and generates a random number between 0 and his Uppercut agility, which is 30. He gets 24, which means that actual power of the punch is 21-24=-3.  
Since the total power is negative the punch is a miss. Fury notifies that he has been missed.

## Display

The display should at all times display the names and current hitpoints of the boxers.  
It should also display a history of the punches thrown.

## Remarks

The `Boxer` class should not have a reference to the `Display` class
The `Display` class should not have a reference to the `Boxer` class
The `BoxMatch` should have references to both classes and should handle the orchestration.












