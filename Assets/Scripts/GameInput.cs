using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KitchenChaos {
    public class GameInput : MonoBehaviour {

        private PlayerInputAction playerInputAction;

        public event EventHandler OnInteractAction;


        private void Awake() {
            playerInputAction = new PlayerInputAction();
            playerInputAction.Player.Enable();

            playerInputAction.Player.Interact.performed += Interact_performed;
        }

        private void Interact_performed(InputAction.CallbackContext context) {
            OnInteractAction?.Invoke(this, EventArgs.Empty);
        }

        public Vector2 GetMovementInputVector() {
            Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

            return inputVector;
        }
    }
}
