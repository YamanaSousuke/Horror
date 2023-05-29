using Horr;
using UnityEngine;

namespace Horror
{
    // �X�e�[�W�̐i�s���Ǘ�����
    public class StageScene : MonoBehaviour
    {
        // ���̃N���X�̃C���X�^���X
        public static StageScene Instance = null;

        // �Q�[���I�[�o�[UI
        [SerializeField] private GameObject gameOverUI = null;
        // �G
        [SerializeField] private Enemy enemy = null;

        // �v���C���[���ړ�������
        private int playerCount = 0;
        // �G���ړ�������
        private int enemyCount = 0;

        private void Awake()
        {
            Instance = this;
        }

        // ���̏ꏊ��\������
        public void ShowNextPlace(GameObject current, GameObject next)
        {
            current.SetActive(false);
            next.SetActive(true);
        }

        // �Q�[���I�[�o�[UI�̕\��
        public void ShowGameOverUI()
        {
            gameOverUI.SetActive(true);
        }

        // �v���C���[�ƓG���Ⴄ�ꏊ�ɂȂ����Ƃ�
        public void OnDifferentLocation(Vector3 destination)
        {
            enemy.DifferentLocation(destination);
        }

        // �v���C���[�ƓG�������ꏊ�ɂȂ����Ƃ�
        public void OnSameLocation()
        {
            enemy.SameLocation();
        }
    }
}
