# VR AIrHockey

In deze tutorial wordt uitgelegd hoe je een eigen VR air-hockey game maakt die gebruik maakt van machine learning. Er staat stap voor stap beschreven hoe je tot deze oplossing komt. Er wordt uitgelegd welke installaties, objecten en scripts er vereist zijn om een werkende VR air-hockey game te maken. De tutorial beschrijft hoe je de AI traint en welke resultaten je kan verwachten uit deze training.

## Inhoudsopgave

1. [Benodigdheden](#1-benodigdheden)
1. [Inleiding](#2-inleiding)
1. [Spelverloop](#3-spelverloop)
1. [Agent](#4-agent)
1. [Objecten](#5-objecten)
1. [Scripts](#6-scripts)
1. [Training](#7-training)
1. [One-pager](#8-one-pager)
1. [Conclusie](#9-conclusie)

## 1. Benodigdheden

1. Unity Hub 2.4.1 (<https://unity3d.com/get-unity/download>)
1. Unity versie 2019.4.11f1 (<https://unity3d.com/unity/whats-new/2019.4.11>)
1. ML-agents release 6 package (<https://github.com/Unity-Technologies/ml-agents/releases/tag/release_6>)
1. Visual Studio Community  (<https://visualstudio.microsoft.com/downloads/>)
1. Python 3.8.6 (<https://www.python.org/downloads/>)
1. Oculus Quest 2 (VR-Bril)

## 2. Inleiding

VR AIrHockey is een spel waarbij een speler tegen een AI speelt. De speler kan met zijn VR controllers de zogenaamde `Hammer` vastnemen om te slagen tegen de `Puck`. Op deze manier moet hij 5 punten halen om te winnen.

Doorheen dit document worden drie belangrijke aspecten aangeleerd. Ten eerste het bouwen van een Unity omgeving om het spel te kunnen spelen. Ten tweede een Artificial Inteligence Agent aanleren hoe hij het spel airhockey moet spelen. En ten derde hoe we deze omgeving kunnen combineren met het VR-aspect.

|          Student         |      Email      |
|--------------------------|:---------------:|
| Kristof De Winter        | s106749@ap.be   |
| Felix Neijzen            | s109332@ap.be   |
| Bram Van Chronenburg     | s109544@ap.be   |
| Jonathan De Baerdemaeker | s108835@ap.be   |
| Luka Hendrickx           | s109055@ap.be   |

## 3. Spelverloop

De speler start het spel met een `Puck` te nemen en die op het veld te plaatsen met zijn controllers. Eenmaal de `Puck` geplaatst is start het spel en kan de spelere met zijn `Hammer` slagen tegen de `Puck`. Op deze manier kan de speler scoren in de goal van de tegenstander. Als de speler of de AI 5 punten kan scoren bij zijn tegenstander is hij gewonnen. Hierna stopt het spel.

## 4. Agent

### 4.1 Observaties

De ML-Agent kan 3 verschillende objecten observeren met zijn 3D Ray Perception Sensor. De `Puck` kan hij observeren om te bepalen wanneer hij er tegen moet slagen. Natuurlijk moet hij ook de `GoalPlayer` observeren om de richting te bepalen waarnaar hij de `Puck` slaagt. Aangezien er in Air-Hockey ook verdedigt kan worden moet hij de `Hammer` van de speler ook kunnen observeren.

### 4.2 Acties

Inhoudelijk hebben 5 acties voor de ML-Agent:

1. Beweging vooruit
1. Beweging naar rechts
1. Beweging achteruit
1. Beweging naar links
1. Geen beweging

Doorheen het spel zal de ML-Agent voortdurend beslissingen maken tussen deze 5 acties.

### 4.3 Beloningen

Tekst..

## 5. Objecten

### 5.1 Environment

Tekst..

### 5.2 Hammer

Tekst..

### 5.3 Puck

Tekst..

### 5.4 Wall

Tekst..

### 5.5 Goal

Tekst..

## 6. Scripts

### 6.1 Environment

Tekst..

### 6.2 Hammer

Tekst..

### 6.3 Puck

Tekst..

## 7. Training

Tekst..

### 7.1 Hoe te trainen

Tekst..

### 7.2 Trainingsresultaten

Tekst.. + TensorBoard afbeeldingen + Beschrijving TensorBoard afbeelding

### 7.3 Opvallende waarnemingen

Tekst..

## 8. One-pager

Tekst..

## 9. Conclusie

Tekst..
