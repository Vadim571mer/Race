using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller Pro/AI/RCCP Waypoint")]
public class RCCP_Waypoint : RCCP_GenericComponent
{
    /// <summary>
    /// Target speed for AI. 
    /// </summary>
    [Range(0f, 360f)] public float targetSpeed = 100f;
}