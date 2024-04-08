using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // ���X�|�[��������GameObject�̃��X�g
    public Vector3 initialPosition; // �����ʒu

    void Start()
    {
        // objectsToRespawn�z�񂩂�Prefab���擾���ď����ʒu�ɐ���
        if (objectsToRespawn.Length > 0)
        {
            GameObject spawnedObject = Instantiate(objectsToRespawn[0], initialPosition, Quaternion.identity);
        }
        //initialPosition = transform.position; // �����ʒu��ۑ�
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // �Փ˂����I�u�W�F�N�g�� "Hand Grab Interactable" �X�N���v�g���擾
            //HandGrabInteractable handGrabInteractable = collision.gameObject.GetComponent<>();

            // �����擾�ł����ꍇ�� null �ɐݒ�
            //if (handGrabInteractable != null)
            //{
            //    handGrabInteractable = null;
            //}

            RespawnRandom(); // �����_���ȃI�u�W�F�N�g�����X�|�[��
        }
    }

    void RespawnRandom()
    {
        if (objectsToRespawn.Length > 0)
        {
            int randomIndex = Random.Range(0, objectsToRespawn.Length); // �����_���ȃC���f�b�N�X��I��
            GameObject objectToRespawnPrefab = objectsToRespawn[randomIndex]; // �����_���ɑI������Prefab

            // �����ʒu��Prefab�𐶐����ă��X�|�[��
            GameObject spawnedObject = Instantiate(objectToRespawnPrefab, initialPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No objects to respawn."); // ���X�|�[������I�u�W�F�N�g���Ȃ��ꍇ�͌x����\��
        }
    }
}
