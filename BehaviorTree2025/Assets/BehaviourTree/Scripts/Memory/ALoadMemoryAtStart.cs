using UnityEngine;

namespace BTree
{
    [RequireComponent(typeof(AThinker))]
    public abstract class ALoadMemoryAtStart<T> : MonoBehaviour
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private T _value;

        private AThinker _thinker;

        private void Start()
        {
            _thinker = GetComponent<AThinker>();
            _thinker.Memory.AddOrEditData(_key, _value);
        }
    }
}
