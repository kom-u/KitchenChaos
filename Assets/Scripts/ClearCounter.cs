using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {


    public class ClearCounter : MonoBehaviour {
        [SerializeField] private Transform topPoint;
        [SerializeField] private KitchenObjectSO kitchenObjectSO;



        public void Interact() {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topPoint.position, Quaternion.identity);

            Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectSO);
        }
    }
}
