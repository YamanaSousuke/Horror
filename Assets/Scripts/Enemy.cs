using Horror;
using UnityEngine;

namespace Horr
{
    // プレイヤーを追跡する敵
    public class Enemy : MonoBehaviour
    {
        // プレイヤー
        [SerializeField] private Transform player = null;
        // 移動スピード
        [SerializeField] private float speed = 0.0f;

        // 物理特性にる制御
        private Rigidbody rigidbody = null;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // プレイヤーを向いて追跡する
            var direction = (player.transform.position - rigidbody.position).normalized;
            var rotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 0.1f);
            rigidbody.velocity = speed * direction;
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