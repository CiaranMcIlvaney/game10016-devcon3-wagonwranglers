# **Game Design Document**



##### **Desired Game Mechanic**

The desired game mechanic is that the player controls a pan and must keep as many randomly falling objects in the pan as they can while quickly trying to catch more.



##### **Objective statement**

Is it a challenging but fair experience to balance being careful about not losing items with being fast to catch more items?



##### **Intended Experience**

The intended experience is that the player will feel hectic as they try to balance going fast with being cautious, and they will feel achieved as they get a higher score each time they play. The gamer motivation models we're going for are Challenge and Excitement.



##### **Design Rational**

This mechanic is unique because while some games have catching falling objects as a mechanic, we are shaking it up by making each item falling down as close to real physics as we can. This means the player has to think about the items they're catching. For example, if an anvil and a pillow fall down, the pillow is going to be easier to keep balance in the pan, but the anvil might be more points. The player has to decide what they prioritize: more items but they're light, or fewer items but they're heavier.



### **GDD Section: Specification**



##### **Concept**

The concept is that the player controls a cart that can move around on a flat plane. There are falling objects that the player must run around to collect and store inside the cart. Each item is has weight and friction coefficients that match very closely to real life. Heavy objects are worth more but slow the player down and make balancing harder. There are also bombs that drop that will send items flying out of your cart.



##### **Setting**

The game will be set on a flat plane, the look is currently undetermined.



##### **Game Structure**

The game will begin with the player in the middle of the plane. Then, the timer starts, and the player must quickly run around catching items. More items fall faster as the timer nears zero. After reaching zero the end state will initiate, showing the player how much points they earned based on how many items they ended with.



##### **Players**

The game would be single player only, but if we were to add multiplayer, it would be in the form of one player moving the pan and one player rotating items to fit on the pan.



### **Feedback Section**



* Balancing WASD with the arrow keys was wonky to control. Reworking some of the controls will help with this.
* The pan's friction was too slippery, items fell off way too fast. Changing the friction coefficient on the pan should make item balancing more fair.
* The pan takes up too much real estate on screen. Zooming out the camera to see more of the landscape should fix this.



## **Physics Notes (By Olwyn)**

All numbers provided were sourced from Google search, more specifically, Google’s AI Overview.



Friction Coefficients and Numbers Used



#### Cast Iron

Friction coefficient was stated to be about 1.1, however to keep the gameplay a bit more interactive, I only put the friction on the pan to 0.5, as though there was some sort of lubricant



#### Coin

Friction coefficient stated to be between 0.3 and 0.7 for static friction, and so the friction was set to 0.7 as there was a planned setting to have multiple coins drop at once in the same place, so it would make it easier to catch multiple without reaching too far beyond reality



#### Crown

Friction coefficient for gold was stated at 0.2 to 0.3, however the drag settings in unity were set to 0.4 to make things a little easier with managing the angle and rotation of the player's frying pan



#### Dice

Friction coefficient was stated to be anywhere from 0.05 to over 1.0, with dry conditions increasing the friction coefficient. I opted to leave the drag levels at 0.7 due to the mass of the object as well as the apparent material, with plastic not being very slippery on cast iron



#### Wood

Friction coefficient has many variables for wood, ranging from 0.25-0.5 for wood-on-wood, and gets higher gradually with moisture. The friction for the crates in our game is set to 0.4, as it feels proper with the mass of the objects and fits well with the challenge of the game





### **Sources Cited**

[**https://assetstore.unity.com/packages/3d/props/industrial/low-poly-wooden-crate-308305**](https://assetstore.unity.com/packages/3d/props/industrial/low-poly-wooden-crate-308305)

[**https://assetstore.unity.com/packages/3d/props/low-poly-objects-pack-241890**](https://assetstore.unity.com/packages/3d/props/low-poly-objects-pack-241890)

[**https://assetstore.unity.com/packages/package/157552**](https://assetstore.unity.com/packages/package/157552)



