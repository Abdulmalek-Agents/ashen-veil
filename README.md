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
| **Runtime AI features** | **None** — the shipping game is fully offline and self-contained |
| **AI in development** | Claude Code & Claude Agents are used by the studio to draft GDDs, generate C#, and write lore. See [docs/05_AI_ASSISTED_DEVELOPMENT.md](docs/05_AI_ASSISTED_DEVELOPMENT.md). |

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
├── docs/                              (7 critic-approved design docs)
└── Assets/_Project/                   (Unity-ready scripts, ScriptableObject guide, scenes/prefabs/art/audio folders)
    └── Scripts/{Core, Dialogue, Gameplay, UI}
```

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. New Unity 2022.3 LTS URP project; copy `Assets/_Project/` in.
3. Import: Fantasy Castle Environment, Stylized Dungeons, BoZo Characters, Fantasy Monsters Bundle, Stylized Fantasy Creatures #2, Anime Powers Pack, Magic Arsenal, Spells Pack, 100 Special Skills FX, Character Controller Pro, Traversal Pro, Realistic Blood VFX, Heat UI, Cutscene Engine, Skill Tree Builder — all in your Inventix inventory.
4. Open `Scenes/Bootstrap.unity` → Play.

> No proxy server, no API key, no internet config required.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| v0.2 — runtime LLM removed, scripted dialogue stack | ✅ |
| Mission 1 scene authored | ⏳ |
| Missions 2–6 outlined | ✅ (data-driven) |

> Maintained by Abdulmalek-Agents (Inventix Games).
