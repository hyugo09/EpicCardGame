using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using Cinemachine;

public class PlayerInteraction : MonoBehaviour
{
    bool inRange = false;
    public GameObject dialogueUI;
    public CinemachineVirtualCamera npcCam;
    public Transform playerTransform;

    void Update()
    {
        if (InputManager.interactionInput && inRange)
        {
            dialogueUI.SetActive(true);
            npcCam.Priority = 2;

            DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
            if (dialogueTrigger != null)
            {
                dialogueTrigger.TriggerDialogue();
            }

            transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            npcCam.Follow = transform;
            npcCam.LookAt = transform;
            GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            npcCam.Priority = 0;
            GetComponent<NavMeshAgent>().isStopped = false;
            dialogueUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
