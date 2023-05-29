using UnityEngine;

namespace Horror
{
    // 場所が切り替わった時にプレイヤーが生成されるポイント
    public class GeneratePoint : MonoBehaviour
    {
        // プレイヤーの初期の向き
        private enum InitRotation
        {
            // 上
            Up,
            // 右
            Right,
            // 下
            Back,
            // 左
            Left,
        }
        [SerializeField] private InitRotation initRotation = InitRotation.Up;

        // プレイヤーの初期の向き
        public Vector3 InitDirection()
        {
            switch (initRotation)
            {
                // 上
                case InitRotation.Up: return Vector3.up;

                // 右
                case InitRotation.Right: return Vector3.right;

                // 下
                case InitRotation.Back: return Vector3.back;

                // 左
                case InitRotation.Left: return Vector3.left;

                // その他
                default: return Vector3.zero;
            }
        }
    }
}
