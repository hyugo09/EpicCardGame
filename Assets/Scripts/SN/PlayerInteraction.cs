using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour
{
    bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRange)
        {
            Debug.Log("Interacting with NPC.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
