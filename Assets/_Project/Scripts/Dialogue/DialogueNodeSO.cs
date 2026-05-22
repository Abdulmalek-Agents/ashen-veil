using UnityEngine;

namespace InventixGames.Core.Dialogue
{
    [CreateAssetMenu(menuName = "Inventix/Dialogue/Node", fileName = "Node_")]
    public class DialogueNodeSO : ScriptableObject
    {
        public string nodeId;
        public string speakerId;
        public string speakerDisplayName = "Stranger";
        [TextArea(2, 6)] public string speakerLine;
        public AudioClip voiceOver;
        public Reply[] replies = System.Array.Empty<Reply>();
        [System.Serializable]
        public class Reply
        {
            [TextArea(1, 3)] public string playerLine;
            public DialogueNodeSO next;
            public string objectiveIdToReport;
        }
    }
}
