using System;
using UnityEngine;

namespace KitchenChaos {
    public class Player : Singleton<Player>, IKitchenObjectParent {
        public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
        public class OnSelectedCounterChangedEventArgs : EventArgs {
            public ClearCounter selectedCounter;
        }

        [Header("General")]
        [SerializeField] private GameInput gameInput;
        [SerializeField] private LayerMask interactLayerMask;

        [Header("Property")]
        [SerializeField] private float moveSpeed = 5f;
        private bool isWalking;
        public bool IsWalking {
            get => isWalking;
        }

        private Vector3 lastInteractDirection;
        private ClearCounter selectedCounter;

        [Header("Object Hold")]
        [SerializeField] private Transform kitchenObjectHoldPoint;
        private KitchenObject kitchenObject;


        private void Start() {
            gameInput.OnInteractAction += GameInput_OnInteractAction;
        }



        private void GameInput_OnInteractAction(object sender, EventArgs e) {

            if (selectedCounter == null) return;

            selectedCounter.Interact(this);
        }

        private void Update() {
            HandleMovement();
            HandleInteraction();
        }



        // FIXME: refactor later
        private void HandleMovement() {
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



        private void HandleInteraction() {
            Vector2 inputVector = gameInput.GetMovementInputVector();

            Vector3 moveDirection = new(inputVector.x, 0f, inputVector.y);

            if (moveDirection != Vector3.zero)
                lastInteractDirection = moveDirection;

            float interactDistance = 2f;
            bool isCanInteract = Physics.Raycast(
                transform.position,
                lastInteractDirection,
                out RaycastHit hitInfo,
                interactDistance,
                interactLayerMask
            );

            if (isCanInteract) {
                if (hitInfo.transform.TryGetComponent(out ClearCounter clearCounter)) {
                    if (clearCounter != selectedCounter)
                        SetSelectedCounter(clearCounter);
                } else {
                    SetSelectedCounter(null);
                }
            } else {
                SetSelectedCounter(null);
            }
        }



        private void SetSelectedCounter(ClearCounter selectedCounter) {
            this.selectedCounter = selectedCounter;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs {
                selectedCounter = this.selectedCounter
            });
        }

        public KitchenObject GetKitchenObject() {
            return kitchenObject;
        }

        public void SetKitchenObject(KitchenObject kitchenObject) {
            this.kitchenObject = kitchenObject;
        }

        public Transform GetKitchenObjectFollowTransform() {
            return kitchenObjectHoldPoint;
        }

        public void ClearKitchenObject() {
            kitchenObject = null;
        }

        public bool IsHasKitchenObject() {
            return kitchenObject != null;
        }
    }
}