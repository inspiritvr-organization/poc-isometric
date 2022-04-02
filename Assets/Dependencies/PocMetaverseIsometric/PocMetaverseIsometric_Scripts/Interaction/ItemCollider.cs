using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    [SerializeField] InteractionZone interactionZone;

    public InteractionZone InteractionZone => interactionZone;
}
