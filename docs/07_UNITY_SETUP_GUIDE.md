# 🛠️ Unity Setup Guide — Ashen Veil

## Prerequisites
- Unity 2022.3.30f1 LTS + Windows IL2CPP
- All assets from `03_ASSET_PLAN.md` in your Inventix account
- Node.js 18+ for AI proxy
- Anthropic API key

## Step 1 — New Unity project

Unity Hub → New → 3D (URP) Core → name `AshenVeil`.

## Step 2 — Drop repo in

```bash
git clone https://github.com/Abdulmalek-Agents/ashen-veil.git
```

Copy `Assets/_Project/` and `.gitignore` to the Unity project. Unity recompiles — zero errors.

## Step 3 — Render pipeline

Graphics: URP assigned. Color Space: Linear. Quality: High (PC), Low tier with HDR off.

## Step 4 — Import assets (in order)

1. Heat UI
2. Character Controller Pro
3. Traversal Pro
4. Fantasy Castle Environment
5. The Medieval Castle
6. Stylized Dungeons
7. BoZo Modular Characters Fantasy
8. Fantasy Monsters Bundle
9. Stylized Fantasy Creatures #2
10. Anime Powers Pack
11. Spells Pack
12. 100 Special Skills Effects Pack
13. Magic Arsenal
14. Realistic Blood VFX
15. Volumetric Blood Fluids
16. Ultimate Mesh FX
17. Screenspace VFX
18. Lumen FX 2
19. Cutscene Engine
20. Skill Tree Builder
21. Animation Composer System
22. Eyes Animator
23. VoluSmokeFX

Move each into `Assets/_Project/Art/...` after import.

## Step 5 — Bootstrap scene

New Scene Empty → `Scenes/Bootstrap.unity` → `[Game]` GameObject with `GameBootstrap` component. Build idx 0.

## Step 6 — MainMenu scene

New Scene → `Scenes/MainMenu.unity`. Drag Heat UI prefab. Attach `MainMenuController`. Create + assign `MissionDatabase.asset`. Build idx 1.

## Step 7 — Mission 1 scene

New Scene → `Scenes/Mission01_HollowWarden.unity`.
1. Drop Fantasy Castle Environment 'outer keep' prefab.
2. Drop Stylized Dungeons corridor segment connecting to keep.
3. Player_Veiled prefab at start of corridor.
4. 4 skeleton prefabs (Fantasy Monsters Bundle) spaced along corridor.
5. Courtyard with 3 skeletons.
6. Hollow Warden boss arena (large keep room). Place Hollow Warden boss prefab.
7. Place a Bonfire prefab at start and after the boss.
8. Drop a Cinemachine free-look 3rd-person camera, parent to player.
9. `[Mission01Director]` GameObject with `Mission01Director.cs`. Wire bonfires + boss death event.
10. Create `MissionData_M01.asset` with 7 objectives (GDD §6). Add to MissionDatabase.

Build idx 3 (after Hub at 2).

## Step 8 — AI proxy

```bash
cd server/copilot-proxy && cp .env.example .env  # set ANTHROPIC_API_KEY
npm install && npm run dev
```

## Step 9 — Echo Companion persona

Create → Inventix → AI Copilot → Persona → `Persona_Echo.asset`. Paste system prompt from `05_AI_COPILOT_INTEGRATION.md`.

## Step 10 — Playtest

Open Bootstrap → Play. New Game → M01 loads → fight 4 corridor skeletons → 3 courtyard skeletons → Hollow Warden 2-phase fight → Mission Complete.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Pink materials | URP convert; rebuild lighting |
| Boss never enters Phase 2 | HollowWardenBoss `Phase2HpThreshold` mis-wired |
| Anime VFX hangs | Ensure Anime Powers VFX is in ObjectPool, not Instantiated |
| Claude no reply | Proxy not running; check port 8787 |

## After M1

Tag `v0.1-mission1-playable`. Author M2 by duplicating scene + new MissionData asset + EnemyController references to Wyvern instead of Skeleton.
