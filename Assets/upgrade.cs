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
        // �Փ˂����I�u�W�F�N�g���������g�Ɠ������O�̏ꍇ
        if (this.gameObject.name == collision.gameObject.name)
        {
            // �������g�̃Q�[���I�u�W�F�N�g��j������
            Destroy(this.gameObject);

            // �Փ˂����I�u�W�F�N�g��Upgrade�R���|�[�l���g�������Ă����ꍇ
            Upgrade upgradeComponent = collision.gameObject.GetComponent<Upgrade>();
            if (upgradeComponent != null)
            {
                // �A�b�v�O���[�h��̃I�u�W�F�N�g���ݒ肳��Ă���ꍇ
                if (upgradedObject != null)
                {
                    // �A�b�v�O���[�h��̃I�u�W�F�N�g�𐶐����A�����ʒu�Ɖ�]�Ŕz�u����
                    Instantiate(upgradedObject, this.transform.position, this.transform.rotation);
                }
            }
        }
    }
}
