# 🧱 Technical Architecture — Ashen Veil

> v0.2: runtime LLM removed. Echo Companion is a `BonfireEcho` reading `LineBankSO`s.
> v0.2.1: Unity 6 LTS (6000.4.4f1) target.

## 1. Stack

| Layer | Choice |
|---|---|
| Engine | Unity **6 LTS (6000.4.4f1)** |
| Render | **URP 17.x** (Unity 6 default) |
| Scripting | C# 9, .NET Standard 2.1 |
| Input | New Input System |
| Camera | Cinemachine 3.x |
| Async loading | Addressables |
| Save | JsonUtility → persistentDataPath |
| Dialogue | Hand-authored `DialogueNodeSO` + `LineBankSO` |
| Source control | Git + Unity Smart Merge + LFS |

## 2. Folder layout (`Assets/_Project/Scripts/`)

```
Core/        ← shared (every Inventix game)
  GameBootstrap, ServiceLocator, SceneLoader
  Mission/, Save/, Audio/, Checkpoint/, Pooling/
Dialogue/    DialogueNodeSO, LineBankSO, ScriptedDialogueService
UI/          MainMenuController, HUDController
Gameplay/    ← Ashen Veil specific
  Player/     PlayerController, PlayerCombat, PlayerStamina, PlayerHealth
  Combat/     WeaponController, HitboxComponent, ParrySystem
  Enemy/      EnemyController, EnemyAI, EnemyHealth, BossController
  Bonfire/    BonfireCheckpoint, BonfireEcho
  Skills/     SkillNodeSO, SkillTreeController, AbilityRunner
  Mission01/  Mission01Director, HollowWardenBoss
```

## 3. Scenes

| Scene | Build idx |
|---|---|
| Bootstrap | 0 |
| MainMenu | 1 |
| Hub_Veilstead | 2 |
| Mission01_HollowWarden | 3 |
| Mission02..06 | 4-8 |
| Finale_SleepingGod | 9 |

## 4. Combat flow

```
Player LMB → PlayerCombat.LightAttack()
  → Stamina.Drain(12) → Animator.SetTrigger('light')
  → Animation event opens HitboxComponent for 150ms
  → OnHit: applies damage to EnemyHealth + spawns Anime Powers Pack VFX (pooled)
  → If enemy.health <= 0 → EnemyController.Die() → raises EnemyDeathChannelSO
  → MissionManager.ReportObjectiveProgress('m1_clear_corridor')
```

## 5. Boss state machine (HollowWardenBoss)

`Idle → Approach → LightCombo → BackStep → HeavyOverhead → (HP<50%) PhaseTwo` → patterns differ.

## 6. Bonfire system

Lighting a Bonfire:
- Saves player state via SaveService.
- Resets all enemies in the biome.
- Restores estus charges.
- Adds to fast-travel list.
- Triggers `BonfireEcho.OnPlayerRested()` — picks a hand-authored line from the assigned `LineBankSO` (first-rest bank if available; otherwise generic bank).

## 7. Unity 6 (6000.4.4f1) compatibility notes

- **URP** upgraded from 14.x (Unity 2022) to 17.x. Render Pipeline Converter (Built-in → URP) handles any Unity 2022–era asset.
- **Cinemachine** is now 3.x. The old `CinemachineFreeLook` is replaced by `CinemachineCamera` with `CinemachineOrbitalFollow` (used for the 3rd-person souls camera).
- **Render Graph API** opt-in for URP performance — not required for M1.
- **Animation Rigging**, **Splines**, **NavMesh**, **TextMeshPro**, **Addressables**, **New Input System** all work as-is.

## 8. Scalability ✅

| Concern | Resolution |
|---|---|
| Adding M7 | Author MissionData_M07.asset + scene |
| New enemy | Author EnemyDataSO + prefab |
| New skill | Author SkillNodeSO; AbilityRunner reads it |
| New Echo whisper set | Author a new `LineBank_Echo_*.asset`; drop into BonfireEcho |
| Save format | kv dictionary preserves older fields |
| Internet outage breaks game? | ❌ No — fully offline |

## 9. Performance budget (60 fps on RTX 2060 / Steam Deck)

- Draw calls < 1,200
- Triangles < 2M
- Particles < 5,000 (Anime Powers VFX heaviest)
- Memory < 1.5 GB
- GC alloc/sec < 250 KB

## 10. CI

Later: GitHub Actions + `game-ci/unity-builder@v4` (Unity 6 supported).
