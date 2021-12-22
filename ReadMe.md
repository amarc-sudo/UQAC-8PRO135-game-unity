# UQAC 8PRO135 unity


8PRO135 Programmation avec des moteurs de jeu

* Alexandre MIGNOT MIGA29120104
* Aurelien MARC MARA22050108
* Alexandre Bélisle-Huard BELA23108406

Partie 1 tp7

Le premier bug viens du son, en effet le son est lance plein de fois au demarage comme le demontre cela : 

![song bug](/song.png).

Ce bug viens du fait qu'on fait une boucle de 400 sur le lancement du song, pour corriger cela il faut supprimer la boucle

Le deuxieme bug viens du script delay

![delay bug](/delay.png).

En effet, on peut observer dans le code que la source audio est relancer une deuxieme fois par delay avec 2 seconde d'interval, il suffit de desactiver le script pour regler le soucis
