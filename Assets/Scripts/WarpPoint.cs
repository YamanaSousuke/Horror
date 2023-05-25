using UnityEngine;

namespace Horror
{
    // 接触したらプレイヤーを次の場所に移動させるポイント
    public class WarpPoint : MonoBehaviour
    {
        // 次の場所で生成するポイント
        [SerializeField] private GeneratePoint generatePoint = null;

        // 現在の場所
        private GameObject currentPlace = null;

        private void Start()
        {
            currentPlace = transform.parent.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            // プレイヤーと接触したとき
            if (other.TryGetComponent(out Player player))
            {
                // 現在の場所を非表示にして、次の場所を表示する
                StageScene.Instance.ShowNextPlace(currentPlace, generatePoint.ShowPlace());
                player.SetPosition(generatePoint.InitPosition(), generatePoint.InitDirection());
            }
        }
    }
}
