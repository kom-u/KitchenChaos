using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos
{
    public class CounterVisualSelected : MonoBehaviour
    {
        [SerializeField] private ClearCounter clearCounter;
        [SerializeField] private GameObject selectedVisual;



        private void Start()
        {
            Player.Instance.OnSelectedCounterChanged += Player_Instance_OnSelectedCounterChanged;
        }



        private void Player_Instance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
        {
            if(e.selectedCounter == clearCounter) {
                ShowSelectedVisual();
            } else {
                HideSelectedVisual();
            }

        }



        private void ShowSelectedVisual()
        {
            selectedVisual.SetActive(true);
        }



        private void HideSelectedVisual()
        {
            selectedVisual.SetActive(false);
        }
    }
}
