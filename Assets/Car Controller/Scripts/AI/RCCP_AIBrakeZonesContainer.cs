using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller Pro/AI/RCCP AI Brake Zones Container")]
public class RCCP_AIBrakeZonesContainer : RCCP_GenericComponent
{
    /// <summary>
    ///  Brake Zones list.
    /// </summary>
    public List<RCCP_AIBrakeZone> brakeZones = new List<RCCP_AIBrakeZone>();

    private void Awake()
    {
        // Changing all layers to ignore raycasts to prevent lens flare occlusion.
        foreach (var item in brakeZones)
            item.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    /// <summary>
    /// Getting brake zones and adding them to the list.
    /// </summary>
    public void GetAllBrakeZones()
    {
        if (brakeZones == null)
            brakeZones = new List<RCCP_AIBrakeZone>();

        brakeZones.Clear();

        brakeZones = GetComponentsInChildren<RCCP_AIBrakeZone>(true).ToList();
    }

    /// <summary>
    /// Used for drawing gizmos on Editor.
    /// </summary>
    private void OnDrawGizmos()
    {
        for (int i = 0; i < brakeZones.Count; i++)
        {
            if (brakeZones[i] != null && brakeZones[i].gameObject.activeSelf)
            {
                Gizmos.matrix = brakeZones[i].transform.localToWorldMatrix;
                Gizmos.color = new Color(1f, 0f, 0f, .25f);
                Vector3 colliderBounds = brakeZones[i].GetComponent<BoxCollider>().size;

                Gizmos.DrawCube(Vector3.zero, colliderBounds);
            }
        }
    }
}