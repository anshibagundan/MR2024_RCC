using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // リスポーンさせるGameObjectのリスト
    public Vector3 spawner; // 初期位置

    void Start()
    {
        // objectsToRespawn配列からPrefabを取得して初期位置に生成
        Instantiate(objectsToRespawn[0], spawner, Quaternion.identity);
    }
    private void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {

            // 衝突時に新しいゲームオブジェクトを生成する
            Instantiate(objectsToRespawn[Random.Range(0, objectsToRespawn.Length)], spawner, Quaternion.identity);
        }
    }
}
