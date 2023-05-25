using UnityEngine;

namespace Horror
{
    // ステージの進行を管理する
    public class StageScene : MonoBehaviour
    {
        public static StageScene Instance = null;

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
    }
}
