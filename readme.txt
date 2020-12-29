Tilisiirtolomakkeen rakentaja viivakoodiominaisuudella.
-Käytetty Finanssiala ry:n viivakoodijärjestelmäversiota 4.
-Rakentaa käyttäjän haluaman tilisiirtolomakkeen ja tulostaa siihen
koneluettavan viivakoodin (suomalainen ver.4)


Rakenettu: 
SharpDevelop 4.4

Kieli: 
C#

Testi:
Ajettu Pankkiviivakoodi-opas-2.pdf mukaiset testisarjat.
Testilaskussa 5 ei voitu käyttää ohjeen mukaisia nolla-arvoja, 
ne voidaan ottaa käyttöön esim. lisäämällä checkbox, joka painettuna myös disabloi kalenterin.

Muutama ensimmäinen viivakoodi on tarkastettu laitteistolla:
OP-Mobiili Samsung J5:ssä, loput silmämääräisesti.
Varoitus: käyttää käypiä arvoja, älä maksa laskuja.

Testisarjojen tulosteet:
tilisiirtotallenne.lasku{0}.bmp
{0}->1,2,3...9

Lähdekoodi:
tilisiirtouusi -kansio

Muodostus:
Huom: Ohjelma ei käytä nimiavaruutta System.IO testiturvallisuussyistä.

Rakenna C:\TEMP -kansio manuaalisesti. 

Lisää edellämainittuun kansioon 
tilisiirtocanvas.bmp
code128.ttf
manuaalisesti em. syystä.

Rakenna ja aja käyvällä C# developer-työkalulla.





Huomautus:
Vain tutkimuskäyttöön. Mitään tiedostoa ei saa käyttää sellaisenaan mihinkään.
code128.ttf numerojärjestys riippuu kyseisen tiedoston logiikasta. 
Operaatiot.cs operaatioluokan kommentit kertovat tästä tarkemmin.
Luokkien kapselointi on löyhää, se kannattaa muuttaa jatkojalostusvaiheessa.

 
Lue myös alla oleva:

Disclaimer:
For scientific purposes only. 
No file of this repository should be used "as-is" in financial and/or private use.
ABSOLUTELY NO WARRANTY.
UNDERSTAND THE SOURCE CODE AND MAKE YOUR OWN ADJUSTMENTS.
I HAVE NOTHING TO DO WITH OP Financial Group, EDITA Publishing OY OR FINANSSIALA RY, THEY ARE MY SCIENTIFICAL SOURCES.
ALL FILES MAY HAVE THEIR OWN COPYRIGHTS, I HAVE INCLUDED THEM ONLY WITH "FAIR SCIENTIFICAL USE" -PURPOSES

"FAIR SCIENTIFICAL USE" IS PROTECTED BY U.S. AND EU. LAW, NAMELY:
U.S. CONSTITUTION, ARTICLE ONE, SECTION EIGHT
EU. Directive 2001/29/EC



INCLUDED FONT FILE IS FOR SCIENTIFICAL TEST PURPOSES ONLY, GIVE IT NOT TO FREE USE.
INCLUDED MANUALS ARE NOT MINE, AND THEY ARE AVAILABLE ON INTERNET BY FINANSSIALA RY:

https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjIqIbNyvPtAhWIuIsKHfYOD6IQFjABegQIARAC&url=https%3A%2F%2Fwww.finanssiala.fi%2Fmaksujenvalitys%2Fdokumentit%2FPankkiviivakoodi-opas.pdf&usg=AOvVaw019vgcS-ALk619XNmbXpZn

https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwiC2svfyvPtAhUFlIsKHYXyD2IQFjAAegQIAxAC&url=https%3A%2F%2Fwww.finanssiala.fi%2Fmaksujenvalitys%2Fdokumentit%2FTilisiirto-opas.pdf&usg=AOvVaw3yCDeXkMz_sBrkLFg-3Kna


