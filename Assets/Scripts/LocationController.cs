using UnityEngine;

namespace Horror
{
    // 各場所ごとで進行の制御を行う
    public class LocationController : MonoBehaviour
    {
        // この場所を映すカメラ
        [SerializeField] private GameObject camera = null;

        // この場所にプレイヤーがいるかどうか
        private bool isPlayerInPlace = false;

        // この場所に敵がいるかどうか
        private bool isEnemyInPlace = false;

        // 場所の表示
        public void ShowLocation()
        {
            camera.SetActive(true);
            isPlayerInPlace = true;
        }
        
        // 場所の非表示
        public void HideLocation()
        {
            camera.SetActive(false);
        }

        // 敵がこの場所に来たととき
        public void SetEnemyInPlace()
        {
            if (isPlayerInPlace)
            {

            }
        }
    }
}


