using UnityEngine;

namespace Horror
{
    // ステージの進行を管理する
    public class StageScene : MonoBehaviour
    {
        public static StageScene Instance = null;

        // プレイヤー
        [SerializeField] private GameObject player = null;
        // 表示する場所
        [SerializeField] private GameObject[] places = { null };


        private void Awake()
        {
            Instance = this;
        }

        // 次の場所の表示
        public void ShowNextPlace()
        {
            places[0].SetActive(false);
            player.transform.position = new Vector3(-3.48f, 0.0f, 0.0f);
            places[1].SetActive(true);
        }
    }
}
