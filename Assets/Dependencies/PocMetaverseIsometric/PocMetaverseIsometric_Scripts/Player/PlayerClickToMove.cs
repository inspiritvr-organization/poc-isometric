using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerClickToMove : MonoBehaviour
{
    private const string GroundColliderName = "GroundCollider";
    private const string ItemColliderName = "ItemCollider";

    [SerializeField] LayerMask layerMask;
    private NavMeshAgent agent;

    public event Action OnClickMovementStarted;
    public event Action OnClickMovementFinished;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            agent.enabled = true;
            agent.isStopped = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {
                Vector3 destinationPoint = hitInfo.point;
                if (hitInfo.collider.name == ItemColliderName)
                {
                    RaycastHit[] hits = Physics.RaycastAll(hitInfo.collider.transform.position, Vector3.down, 10, layerMask);

                    destinationPoint = Array.Find(hits, x => x.collider.name == GroundColliderName).point;
                }

                agent.SetDestination(destinationPoint);
            }

            OnClickMovementStarted?.Invoke();
        }
        if (Vector3.Distance(agent.transform.position, agent.destination) <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            agent.enabled = false;
            OnClickMovementFinished?.Invoke();
        }
    }
}
