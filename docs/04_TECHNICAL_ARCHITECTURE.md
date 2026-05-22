# 🧱 Technical Architecture — Ashen Veil

## 1. Stack

Unity 2022.3 LTS + URP. C# 9. New Input System. Addressables. JsonUtility save. Claude proxy.

## 2. Folder layout (`Assets/_Project/Scripts/`)

```
Core/        ← shared (every Inventix game)
  GameBootstrap, ServiceLocator, SceneLoader
  Mission/    MissionDataSO, MissionDatabaseSO, MissionManager
  Save/, Audio/, Checkpoint/, Events/, Pooling/
AI/          ClaudeCopilotService, AICopilotPersonaSO
UI/          MainMenuController, HUDController
Gameplay/    ← Ashen Veil specific
  Player/     PlayerController, PlayerCombat, PlayerStamina, PlayerHealth
  Combat/     WeaponController, HitboxComponent, ParrySystem
  Enemy/      EnemyController, EnemyAI, EnemyHealth, BossController
  Bonfire/    BonfireCheckpoint, BonfireMenu
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

Bonfires are also where the player talks to Echo Companion (Claude AI).

## 7. Scalability ✅

| Concern | Resolution |
|---|---|
| Adding M7 | Author MissionData_M07.asset + scene |
| New enemy | Author EnemyDataSO + prefab |
| New skill | Author SkillNodeSO; AbilityRunner reads it |
| Save format | kv dictionary preserves older fields |

## 8. Performance budget (60 fps on RTX 2060 / Steam Deck)

- Draw calls < 1,200
- Triangles < 2M
- Particles < 5,000 (Anime Powers VFX heaviest)
- Memory < 1.5 GB
- GC alloc/sec < 250 KB

## 9. CI

Later: GitHub Actions + `game-ci/unity-builder@v4`.
