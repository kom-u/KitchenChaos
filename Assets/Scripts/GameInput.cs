using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenChaos {
    public class GameInput : MonoBehaviour {

        PlayerInputAction playerInputAction;


        private void Awake() {
            playerInputAction = new PlayerInputAction();
            playerInputAction.Player.Enable();
        }



        public Vector2 GetMovementInputVector() {
            Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

            return inputVector;
        }
    }
}
