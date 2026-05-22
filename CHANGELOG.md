# Changelog — Ashen Veil

## [v0.2-mission1-no-runtime-ai] — Removed runtime LLM dependencies

### Changed
- **Critic & Review Board re-review (Cycle 4):** AI is now a development-workflow tool
  (Claude Code / Claude Agents), not a runtime gameplay feature. The shipping game no
  longer calls any LLM at runtime.
- Echo Companion is now a `BonfireEcho` component reading from `LineBank_Echo_*.asset`
  ScriptableObjects — 25 hand-authored whispers per bank, no LLM.
- `GameBootstrap.cs` registers `IScriptedDialogueService` instead of `IAICopilotService`.
- `docs/05_AI_COPILOT_INTEGRATION.md` replaced with `docs/05_AI_ASSISTED_DEVELOPMENT.md`.
- README updated to remove runtime-AI claims.

### Removed
- `Assets/_Project/Scripts/AI/` (ClaudeCopilotService, AICopilotPersonaSO)
- `server/copilot-proxy/` (Node proxy)

---

## [v0.1-mission1-skeleton] — Initial scaffolding

### Added
- Concept locked through 3 Critic Review Board cycles
- GDD v1.0, Asset Plan, Tech Architecture, AI integration doc, Unity setup guide
- Core shared C# library (Mission, Save, Audio, Checkpoint)
- Ashen Veil scripts (Combat, Player, Boss, Enemy, Skills, Bonfire)
- Claude AI integration plan + Node proxy *(both removed in v0.2)*
