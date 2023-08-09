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

            Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
            float moveDistance = moveSpeed * Time.deltaTime;

            float playerRadius = 0.7f;
            float playerHeight = 2f;
            bool isCanMove = !Physics.CapsuleCast(
                transform.position, // lower point
                transform.position + Vector3.up * playerHeight, // upper point
                playerRadius, // radius
                moveDirection, // direction
                moveDistance // distance
            );


            if (!isCanMove) {
                moveDirection = new Vector3(inputVector.x, 0f, 0f);
                isCanMove = !Physics.CapsuleCast(
                    transform.position, // lower point
                    transform.position + Vector3.up * playerHeight, // upper point
                    playerRadius, // radius
                    moveDirection, // direction
                    moveDistance // distance
                );

                if (!isCanMove) {
                    moveDirection = new Vector3(0f, 0f, inputVector.y);
                    isCanMove = !Physics.CapsuleCast(
                        transform.position, // lower point
                        transform.position + Vector3.up * playerHeight, // upper point
                        playerRadius, // radius
                        moveDirection, // direction
                        moveDistance // distance
                    );
                }
            }


            if (isCanMove)
                transform.position += moveDirection * moveDistance;

            isWalking = moveDirection != Vector3.zero;

            float rotateSpeed = 5f;
            transform.forward = Vector3.Slerp(moveDirection, transform.forward, rotateSpeed * Time.deltaTime);
        }
    }
}