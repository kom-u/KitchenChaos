using UnityEngine;

namespace KitchenChaos {
    public class Player : MonoBehaviour {
        [SerializeField] private float moveSpeed = 5f;
        private bool isWalking;

        public bool IsWalking {
            get => isWalking;
        }



        private void Update() {
            var inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W)) inputVector.y += 1;
            if (Input.GetKey(KeyCode.A)) inputVector.x -= 1;
            if (Input.GetKey(KeyCode.S)) inputVector.y -= 1;
            if (Input.GetKey(KeyCode.D)) inputVector.x += 1;

            inputVector = inputVector.normalized;

            var moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            var playerTransform = transform;
            playerTransform.position += moveDir * (moveSpeed * Time.deltaTime);

            isWalking = moveDir != Vector3.zero;

            var rotateSpeed = 5f;
            playerTransform.forward = Vector3.Slerp(moveDir, playerTransform.forward, rotateSpeed * Time.deltaTime);
        }
    }
}