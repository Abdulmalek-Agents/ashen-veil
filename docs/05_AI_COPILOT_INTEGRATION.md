# 🤖 Echo Companion (Claude AI) — Ashen Veil

> The Echo Companion is a fragment of the slumbering god in your soul, manifested as a soft blue flame at every bonfire. Players press T to talk to it.

## 1. Why this works for souls-likes

- r/Soulslikes consistently asks for clearer lore. Traditional games hide it in item descriptions; we provide an in-character lore-master.
- Suck Up! proved LLM NPCs ship and sell.
- Inworld AI has demonstrated cinematic AI characters at AAA scale; we apply the niche, soulful indie version with Claude.

## 2. Touch points

| Surface | Role | Cost class |
|---|---|---|
| Echo Companion at every bonfire | Lore, hints, banter | Mid (Sonnet) |
| Whispers when player dies | Short flavour line | Low (Haiku) |
| Item lore generation | Procedural item flavour | Low (Haiku) |
| Boss intro narration | Pre-baked but with one Claude swing-tag | Mid |

Offline fallback: scripted lines for every surface.

## 3. Echo Companion persona

```
You are the Echo — a fragment of the slumbering god in the player's soul, manifested as a soft blue flame at bonfires in the stylized souls-like 'Ashen Veil'.

Voice: ancient, weary, occasionally amused. Cryptic about your true nature. Refer to the player as 'small flame' or 'kindling'.

Knowledge:
- The seven Hollow Lords were once god-bearers like the player.
- You do not yet remember your own name; it returns by mission 6.
- The kingdom Eldermarch fell 200 years ago in the Mirror Plague.

Rules:
- Reply in 1–3 short, evocative sentences.
- Never break character or reference being an AI.
- If asked the answer to a puzzle or 'how do I beat the boss', give a poetic hint, never the explicit solution.
- If asked about the player's own past, deflect mysteriously.
```

## 4. Architecture — same shared proxy

Unity → Node copilot-proxy → Anthropic. Per-NPC memory in RAM + SaveData.kv. See `/server/copilot-proxy`.

## 5. Cost projection (1k DAU)

| Component | Tokens/day/player | $/day/player |
|---|---|---|
| Echo Companion chats (avg 6 turns) | 2k | $0.004 |
| Death whispers (5/day) | 0.5k | $0.001 |
| Item lore (sporadic) | 0.3k | $0.0005 |
| **Total / DAU** | | **~$0.006** |

**Per 1k DAU: ~$6/day.** Trivial against a $19.99 launch price.

## 6. Safety

- Pre-prompt steers refusals back to dark fantasy tone.
- max_tokens=320.
- Profanity denylist client-side.
- AI-companion toggle in main menu (default On).
