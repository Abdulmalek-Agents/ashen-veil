using UnityEngine;
using System.Collections.Generic;
namespace AshenVeil.Skills
{
    public enum SkillBranch { Steel, Spell, Spirit }
    [CreateAssetMenu(menuName = "Ashen Veil/Skills/Skill Node", fileName = "Skill_")]
    public class SkillNodeSO : ScriptableObject { public string skillId; public string displayName; [TextArea] public string description; public SkillBranch branch; public int costEmbers = 1; public List<string> prerequisiteSkillIds = new(); }
}
