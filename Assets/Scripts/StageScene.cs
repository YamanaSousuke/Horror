using UnityEngine;

namespace Horror
{
    // �X�e�[�W�̐i�s���Ǘ�����
    public class StageScene : MonoBehaviour
    {
        public static StageScene Instance = null;

        // �v���C���[
        [SerializeField] private GameObject player = null;
        // �\������ꏊ
        [SerializeField] private GameObject[] places = { null };


        private void Awake()
        {
            Instance = this;
        }

        // ���̏ꏊ�̕\��
        public void ShowNextPlace()
        {
            places[0].SetActive(false);
            player.transform.position = new Vector3(-3.48f, 0.0f, 0.0f);
            places[1].SetActive(true);
        }
    }
}
