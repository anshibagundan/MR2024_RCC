using Oculus.Interaction.HandGrab;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class spawn_event : MonoBehaviour
{
    private float collisionStartTime = 0f; // �Փ˂��n�܂�������
    private bool isColliding = false; // �Փ˒����ǂ����̃t���O

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

            // �Փ˒��ł��邱�Ƃ��L�^���A���݂̎�����ۑ�����
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
            // �Փ˂��I��������t���O�����Z�b�g
            isColliding = false;
        }
    }

    private void Update()
    {
        if (isColliding && Time.time - collisionStartTime >= 2f)
        {
            // �Փ˂�2�b�ȏ�p�����Ă���ꍇ�A����̏��������s����
            // �����ł̓^�O�� "Sphere" �̃I�u�W�F�N�g�� Rigidbody �̏d�͂𔽓]������
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

