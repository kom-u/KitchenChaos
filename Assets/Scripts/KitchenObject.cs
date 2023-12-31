using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {
    public class KitchenObject : MonoBehaviour {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;
        private IKitchenObjectParent kitchenObjectParent;



        public KitchenObjectSO GetKitchenObjectSO() {
            return kitchenObjectSO;
        }



        public IKitchenObjectParent GetKitchenObjectParent() {
            return kitchenObjectParent;
        }


        public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
            if (this.kitchenObjectParent != null)
                this.kitchenObjectParent.ClearKitchenObject();

            this.kitchenObjectParent = kitchenObjectParent;

            if (this.kitchenObjectParent.IsHasKitchenObject())
                Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
            this.kitchenObjectParent.SetKitchenObject(this);

            transform.parent = this.kitchenObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        }


    }
}
