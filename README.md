# CROWN CLASH // PROTOTYPE 2026

<div align="center">
  <p>✦ <i>A competitive local multiplayer experiment centered around control, pursuit, and possession.</i> ✦</p>
</div>

---

### // OVERVIEW
Crown Clash is a 2D local multiplayer party game developed in Unity. The objective is deceptively simple: acquire the crown and maintain possession for as long as possible before the match timer expires.

Beneath this straightforward premise lies a constant tension between evasion and pursuit. Every second holding the crown contributes to a player's score, forcing the crown bearer to navigate the arena while the opponent relentlessly attempts to reclaim control.

The project was developed as an exploration of real-time competitive systems, player movement, state management, and rapid gameplay prototyping.

### // TECH STACK
Built with a focus on gameplay iteration and modular systems:

* **Engine** | Unity
* **Language** | C#
* **Input** | Unity New Input System
* **UI** | TextMeshPro
* **Level Design** | Tilemap System
* **Physics** | Rigidbody2D & Collider2D
* **Version Control** | Git & GitHub

### // CORE GAMEPLAY LOOP

```text
Acquire Crown
      ↓
Earn Time-Based Score
      ↓
Avoid Opponent
      ↓
Lose Crown on Contact
      ↓
Reclaim Control
      ↓
Highest Crown Time Wins
```

The gameplay emphasizes positioning, route optimization, and spatial awareness rather than direct combat mechanics.

### // SYSTEM LOGIC

* **Crown Ownership System** | The crown maintains a single active holder and dynamically transfers ownership when stolen.
* **Time-Based Scoring** | Players accumulate score through crown possession duration rather than eliminations or objectives.
* **Match State Management** | Centralized game flow controls timer progression, winner determination, and end-of-match transitions.
* **Local Multiplayer Architecture** | Independent input maps allow multiple players to share a single device while maintaining isolated control schemes.
* **Animation State Control** | Directional movement and idle states are managed through an Animator-driven state machine.
* **Arena-Based Interaction** | Environmental obstacles influence movement paths and create opportunities for pursuit and escape.

### // DEVELOPMENT OBJECTIVES

This prototype was primarily created to gain practical experience with:

* Unity's New Input System
* State-driven gameplay architecture
* Local multiplayer implementation
* Tilemap-based level construction
* 2D animation workflows
* UI integration and game state feedback
* Git-based project management

### // CURRENT FEATURE SET

* Two-player local multiplayer
* Crown pickup and transfer mechanics
* Real-time possession scoring
* Match timer system
* Winner determination screen
* Obstacle-based arena navigation
* Directional character animation
* Restartable gameplay loop

### // PHILOSOPHY

The project explores a simple design principle:

> **Control is temporary. Retention is the challenge.**

Rather than rewarding aggression through combat, Crown Clash creates tension through possession. Every second spent holding the crown increases a player's lead while simultaneously increasing the pressure of being pursued.

The result is a compact competitive experience where movement, positioning, and decision-making determine victory.