using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
        }
    }

    private IEnumerator TurnOffTriggerAfterDelay(BoxCollider boxCollider, float delay)
    {
        boxCollider.isTrigger = true;
        yield return new WaitForSeconds(delay);
        boxCollider.isTrigger = false;
    }
}
