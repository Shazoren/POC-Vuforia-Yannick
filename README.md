# Projet AR Carte de Visite (Unity + Vuforia)

## 🎯 Description
Ce projet est une application de Réalité Augmentée réalisée avec **Unity** et **Vuforia**.  
L’idée : scanner une carte de visite imprimée (ou affichée à l’écran) pour faire apparaître un modèle 3D interactif de la carte en AR.

L’objectif est double :
- Montrer comment **augmenter un support imprimé** (carte de visite) avec des contenus numériques.  
- Explorer les fonctionnalités d’interaction possibles avec Vuforia et Unity.

---

## 🛠️ Fonctionnalités

### 1. Détection AR (Vuforia)
- L’application reconnaît une **image cible** (recto de la carte de visite).  
- Une **carte 3D** est générée en surimpression.  
- La taille et l’échelle de la carte virtuelle respectent la taille réelle de la carte.

### 2. Menu d’accueil
- **Lancer l’AR** : ouvre la scène AR avec la caméra.  
- **Quitter l’application** : ferme proprement l’app.

### 3. Interactions utilisateur
- **Tap sur la carte** : change la couleur de la carte (cycle de couleurs prédéfinies).  
- **Slider UI** : permet de redimensionner (scale) la carte en temps réel.  
- **Swipe horizontal** : fait tourner la carte sur elle-même (droite/gauche).  

### 4. Son & Feedback
- **Musique de fond** dans le menu et la partie AR.  
- **Effet sonore** au clic sur la carte (feedback d’interaction).

### 5. Animations & Effets
- Rotation fluide de la carte (avec inertie au swipe).  
- Possibilité d’ajouter des **VFX Unity** (ex. surbrillance, glow, particules).

---

## 📸 Démo d’utilisation
1. Lancer l’application.  
2. Depuis le menu, cliquer sur **Lancer l’AR**.  
3. Pointer la caméra vers l’image cible (carte de visite).  
4. Interagir avec la carte :  
   - Tap → changer de couleur.  
   - Slider → changer la taille.  
   - Swipe → rotation droite/gauche.  

---

## ✅ Critères du projet (grille de notation)

- **Application fonctionnelle en AR avec Vuforia** → ✔  
- **2 interactions minimum** (tap + slider + swipe) → ✔ (3 interactions implémentées)  
- **Menu d’accueil (lancer/fermer)** → ✔  
- **Sons intégrés** (musique + feedback) → ✔  
- **Animation/VFX** (rotation + effets possibles) → ✔  

---

## 📂 Organisation du projet
- `Assets/Scenes/`  
  - `Menu.unity` → scène d’accueil  
  - `ARScene.unity` → scène AR avec Vuforia  
- `Assets/Scripts/`  
  - `SwipeRotate.cs` → rotation au swipe  
  - `TapRaycast.cs` → gestion des taps sur objets 3D  
  - `CardColorCycler.cs` → cycle de couleurs de la carte  
  - `ScaleSlider.cs` → gestion du slider de taille  
- `Assets/Materials/` → matériaux de la carte (recto/verso)  
- `Assets/Textures/` → visuels de la carte de visite  

---

## 🚀 Technologies utilisées
- **Unity** (2021 LTS+)  
- **Vuforia Engine**  
- **C# scripts** (interactions et logique)  
- **Android Build** pour test sur smartphone
