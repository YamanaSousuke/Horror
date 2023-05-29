using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Horror
{
    // 移動するキャラクターに継承するインターフェース
    public interface ICharacterMovement
    {
        // 場所が切り替わったときに座標と回転を設定する
        public void SetTransform(Vector3 position, Vector3 direction);
    }
}

