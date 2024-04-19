using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera npcCam;
    [SerializeField] private TextMeshProUGUI interactText;
    //bool inRange = false;
    public GameObject dialogueUI;
    public Transform playerTransform;
    public PlayerInteract player;

    private NavMeshAgent npc;

    private void Start()
    {
        npc = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (player.inRange)
        {
            npc.isStopped = true;
            interactText.enabled = true;

            Vector3 direction = (playerTransform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            if (InputManager.isInteracting /*Input.GetKeyUp(KeyCode.F)*/)
            {
                if (!dialogueUI.activeSelf)
                { 
                    dialogueUI.SetActive(true);
                    npcCam.Priority = 2;
                    //Time.timeScale = 0;

                    DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
                    if (dialogueTrigger != null)
                    {
                        dialogueTrigger.TriggerDialogue();
                    }

                    //transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));


                    Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                }
            }
        }
        else 
        {
            interactText.enabled = false;

            if (InputManager.isInteracting && dialogueUI.activeSelf)
            {
                interactText.enabled = false;
                //    //inter
                npcCam.Priority = 0;
                dialogueUI.SetActive(false);
                npc.isStopped = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (!player.inRange && !dialogueUI.activeSelf && npc.isStopped)
            {
                npc.isStopped = false;
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        inRange = true;
    //        //npcCam.Follow = transform;
    //        //npcCam.LookAt = transform;

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        inRange = false;
    //        npcCam.Priority = 0;
    //        GetComponent<NavMeshAgent>().isStopped = false;
    //        dialogueUI.SetActive(false);
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //}
}
