using UnityEngine;
using System.Collections.Generic;
namespace InventixGames.Core
{
    public interface ICheckpointService { void Register(Vector3 p, string id); bool TryGetLatest(out Vector3 p, out string id); void Clear(); }
    public class CheckpointService : MonoBehaviour, ICheckpointService
    {
        private readonly List<(Vector3 p, string id)> _c = new();
        public void Register(Vector3 p, string id) { _c.Add((p, id)); if (ServiceLocator.TryGet<ISaveService>(out var s)) { s.Data.kv[$"chk_{id}_x"] = p.x.ToString(); s.Data.kv[$"chk_{id}_y"] = p.y.ToString(); s.Data.kv[$"chk_{id}_z"] = p.z.ToString(); s.Save(); } }
        public bool TryGetLatest(out Vector3 p, out string id) { if (_c.Count == 0) { p = Vector3.zero; id = null; return false; } var l = _c[_c.Count - 1]; p = l.p; id = l.id; return true; }
        public void Clear() => _c.Clear();
    }
}
