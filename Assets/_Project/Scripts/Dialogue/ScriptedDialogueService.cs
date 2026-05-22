using System;
using UnityEngine;

namespace InventixGames.Core.Dialogue
{
    public interface IScriptedDialogueService
    {
        event Action<DialogueNodeSO> NodeOpened;
        event Action ConversationClosed;
        void OpenNode(DialogueNodeSO node);
        void Close();
        string PickFromBank(LineBankSO bank, out AudioClip clip);
    }

    public class ScriptedDialogueService : MonoBehaviour, IScriptedDialogueService
    {
        public event Action<DialogueNodeSO> NodeOpened;
        public event Action ConversationClosed;
        public void OpenNode(DialogueNodeSO node) { if (node == null) { Close(); return; } NodeOpened?.Invoke(node); }
        public void Close() => ConversationClosed?.Invoke();
        public string PickFromBank(LineBankSO bank, out AudioClip clip) { clip = null; return bank == null ? string.Empty : bank.PickRandom(out clip); }
    }
}
