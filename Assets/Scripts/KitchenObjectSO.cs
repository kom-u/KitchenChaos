using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {
    [CreateAssetMenu(fileName = "New Kitchen Object", menuName = "SO/Kitchen Object")]
    public class KitchenObjectSO : ScriptableObject {
        public Transform prefab;
        public Sprite sprite;
        public new string name;
    }
}
