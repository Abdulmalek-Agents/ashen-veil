# 🛠️ Unity Setup Guide — Ashen Veil

> **v0.2.1: Unity 6 LTS (6000.4.4f1) target. No proxy server, no API key, no internet config required.**

## Prerequisites
- Unity Hub + Unity **6 LTS (6000.4.4f1)** with Windows IL2CPP module
- All assets from `03_ASSET_PLAN.md` in your Inventix account

## Step 1 — New Unity project

Unity Hub → New → select Editor **6000.4.4f1** → template **Universal 3D** → name `AshenVeil`.

## Step 2 — Drop repo in

```bash
git clone https://github.com/Abdulmalek-Agents/ashen-veil.git
```

Copy `Assets/_Project/` and `.gitignore` to the Unity project. Unity recompiles — zero errors.

## Step 3 — Render pipeline

Graphics: URP 17.x assigned (Unity 6 default). Color Space: Linear. Quality: High (PC), Low tier with HDR off.

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

> **Unity 6 note:** if any package imports with pink materials, run **Edit → Rendering → Render Pipeline Converter → Built-in to URP**.

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
7. Place a Bonfire prefab at start and after the boss. On each bonfire's `BonfireCheckpoint`, drag the child `BonfireEcho` reference into the `echo` field; assign `whisperBank` and (optionally) `firstRestBank`.
8. **Unity 6 camera:** add a **CinemachineCamera** (3.x) with a **CinemachineOrbitalFollow** component, parented to the player. Set Look-At + Follow.
9. `[Mission01Director]` GameObject with `Mission01Director.cs`. Wire bonfires + boss death event.
10. Create `MissionData_M01.asset` with 7 objectives (GDD §6). Add to MissionDatabase.

Build idx 3 (after Hub at 2).

## Step 8 — Author the Echo line banks

For each bonfire (or share across bonfires):

1. **Create → Inventix → Dialogue → Line Bank** → `LineBank_Echo_Generic.asset`.
2. Fill `lines` with 25 hand-authored Echo whispers (voice guide: ancient, weary, occasionally amused; refer to player as 'small flame' or 'kindling').
3. (Optional) `LineBank_Echo_FirstRest.asset` for first-rest variants.
4. Drag the bank into the `BonfireEcho.whisperBank` field on each bonfire.
5. (Optional) drop wav clips into the `voiceOver` array (parallel to `lines`).

## Step 9 — Playtest

Open Bootstrap → Play. New Game → M01 loads → fight 4 corridor skeletons → 3 courtyard skeletons → Hollow Warden 2-phase fight → Mission Complete. Bonfires should fire an Echo whisper on first contact.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Pink materials | Render Pipeline Converter (Built-in → URP) |
| `CinemachineFreeLook` missing | Use Unity 6's CinemachineCamera + CinemachineOrbitalFollow |
| Boss never enters Phase 2 | HollowWardenBoss `Phase2HpThreshold` mis-wired |
| Anime VFX hangs | Ensure Anime Powers VFX is in ObjectPool, not Instantiated |
| Bonfire silent on rest | `BonfireEcho` reference not wired on `BonfireCheckpoint`, or `whisperBank` empty |

## After M1

Tag `v0.2.1-mission1-playable`. Author M2 by duplicating scene + new MissionData asset + EnemyController references to Wyvern instead of Skeleton.
