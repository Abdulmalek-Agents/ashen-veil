# Data folder — ScriptableObject authoring (Ashen Veil)

```
Data/
├── Missions/         MissionDatabase + MissionData_M01..M06
├── AICopilot/        Persona_Echo (the Echo Companion)
├── Enemies/          EnemyDataSO per monster
├── Bosses/           BossDataSO per Hollow Lord
├── Skills/           SkillNode_Steel_*, Skill_Spell_*, Skill_Spirit_*
└── Weapons/          WeaponData per Magic Arsenal weapon
```

Mission 1 minimum:
1. MissionDatabase.asset with M01.
2. MissionData_M01.asset with 7 objectives (see GDD §6).
3. Persona_Echo.asset (system prompt in 05).
4. SkillNode assets for first 4 unlockable nodes.
