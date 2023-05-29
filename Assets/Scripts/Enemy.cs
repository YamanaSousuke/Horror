using Horror;
using UnityEngine;

namespace Horr
{
    // プレイヤーを追跡する敵
    public class Enemy : MonoBehaviour, ICharacterMovement
    {
        // プレイヤー
        [SerializeField] private Transform player = null;
        // 移動スピード
        [SerializeField] private float speed = 0.0f;

        // 物理特性にる制御
        private new Rigidbody rigidbody = null;

        private Vector3 direction = new Vector3();

        // プレイヤーと同じ場所にいるかどうか
        private bool isPlayerInSamePlace = true;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // プレイヤーと同じ場所にいればプレイヤーを追跡する
            if (isPlayerInSamePlace)
            {
                direction = (player.transform.position - rigidbody.position).normalized;
            }

            var rotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 0.1f);
            rigidbody.velocity = speed * direction;
        }

        // 場所が切り替わったときに座標と回転を設定する
        public void SetTransform(Vector3 position, Vector3 direction)
        {
            transform.position = new Vector3(position.x, 0.0f, position.z);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // プレイヤーと場所が異なったとき
        public void DifferentLocation(Vector3 destination)
        {
            isPlayerInSamePlace = false;
            direction = (destination - transform.position).normalized;
        }

        // プレイヤーと場所が同じになったとき
        public void SameLocation()
        {
            isPlayerInSamePlace = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // ゲームオーバーUIの表示
                StageScene.Instance.ShowGameOverUI();
            }
        }
    }
}