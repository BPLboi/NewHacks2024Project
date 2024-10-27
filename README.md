# Data Heist
*A game on cybersecurity where you play as the hacker*

![game3](https://github.com/user-attachments/assets/209a45c5-ceed-44ff-9b5f-7613bbc5f097)
[watch on asciinema](https://asciinema.org/a/0Fiwq2O2YknyI3gy4DrDBb5pP)

## Concept

As data becomes an increasingly valuable commodity, threats to security are more important than ever. To increase awareness, we wanted to make an educational but fun game about cyber attacks and recommended defenses.
To generate unique descriptions and levels and to enable human-like interactions, we integrated Google's Gemini API into our project.

## Gameplay

You play as a hacker who can use multiple Attack Cards of different types to extract data (and thus money) from your chosen victims. Victims have certain Defenses (cybersecurity measures) that protect them against certain Attacks.
The player selects a victim and an attack. If the victim has the appropriate defense, the attack fails. Otherwise, the player is prompted to complete a small task to carry out the attack.
- Phishing attack: The player must write a phishing email to extort money from the victim. An AI determines if the phishing attempt was successful or not.
- Metadata attack: The player is given AI generated metadata belonging to a fictitious image, and must identify personal information.
- Person in the middle attack: An AI produces a sample text message from the victim intercepted by the player, and the player must decide if it reveals personal information.
- Fingerprinting attack: The player is presented with data on the victim's ad engagement, and must choose an ad category to target.
- Hack attack: The player gains access to the victim's device and installs malicious software.
Each successful attack provides the player with a random amount of money, while unsuccessful attacks cause a loss of money.
The game ends when all Attack Cards are exhausted.

## 
