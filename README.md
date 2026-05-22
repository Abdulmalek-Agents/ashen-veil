# ⚔️ Ashen Veil

> A stylized Souls-like action RPG. Anime-power combat in a fallen kingdom.
> You are a Veiled — a hollow warrior bound to a slumbering god. Pierce the cursed kingdom of Eldermarch, defeat the seven Hollow Lords, and decide whether to free or destroy the god in your soul.

| | |
|---|---|
| **Genre** | Stylized Souls-like Action RPG |
| **Platforms** | PC (Steam) primary |
| **Engine** | Unity 2022.3 LTS + URP |
| **Target frame-rate** | 60 fps on mid-range PC |
| **Mission 1 scope** | Tutorial duel → first bonfire → first Hollow Lord (tutorial boss) |
| **Designed for** | 6 missions (one per Hollow Lord biome) |
| **AI co-pilot** | Claude-powered Echo Companion (lore-master, hint-giver) |

## Why this game

| Signal | Source |
|---|---|
| Souls-likes are top revenue earners | Black Myth: Wukong (~$1B), Lies of P, Elden Ring expansion |
| Stylized (vs. realistic) souls-like is open lane | Lies of P + AAA realistic; stylized indie path under-served |
| Anime-power VFX is highly marketable | Anime Powers Pack assets give us authentic flair |
| Reddit r/Soulslikes consistently asks for shorter, polished souls-likes | Our 6-mission structure matches |

Detailed evidence in [docs/01_IDEATION_AND_TRENDS.md](docs/01_IDEATION_AND_TRENDS.md).

## Repo layout

```
ashen-veil/
├── README.md, CHANGELOG.md, LICENSE, .gitignore
├── docs/  (7 critic-approved design docs)
├── Assets/_Project/  (Unity-ready scripts, ScriptableObject guide, scenes/prefabs/art/audio folders)
└── server/copilot-proxy/  (Claude API proxy)
```

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. New Unity 2022.3 LTS URP project; copy `Assets/_Project/` in.
3. Import: Fantasy Castle Environment, Stylized Dungeons, BoZo Characters, Fantasy Monsters Bundle, Stylized Fantasy Creatures #2, Anime Powers Pack, Magic Arsenal, Spells Pack, 100 Special Skills FX, Character Controller Pro, Traversal Pro, Realistic Blood VFX, Heat UI, Cutscene Engine, Skill Tree Builder — all in your Inventix inventory.
4. `cd server/copilot-proxy && npm install && npm run dev`.
5. Open `Scenes/Bootstrap.unity` → Play.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| Mission 1 scene authored | ⏳ |
| Missions 2–6 outlined | ✅ (data-driven) |

> Maintained by Abdulmalek-Agents (Inventix Games).
