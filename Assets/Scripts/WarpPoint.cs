using UnityEngine;

namespace Horror
{
    // �ڐG������v���C���[�����̏ꏊ�Ɉړ�������|�C���g
    public class WarpPoint : MonoBehaviour
    {
        // ���̏ꏊ�Ő�������|�C���g
        [SerializeField] private GeneratePoint generatePoint = null;

        // ���݂̏ꏊ
        private GameObject currentPlace = null;

        private void Start()
        {
            currentPlace = transform.parent.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            // �v���C���[�ƐڐG�����Ƃ�
            if (other.TryGetComponent(out Player player))
            {
                // ���݂̏ꏊ���\���ɂ��āA���̏ꏊ��\������
                StageScene.Instance.ShowNextPlace(currentPlace, generatePoint.ShowPlace());
                player.SetPosition(generatePoint.InitPosition(), generatePoint.InitDirection());
            }
        }
    }
}
