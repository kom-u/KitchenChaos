using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {


    public class ClearCounter : MonoBehaviour {
        [SerializeField] private Transform topPoint;
        [SerializeField] private KitchenObjectSO kitchenObjectSO;
        private KitchenObject kitchenObject;



        public KitchenObject KitchenObject {
            get => kitchenObject;
            set => kitchenObject = value;
        }



        public void Interact() {
            if (kitchenObject != null) return;

            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topPoint.position, Quaternion.identity);
            kitchenObjectTransform.GetComponent<KitchenObject>().ClearCounter = this;
        }



        public Transform GetTopPoint() {
            return topPoint;
        }



        public void ClearKitchenObject() {
            kitchenObject = null;
        }



        public bool IsHasKitchenObject() {
            return kitchenObject != null;
        }
    }
}
