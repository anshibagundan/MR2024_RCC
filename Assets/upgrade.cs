using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // アップグレード後のオブジェクト
    public GameObject upgradedObject;

    // OnCollisionEnterは、オブジェクトが他のオブジェクトと衝突したときに呼び出されます
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが自分自身と同じ名前の場合
        if (this.gameObject.name == collision.gameObject.name)
        {
            // 自分自身のゲームオブジェクトを破棄する
            Destroy(this.gameObject);

            // 衝突したオブジェクトがUpgradeコンポーネントを持っていた場合
            Upgrade upgradeComponent = collision.gameObject.GetComponent<Upgrade>();
            if (upgradeComponent != null)
            {
                // アップグレード後のオブジェクトが設定されている場合
                if (upgradedObject != null)
                {
                    // アップグレード後のオブジェクトを生成し、同じ位置と回転で配置する
                    Instantiate(upgradedObject, this.transform.position, this.transform.rotation);
                }
            }
        }
    }
}
