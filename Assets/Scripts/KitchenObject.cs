using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {
    public class KitchenObject : MonoBehaviour {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;
        private ClearCounter clearCounter;



        public KitchenObjectSO KitchenObjectSO {
            get => kitchenObjectSO;
        }



        public ClearCounter ClearCounter {
            get => clearCounter;
            set
            {
                if (clearCounter != null)
                    clearCounter.ClearKitchenObject();

                clearCounter = value;

                if (clearCounter.IsHasKitchenObject())
                    Debug.LogError("Counter already has a KitchenObject!");
                clearCounter.KitchenObject = this;

                transform.parent = clearCounter.GetTopPoint();
                transform.localPosition = Vector3.zero;
            }
        }


    }
}
