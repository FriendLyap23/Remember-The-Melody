using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockInterations : MonoBehaviour
{
    public void EnableTileInteraction(List<EventTrigger> components, bool enable)
    {
        foreach (var component in components)
            component.enabled = enable;
    }
}
