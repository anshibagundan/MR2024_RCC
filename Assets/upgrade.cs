using Oculus.Interaction.HandGrab;
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
        if (this.gameObject.name == collision.gameObject.name)
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Upgrade>().upgradedObject = null;
            if (upgradedObject)
            {
                GameObject up = Instantiate(upgradedObject, this.transform.position, this.transform.rotation);
                HandGrabInteractable handGrabInteractableComponent = up.GetComponent<HandGrabInteractable>();
                if (handGrabInteractableComponent != null)
                {
                    handGrabInteractableComponent.enabled = false; // HandGrabInteractable コンポーネントを無効化する
                }
            }
        }
    }
}
