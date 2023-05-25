using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror
{
    // プレイヤーの制御
    public class Player : MonoBehaviour
    {
        // 歩くときの移動スピード
        [SerializeField] private float walkSpeed = 0.0f;
        // 走るときの移動スピード
        [SerializeField] private float dashSpeed = 0.0f;
        // 回転するときの補間率
        [SerializeField, Range(0.01f, 0.1f)] private float rotateInterpolation = 0.0f;

        // 物理特性にる制御
        private new Rigidbody rigidbody = null;
        // アニメーションの制御
        private Animator animator = null;
        // 移動
        private Vector3 move = new();
        // ダッシュしているかどうか
        private bool isDash = false;
        // 現在の移動スピード
        private float currentSpeed = 0.0f;

        // アニメーションID
        private static readonly int speedId = Animator.StringToHash("Speed");

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            currentSpeed = walkSpeed;
        }

        private void FixedUpdate()
        {
            // 移動
            rigidbody.velocity = move.normalized * currentSpeed;

            // 移動中
            if (move != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(move);
                rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, rotateInterpolation);
            }
            // 停止中
            else
            {
                currentSpeed = 0.0f;
            }
            
            // ブレンドツリーでのアニメーション
            animator.SetFloat(speedId, rigidbody.velocity.magnitude / dashSpeed);
        }

        // 移動の入力を受け取る
        public void OnMove(InputAction.CallbackContext context)
        {
            move.x = context.ReadValue<Vector2>().x;
            move.z = context.ReadValue<Vector2>().y;
            currentSpeed = isDash ? dashSpeed : walkSpeed;
        }

        // ダッシュの入力を受け取る
        public void OnDash(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                // 押したとき
                case InputActionPhase.Started:
                isDash = true;
                currentSpeed = dashSpeed;
                break;

                // 離したとき
                case InputActionPhase.Canceled:
                isDash = false;
                currentSpeed = walkSpeed;
                break;
            }
        }
    }
}
