using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // リスポーンさせるGameObjectのリスト
    public Vector3 initialPosition; // 初期位置

    void Start()
    {
        // objectsToRespawn配列からPrefabを取得して初期位置に生成
        if (objectsToRespawn.Length > 0)
        {
            GameObject spawnedObject = Instantiate(objectsToRespawn[0], initialPosition, Quaternion.identity);
        }
        //initialPosition = transform.position; // 初期位置を保存
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // 衝突したオブジェクトの "Hand Grab Interactable" スクリプトを取得
            //HandGrabInteractable handGrabInteractable = collision.gameObject.GetComponent<>();

            // もし取得できた場合は null に設定
            //if (handGrabInteractable != null)
            //{
            //    handGrabInteractable = null;
            //}

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
