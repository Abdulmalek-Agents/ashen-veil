# 🤖 AI-Assisted Development — Ashen Veil

> **Important:** AI is a **development tool**, not a runtime feature.
> No part of the shipping game calls an LLM at runtime. Every Echo whisper,
> every item-lore line, every NPC barbed exchange is hand-authored into
> `DialogueNodeSO` / `LineBankSO` ScriptableObjects.
> Claude (via Claude Code and Claude Agents) is used by the studio to speed up
> design, code, asset wiring, lore writing, and QA — never by the player.

## 1. What the studio uses Claude for

| Phase | What Claude does | What humans do |
|---|---|---|
| Concept & trend research | Pulls r/Soulslikes / Black Myth / Lies of P signals | Final greenlight |
| GDD authoring | Drafts Mission 1–6 layouts, Hollow Lord movesets, anime-power combos | Pillar checks |
| Code generation | Produces ScriptableObjects, combat state machines, dodge i-frame timing, parry windows | Senior dev review + Unity wiring |
| Lore writing | Drafts 200+ item-lore snippets, Echo whisper lines per bonfire, Hollow Lord intros | Writers polish, voice direction |
| QA & playtesting scripts | Authors boss-fight checklists, edge-case bug repros | Manual play, fix bugs |

## 2. Why we removed runtime LLM features (v0.1 → v0.2)

| Concern | v0.1 (runtime Echo) | v0.2 (hand-authored LineBank) |
|---|---|---|
| Tone consistency | LLM may break dark-fantasy register | 100% authored lines |
| Internet dependency | Phones home at every bonfire | Fully offline |
| Per-DAU cost | ~$0.006/day/player | $0 |
| Steam policy | AI disclosure burden | None |
| Latency | 600–2,000 ms | Instant |
| QA repro | Hard | Deterministic |

## 3. How Claude shows up in the dev workflow

1. **Plan** — GDD drafts (see `docs/02`).
2. **Code** — Claude Code generates Unity C# directly into branch PRs.
3. **Review** — Critic & Review Board persona panel audits (see `docs/06`).
4. **Wire** — Step-by-step Unity Editor instructions (see `docs/07`).
5. **Author content** — Item lore, Echo whispers, Hollow Lord intros — all into ScriptableObjects.
6. **Test** — QA checklists per mission.
7. **Ship** — Only the compiled game ships. No LLM at runtime.

## 4. The shipping game's dialogue stack

| Type | When | Author tool |
|---|---|---|
| `LineBankSO` | Bonfire Echo whispers, death whispers, item lore pop-ups | Inspector edit + Claude drafts |
| `DialogueNodeSO` | NPC merchant dialogues (Mission 3+) | Inspector edit |
| `IScriptedDialogueService` | Runtime entry point | (code only) |

## 5. Example: authoring an Echo whisper bank

1. Writer asks Claude: *"Draft 25 short Echo whispers — ancient, weary, occasionally amused. Refer to player as 'small flame' or 'kindling'. 1–3 sentences each. No modern words."*
2. Claude returns 25 lines as a YAML list.
3. Writer creates `LineBank_Echo_Generic.asset` and pastes them in.
4. Drag the bank into the bonfire's `BonfireEcho` component. Done.

## 6. What replaced what

| v0.1 (deleted) | v0.2 (replacement) |
|---|---|
| `Persona_Echo.asset` (systemPrompt) | `LineBank_Echo_Generic.asset` (25 hand-written whispers) |
| `AICopilotPersonaSO.cs` | (deleted) |
| `ClaudeCopilotService.cs` | `ScriptedDialogueService.cs` |
| `server/copilot-proxy/` | (deleted) |

## 7. What the user must do after cloning

1. Open the Unity project per `docs/07_UNITY_SETUP_GUIDE.md`.
2. Buy & import asset packs listed in `docs/03_ASSET_PLAN.md`.
3. Drag prefabs / wire scenes per `docs/07`.
4. **No proxy server, no API key, no internet config required.**
