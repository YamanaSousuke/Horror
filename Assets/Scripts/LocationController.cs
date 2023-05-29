using UnityEngine;

namespace Horror
{
    // �e�ꏊ���ƂŐi�s�̐�����s��
    public class LocationController : MonoBehaviour
    {
        // ���̏ꏊ���f���J����
        [SerializeField] private GameObject camera = null;

        // ���̏ꏊ�Ƀv���C���[�����邩�ǂ���
        private bool isPlayerInPlace = false;

        // ���̏ꏊ�ɓG�����邩�ǂ���
        private bool isEnemyInPlace = false;

        // �ꏊ�̕\��
        public void ShowLocation()
        {
            camera.SetActive(true);
            isPlayerInPlace = true;
        }
        
        // �ꏊ�̔�\��
        public void HideLocation()
        {
            camera.SetActive(false);
        }

        // �G�����̏ꏊ�ɗ����ƂƂ�
        public void SetEnemyInPlace()
        {
            if (isPlayerInPlace)
            {

            }
        }
    }
}


