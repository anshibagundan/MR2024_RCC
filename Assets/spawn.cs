using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // リスポーンさせるGameObjectのリスト
    public Vector3 initialPosition; // 初期位置

    void Start()
    {
        initialPosition = transform.position; // 初期位置を保存
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("top")) // 平面との接触をチェック
        {
            RespawnRandom(); // ランダムなオブジェクトをリスポーン
        }
    }

    void RespawnRandom()
    {
        if (objectsToRespawn.Length > 0)
        {
            int randomIndex = Random.Range(0, objectsToRespawn.Length); // ランダムなインデックスを選択
            GameObject objectToRespawnPrefab = objectsToRespawn[randomIndex]; // ランダムに選択したPrefab

            // 初期位置にPrefabを生成してリスポーン
            GameObject spawnedObject = Instantiate(objectToRespawnPrefab, initialPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No objects to respawn."); // リスポーンするオブジェクトがない場合は警告を表示
        }
    }
}
