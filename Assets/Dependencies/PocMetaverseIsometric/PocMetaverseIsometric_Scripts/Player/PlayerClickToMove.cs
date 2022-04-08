using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerClickToMove : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {
                Vector3 destinationPoint = hitInfo.point;
                if (hitInfo.collider.name == "ItemCollider")
                {
                    RaycastHit[] hits = Physics.RaycastAll(hitInfo.collider.transform.position, Vector3.down, 10, layerMask);

                    destinationPoint = Array.Find(hits, x => x.collider.name == "GroundCollider").point;
                }

                agent.SetDestination(destinationPoint);
            }
        }
    }
}
