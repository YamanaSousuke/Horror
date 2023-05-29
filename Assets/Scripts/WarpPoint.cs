using Horr;
using UnityEngine;

namespace Horror
{
    // 接触したらプレイヤーを次の場所に移動させるポイント
    public class WarpPoint : MonoBehaviour
    {
        // 次の場所で生成するポイント
        [SerializeField] private GeneratePoint generatePoint = null;
        // 次の場所
        [SerializeField] private LocationController nextLocation = null;

        // この場所
        private LocationController thisLocation = null;

        private void Start()
        {
            thisLocation = transform.parent.GetComponent<LocationController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // プレイヤーと接触したとき
            if (other.TryGetComponent(out Player player))
            {
                thisLocation.HideLocation();
                nextLocation.ShowLocation();
                player.SetTransform(generatePoint.transform.position, generatePoint.InitDirection());
                StageScene.Instance.OnDifferentLocation(transform.position);
            }

            // 敵と接触したとき
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.SetTransform(generatePoint.transform.position, generatePoint.InitDirection());
                StageScene.Instance.OnSameLocation();
            }
        }
    }
}
