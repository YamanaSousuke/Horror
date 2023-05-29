using Horror;
using UnityEngine;

namespace Horr
{
    // �v���C���[��ǐՂ���G
    public class Enemy : MonoBehaviour
    {
        // �v���C���[
        [SerializeField] private Transform player = null;
        // �ړ��X�s�[�h
        [SerializeField] private float speed = 0.0f;

        // ���������ɂ鐧��
        private Rigidbody rigidbody = null;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // �v���C���[�������ĒǐՂ���
            var direction = (player.transform.position - rigidbody.position).normalized;
            var rotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 0.1f);
            rigidbody.velocity = speed * direction;
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