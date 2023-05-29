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
    }
}
