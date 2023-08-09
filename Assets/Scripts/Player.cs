using UnityEngine;

namespace KitchenChaos {
    public class Player : MonoBehaviour {
        [SerializeField] private GameInput gameInput;

        [SerializeField] private float moveSpeed = 5f;
        private bool isWalking;

        public bool IsWalking {
            get => isWalking;
        }



        private void Update() {
            Vector2 inputVector = gameInput.GetMovementInputVector();

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            transform.position += moveDir * (moveSpeed * Time.deltaTime);

            isWalking = moveDir != Vector3.zero;

            float rotateSpeed = 5f;
            transform.forward = Vector3.Slerp(moveDir, transform.forward, rotateSpeed * Time.deltaTime);
        }
    }
}