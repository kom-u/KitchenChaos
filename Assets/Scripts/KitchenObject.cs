using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;



        public KitchenObjectSO KitchenObjectSO
        {
            get => kitchenObjectSO;
        }
    }
}
