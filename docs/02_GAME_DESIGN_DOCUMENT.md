# 📜 Game Design Document — Ashen Veil

## 1. High-concept

You are a **Veiled** — a hollow warrior whose soul shelters a slumbering god. The kingdom of Eldermarch has fallen to seven Hollow Lords, each a former god-bearer who lost themselves to the curse. Pierce their domains, claim their relics, and decide at the end: free your god, or kill it.

**Player fantasy:** 'I am the impossible blade, weighted with divinity.'

**Emotional journey:** Frailty → grit → mastery → dread (as you realise what you carry) → catharsis.

**Pillars (do not violate):**
1. **Punishing but fair.** Every death teaches.
2. **Stylized over realistic.** Visual clarity > photorealism.
3. **Story through environment + AI lore companion.** No exposition dumps.

## 2. Core game loop

`Bonfire → Explore biome → Combat minor enemies → Find next bonfire → Defeat Hollow Lord → Return to hub → Spend Embers → Next biome`

## 3. Player verbs

| Verb | Input | Unlocked | Notes |
|---|---|---|---|
| Move / sprint | WASD / Shift | M1 | Stamina-gated sprint |
| Light attack | LMB | M1 | 3-hit combo |
| Heavy attack | RMB hold | M1 | Charged, breaks guard |
| Dodge / roll | Space | M1 | I-frames, stamina cost |
| Block / parry | LeftCtrl | M1 | Parry window 250ms |
| Ki burst (anime power) | Q | M1 | Charge via combat hits |
| Lock-on | MouseMiddle | M1 | Camera focus on enemy |
| Use estus / heal | R | M1 | Limited per bonfire |
| Talk to Echo Companion | T | M1 | Opens Claude AI dialogue |

## 4. Progression

| System | M1 reveal | Late-game ceiling |
|---|---|---|
| Health | 100 | 300 |
| Stamina | 80 | 200 |
| Skill points | 0 | 50 |
| Skill tree branches | 1 of 3 | 3 (Steel / Spell / Spirit) |
| Bonfires lit | 1 | 24 |
| Hollow Lords defeated | 0 (intro tutorial only) | 7 |
| Anime-power tiers | 1 | 5 |

## 5. Mission structure (6 Hollow Lords + finale)

| # | Hollow Lord | Biome | Asset draw |
|---|---|---|---|
| **1** | The Hollow Warden (tutorial boss) | Crumbling outer keep | Fantasy Castle Env + Skeleton Warrior |
| 2 | The Roost Tyrant (Wyvern) | Mountain rookery | Stylized Creatures #2 Wyvern |
| 3 | The Hexed Serpent (Naga) | Drowned cathedral | Naga + Fantasy Castle |
| 4 | The Forge Wretch (Troll-king) | Lava forge | Cave Troll + Sci-Fi Industrial Props (re-painted) |
| 5 | The Plague Maw (Manticore) | Hexed wood | Manticore + Spells Pack poison |
| 6 | The Mirrored Saint (mirror duel) | White cathedral | BoZo elite + Cutscene Engine |
| Finale | The Sleeping God | Astral plane | Anime Powers Pack peak |

## 6. Mission 1 — *The Hollow Warden* (scene-by-scene)

**Goal:** Tutorialise combat, deliver a satisfying first boss. **Duration:** 25–40 min.

**Flow:**
1. Black fade in — you are kneeling at a cold bonfire. Echo Companion speaks (Claude-generated greeting).
2. Combat tutorial corridor — 4 skeleton warriors, each teaching one verb.
3. Open courtyard — first patrol of 3 skeletons; player can stealth-pull.
4. Inner sanctum — the Hollow Warden boss fight; 2 phases.
5. Victory cutscene — first Ember claimed. Bonfire opens for fast travel.

**Objectives:**
- `m1_first_strike` (DefeatEnemies, 1)
- `m1_learn_dodge` (Custom, 1)
- `m1_learn_parry` (Custom, 1)
- `m1_clear_corridor` (DefeatEnemies, 4)
- `m1_clear_courtyard` (DefeatEnemies, 3)
- `m1_defeat_warden` (DefeatEnemies, 1)
- `m1_optional_find_journal` (CollectItems, 1, optional — hints at lore)

## 7. Combat detail

**Stamina:** Light attack 12, heavy 25, dodge 20. Regenerates 30/sec when not attacking.
**Poise:** Player has 50; enemies vary. Heavy attacks chip poise.
**Damage formula:** `dmg = base * (1 + skillBonus) * (isCriticalHit ? 1.8 : 1)`.
**Death:** Drop accumulated Embers at death spot; reclaim by reaching it. Die again before reclaiming → permanent loss.

## 8. Echo Companion (Claude AI)

A fragment of your sleeping god, manifested as a soft blue flame at every bonfire. Press T to ask anything. Claude answers in character — cryptic when asked about story, helpful with hints, witty with banter.

Full integration spec in `05_AI_COPILOT_INTEGRATION.md`.

## 9. UI

| Screen | Asset |
|---|---|
| Main menu | Heat UI |
| HUD | Custom (health, stamina, ki, estus) |
| Bonfire menu | Skill Tree Builder + custom panels |
| Boss intro card | Heat UI lower-third |

## 10. Audio

- Music: Orchestral + choir; commission OST.
- SFX: weapon clashes, monster vocalisations from Fantasy Monsters Bundle audio.

## 11. Accessibility

- Difficulty options (Story / Standard / Hollow). Story mode reduces damage by 50%, doubles I-frames.
- Hold-to-toggle for sprint/block.
- Colourblind presets.
- Optional auto-parry assist.

## 12. Cut-list (scope guard)

1. Mirrored Saint mission (M6) can be cut, jumping to finale.
2. Skill Tree third branch (Spirit) deferred.
3. Optional 'Hex Reliquaries' collectibles.

**Never cut:** Hollow Warden boss, Echo Companion, Anime Power burst.

✅ **Approved.**
