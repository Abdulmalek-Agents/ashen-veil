# 🎨 Asset Plan — Ashen Veil

> Net coverage from Inventix inventory: **~90%**.

## 1. Existing inventory used

| Asset | Used for | Critical |
|---|---|---|
| **Fantasy Castle Environment** ($129.99) | Outer keep, M1 boss arena, hub | 🔴 Yes |
| **The Medieval Castle** ($54.99) | M3 drowned cathedral, M6 white cathedral | 🔴 Yes |
| **Stylized Dungeons** ($50) | Inner corridors, M4 forge depths | 🔴 Yes |
| **Medieval Village Megapack** | Hub town outside the keep | 🟡 Helpful |
| **BoZo Modular Characters Fantasy** ($40) | Player Veiled + NPCs at hub | 🔴 Yes |
| **Fantasy Monsters Bundle** ($99.50) | Skeletons, Goblins, Trolls, Demons | 🔴 Yes |
| **Stylized Fantasy Creatures #2** ($149.99) | M2 Wyvern, M3 Naga, M5 Manticore boss | 🔴 Yes |
| **Anime Powers Pack** ($30) | Player Ki bursts, anime-style projectiles | 🔴 Yes |
| **Magic Arsenal** ($30) | Player weapons + Hollow Lord weapons | 🔴 Yes |
| **Spells Pack** ($59.99) | Enemy spells, area-of-effect attacks | 🔴 Yes |
| **100 Special Skills Effects Pack** ($24.99) | Skill ability VFX | 🔴 Yes |
| **Ultimate Mesh FX** ($35) | Boss dissolve / freeze / burn | 🟡 Helpful |
| **Realistic Blood VFX** ($40) | Combat impact decals | 🟡 Helpful |
| **Volumetric Blood Fluids** ($30) | Boss kill volumetric blood | 🟡 Helpful |
| **Character Controller Pro** ($28.99) | Player movement + ability state machine | 🔴 Yes |
| **Traversal Pro** ($45) | Vault / climb / ledge traversal | 🟡 Helpful |
| **Cutscene Engine** ($35) | Boss intros, M6 mirror duel, finale | 🔴 Yes |
| **Skill Tree Builder** ($15) | Bonfire menu skill tree | 🔴 Yes |
| **Heat UI** ($69.99) | Main menu, settings, results | 🔴 Yes |
| **Animation Composer System** ($39.99) | Layered upper/lower body anims | 🟡 Helpful |
| **Lumen Light FX 2** ($35) | Bonfire glow, dramatic god rays | 🟡 Helpful |
| **VoluSmokeFX** ($25) | Atmospheric smoke in dungeons | 🟡 Helpful |
| **Screenspace VFX** ($30) | Damage flash, low-health vignette | 🔴 Yes |
| **Eyes Animator** ($11.99) | NPC eye warmth at hub | 🟡 Helpful |

**Inventory value applied: ~$1,100 across 22 assets.**

## 2. Gap analysis

| Gap | Suggested | Cost |
|---|---|---|
| Final cinematic boss (Sleeping God) | Unique boss asset or commission | $40–$80 |
| OST (orchestral/choir, 6 tracks) | Commission | $300 |
| Voice acting (Echo Companion lines, ~30) | Hire VA | $200 |

**Mission 1 must-buy: $0 (assets fully cover the Hollow Warden).**

## 3. Folder organisation

```
Assets/_Project/
├── Art/{Characters,Environment,VFX,UI,Weapons}
├── Audio/{Music,SFX,Ambient,Voice}
├── Animations/{Player,Enemies,Bosses}
├── Materials/
├── Prefabs/{Characters,Enemies,Bosses,Environment,UI,VFX,Weapons}
├── Scenes/
├── Data/{Missions,AICopilot,Items,Skills,Enemies}
└── Scripts/
```

## 4. Performance tweaks

| Asset | Tweak |
|---|---|
| Fantasy Castle | Bake lightmaps; combine static stones per chamber |
| Stylized Dungeons | Occlusion culling on corridors |
| Stylized Creatures #2 | LOD0/LOD1; cull at 50m |
| Anime Powers Pack | All VFX through ObjectPool |
| Blood VFX | Limit active decals to 32 |
| Spells Pack | Halve particle counts on Low quality |

## 5. Licence ✅

All Unity Asset Store EULA-compliant. Inventix holds all licences. No binaries in repo.

## 6. Post-purchase checklist

- [ ] Import per §1
- [ ] Migrate to `_Project/Art/`
- [ ] Configure URP materials
- [ ] LOD groups on bosses
- [ ] Build Player_Veiled.prefab (BoZo + Character Controller Pro + Animator)
- [ ] Build Skeleton, Goblin, Troll enemy prefabs (with HealthSystem, EnemyAI)
- [ ] Build HollowWarden_Boss.prefab (2-phase Animator)
- [ ] Build Bonfire.prefab (Lumen FX + interaction)
- [ ] Build 6 ability VFX prefabs (Ki burst + elements)
