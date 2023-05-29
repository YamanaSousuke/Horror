using Horr;
using UnityEngine;

namespace Horror
{
    // �ڐG������v���C���[�����̏ꏊ�Ɉړ�������|�C���g
    public class WarpPoint : MonoBehaviour
    {
        // ���̏ꏊ�Ő�������|�C���g
        [SerializeField] private GeneratePoint generatePoint = null;
        // ���̏ꏊ
        [SerializeField] private LocationController nextLocation = null;

        // ���̏ꏊ
        private LocationController thisLocation = null;

        private void Start()
        {
            thisLocation = transform.parent.GetComponent<LocationController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // �v���C���[�ƐڐG�����Ƃ�
            if (other.TryGetComponent(out Player player))
            {
                thisLocation.HideLocation();
                nextLocation.ShowLocation();
                player.SetTransform(generatePoint.transform.position, generatePoint.InitDirection());
                StageScene.Instance.OnDifferentLocation(transform.position);
            }

            // �G�ƐڐG�����Ƃ�
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.SetTransform(generatePoint.transform.position, generatePoint.InitDirection());
                StageScene.Instance.OnSameLocation();
            }
        }
    }
}
