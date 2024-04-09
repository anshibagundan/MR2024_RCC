using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // ���X�|�[��������GameObject�̃��X�g
    public Vector3 spawner; // �����ʒu

    void Start()
    {
        // objectsToRespawn�z�񂩂�Prefab���擾���ď����ʒu�ɐ���
        Instantiate(objectsToRespawn[0], spawner, Quaternion.identity);
    }
    private void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {

            // �Փˎ��ɐV�����Q�[���I�u�W�F�N�g�𐶐�����
            Instantiate(objectsToRespawn[Random.Range(0, objectsToRespawn.Length)], spawner, Quaternion.identity);
        }
    }
}
