using UnityEngine;

namespace Horror
{
    // �ꏊ���؂�ւ�������Ƀv���C���[�����������|�C���g
    public class GeneratePoint : MonoBehaviour
    {
        // �v���C���[�̏����̌���
        private enum InitRotation
        {
            // ��
            Up,
            // �E
            Right,
            // ��
            Back,
            // ��
            Left,
        }
        [SerializeField] private InitRotation initRotation = InitRotation.Up;

        // �\��������ꏊ
        public GameObject ShowPlace()
        {
            return transform.parent.gameObject;
        }

        // �v���C���[�̏����̌���
        public Vector3 InitDirection()
        {
            switch (initRotation)
            {
                // ��
                case InitRotation.Up: return Vector3.up;

                // �E
                case InitRotation.Right: return Vector3.right;

                // ��
                case InitRotation.Back: return Vector3.back;

                // ��
                case InitRotation.Left: return Vector3.left;

                // ���̑�
                default: return Vector3.zero;
            }
        }

        // �v���C���[�̏������W
        public Vector3 InitPosition()
        {
            return transform.position;
        }
    }
}
