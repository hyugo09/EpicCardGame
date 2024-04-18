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


    private void Update()
    {
        
        if (player.inRange == true)
        {
            NavMeshAgent npc = GetComponent<NavMeshAgent>();
            npc.isStopped = true;
            interactText.enabled = true;

            if (InputManager.isInteracting /*Input.GetKeyUp(KeyCode.F)*/)
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
        else if (InputManager.isInteracting && dialogueUI)
        {
            interactText.enabled = false;
            //inter
            npcCam.Priority = 0;
            GetComponent<NavMeshAgent>().isStopped = false;
            dialogueUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (!player.inRange)
        {
            interactText.enabled = false;
           
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
