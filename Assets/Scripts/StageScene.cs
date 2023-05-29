using Horr;
using UnityEngine;

namespace Horror
{
    // ステージの進行を管理する
    public class StageScene : MonoBehaviour
    {
        // このクラスのインスタンス
        public static StageScene Instance = null;

        // ゲームオーバーUI
        [SerializeField] private GameObject gameOverUI = null;
        // 敵
        [SerializeField] private Enemy enemy = null;

        // プレイヤーが移動した回数
        private int playerCount = 0;
        // 敵が移動した回数
        private int enemyCount = 0;

        private void Awake()
        {
            Instance = this;
        }

        // 次の場所を表示する
        public void ShowNextPlace(GameObject current, GameObject next)
        {
            current.SetActive(false);
            next.SetActive(true);
        }

        // ゲームオーバーUIの表示
        public void ShowGameOverUI()
        {
            gameOverUI.SetActive(true);
        }

        // プレイヤーと敵が違う場所になったとき
        public void OnDifferentLocation(Vector3 destination)
        {
            enemy.DifferentLocation(destination);
        }

        // プレイヤーと敵が同じ場所になったとき
        public void OnSameLocation()
        {
            enemy.SameLocation();
        }
    }
}
