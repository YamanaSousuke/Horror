using UnityEngine;

namespace Horror
{
    // �X�e�[�W�̐i�s���Ǘ�����
    public class StageScene : MonoBehaviour
    {
        public static StageScene Instance = null;

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
    }
}
