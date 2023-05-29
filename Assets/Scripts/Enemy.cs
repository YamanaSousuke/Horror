using Horror;
using UnityEngine;

namespace Horr
{
    // �v���C���[��ǐՂ���G
    public class Enemy : MonoBehaviour, ICharacterMovement
    {
        // �v���C���[
        [SerializeField] private Transform player = null;
        // �ړ��X�s�[�h
        [SerializeField] private float speed = 0.0f;

        // ���������ɂ鐧��
        private new Rigidbody rigidbody = null;

        private Vector3 direction = new Vector3();

        // �v���C���[�Ɠ����ꏊ�ɂ��邩�ǂ���
        private bool isPlayerInSamePlace = true;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // �v���C���[�Ɠ����ꏊ�ɂ���΃v���C���[��ǐՂ���
            if (isPlayerInSamePlace)
            {
                direction = (player.transform.position - rigidbody.position).normalized;
            }

            var rotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 0.1f);
            rigidbody.velocity = speed * direction;
        }

        // �ꏊ���؂�ւ�����Ƃ��ɍ��W�Ɖ�]��ݒ肷��
        public void SetTransform(Vector3 position, Vector3 direction)
        {
            transform.position = new Vector3(position.x, 0.0f, position.z);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // �v���C���[�Əꏊ���قȂ����Ƃ�
        public void DifferentLocation(Vector3 destination)
        {
            isPlayerInSamePlace = false;
            direction = (destination - transform.position).normalized;
        }

        // �v���C���[�Əꏊ�������ɂȂ����Ƃ�
        public void SameLocation()
        {
            isPlayerInSamePlace = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // �Q�[���I�[�o�[UI�̕\��
                StageScene.Instance.ShowGameOverUI();
            }
        }
    }
}