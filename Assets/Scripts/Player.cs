using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror
{
    // �v���C���[�̐���
    public class Player : MonoBehaviour, ICharacterMovement
    {
        // �����Ƃ��̈ړ��X�s�[�h
        [SerializeField] private float walkSpeed = 0.0f;
        // ����Ƃ��̈ړ��X�s�[�h
        [SerializeField] private float dashSpeed = 0.0f;
        // ��]����Ƃ��̕�ԗ�
        [SerializeField, Range(0.01f, 0.1f)] private float rotateInterpolation = 0.0f;

        // ���������ɂ鐧��
        private new Rigidbody rigidbody = null;
        // �A�j���[�V�����̐���
        private Animator animator = null;
        // �ړ�
        private Vector3 move = new();
        // �_�b�V�����Ă��邩�ǂ���
        private bool isDash = false;
        // ���݂̈ړ��X�s�[�h
        private float currentSpeed = 0.0f;

        // �A�j���[�V����ID
        private static readonly int speedId = Animator.StringToHash("Speed");

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            currentSpeed = walkSpeed;
        }

        private void FixedUpdate()
        {
            // �ړ�
            rigidbody.velocity = move.normalized * currentSpeed;

            // �ړ���
            if (move != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(move);
                rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, rotateInterpolation);
            }
            // ��~��
            else
            {
                currentSpeed = 0.0f;
            }
            
            // �u�����h�c���[�ł̃A�j���[�V����
            animator.SetFloat(speedId, rigidbody.velocity.magnitude / dashSpeed);
        }

        // �ꏊ���؂�ւ�����Ƃ��ɍ��W�Ɖ�]��ݒ肷��
        public void SetTransform(Vector3 position, Vector3 direction)
        {
            transform.position = new Vector3(position.x, 0.0f, position.z);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // �ړ��̓��͂��󂯎��
        public void OnMove(InputAction.CallbackContext context)
        {
            move.x = context.ReadValue<Vector2>().x;
            move.z = context.ReadValue<Vector2>().y;
            currentSpeed = isDash ? dashSpeed : walkSpeed;
        }

        // �_�b�V���̓��͂��󂯎��
        public void OnDash(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                // �������Ƃ�
                case InputActionPhase.Started:
                isDash = true;
                currentSpeed = dashSpeed;
                break;

                // �������Ƃ�
                case InputActionPhase.Canceled:
                isDash = false;
                currentSpeed = walkSpeed;
                break;
            }
        }
    }
}
