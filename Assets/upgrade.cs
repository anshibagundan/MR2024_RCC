using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // �A�b�v�O���[�h��̃I�u�W�F�N�g
    public GameObject upgradedObject;

    // OnCollisionEnter�́A�I�u�W�F�N�g�����̃I�u�W�F�N�g�ƏՓ˂����Ƃ��ɌĂяo����܂�
    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.name == collision.gameObject.name)
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Upgrade>().upgradedObject = null;
            if (upgradedObject)
            {
                Instantiate(upgradedObject, this.transform.position, this.transform.rotation);
            }
        }
    }
}
