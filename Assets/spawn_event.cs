using Oculus.Interaction.HandGrab;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawn_event : MonoBehaviour
{
    private float collisionStartTime = 0f; // 衝突が始まった時刻
    private bool isColliding = false; // 衝突中かどうかのフラグ

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("top"))
        {
            Debug.Log("ObjectA collided with ObjectB!");

            HandGrabInteractable grabScript = this.gameObject.GetComponent<HandGrabInteractable>();
            if (grabScript != null)
            {
                grabScript.enabled = false;
            }

            BoxCollider boxCollider = collision.gameObject.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                StartCoroutine(TurnOffTriggerAfterDelay(boxCollider, 0.25f));
            }

            // 衝突中であることを記録し、現在の時刻を保存する
            if (!isColliding)
            {
                collisionStartTime = Time.time;
            }
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("top"))
        {
            // 衝突が終了したらフラグをリセット
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding && Time.time - collisionStartTime >= 2f)
        {
            // 衝突が2秒以上継続している場合、特定の処理を実行する
            // ここではタグが "Sphere" のオブジェクトの Rigidbody の重力を反転させる
            Rigidbody sphereRigidbody = GameObject.FindGameObjectWithTag("Sphere").GetComponent<Rigidbody>();
            if (sphereRigidbody != null)
            {
                sphereRigidbody.useGravity = !sphereRigidbody.useGravity;
            }
            BoxCollider boxCollider = GameObject.FindGameObjectWithTag("top").GetComponent<BoxCollider>();
            if(boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
        }
    }

    private IEnumerator TurnOffTriggerAfterDelay(BoxCollider boxCollider, float delay)
    {
        boxCollider.isTrigger = true;
        yield return new WaitForSeconds(delay);
        boxCollider.isTrigger = false;
    }
}

