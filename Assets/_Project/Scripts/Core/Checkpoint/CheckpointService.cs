using UnityEngine;
using System.Collections.Generic;
namespace InventixGames.Core
{
    public interface ICheckpointService { void Register(Vector3 pos, string id); bool TryGetLatest(out Vector3 pos, out string id); void Clear(); }
    public class CheckpointService : MonoBehaviour, ICheckpointService
    {
        private readonly List<(Vector3 pos, string id)> _c = new();
        public void Register(Vector3 pos, string id) { _c.Add((pos, id)); if (ServiceLocator.TryGet<ISaveService>(out var s)) { s.Data.kv[$"chk_{id}_x"] = pos.x.ToString(); s.Data.kv[$"chk_{id}_y"] = pos.y.ToString(); s.Data.kv[$"chk_{id}_z"] = pos.z.ToString(); s.Save(); } }
        public bool TryGetLatest(out Vector3 pos, out string id) { if (_c.Count == 0) { pos = Vector3.zero; id = null; return false; } var l = _c[_c.Count - 1]; pos = l.pos; id = l.id; return true; }
        public void Clear() => _c.Clear();
    }
}
