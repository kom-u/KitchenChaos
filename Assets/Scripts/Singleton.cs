using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        public static T Instance { get; private set; }

        #region MonoBehaviour methods
        protected virtual void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }
        #endregion



        #region Private methods

        #endregion
    }
}
