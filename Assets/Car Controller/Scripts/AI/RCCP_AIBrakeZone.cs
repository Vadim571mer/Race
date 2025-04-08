using UnityEngine;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller Pro/AI/RCCP AI Brake Zone")]
public class RCCP_AIBrakeZone : RCCP_GenericComponent
{
    /// <summary>
    /// Actual trigger.
    /// </summary>
    private BoxCollider trigger;

    /// <summary>
    /// Target speed.
    /// </summary>
    [Range(5f, 360f)] public float targetSpeed = 50;

    private void Awake()
    {
        //  Getting trigger.
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enabled)
            return;

        //  Getting main car controller.
        RCCP_CarController carController = other.GetComponentInParent<RCCP_CarController>();

        //  If object is not a vehicle, return.
        if (!carController)
            return;

        //  If object is a vehicle, but missing component root, return.
        if (!carController.OtherAddonsManager)
            return;

        //  Of object is vehicle, but missing AI controller, return.
        if (!carController.OtherAddonsManager.AI)
            return;

        //  If trigger bounds contains car controller position, call "Entered Brake Zone" method in the AI script.
        if (trigger.bounds.Contains(carController.transform.position))
            carController.OtherAddonsManager.AI.EnteredBrakeZone(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enabled)
            return;

        //  Getting main car controller.
        RCCP_CarController carController = other.GetComponentInParent<RCCP_CarController>();

        //  If object is not a vehicle, return.
        if (!carController)
            return;

        //  If object is a vehicle, but missing component root, return.
        if (!carController.OtherAddonsManager)
            return;

        //  Of object is vehicle, but missing AI controller, return.
        if (!carController.OtherAddonsManager.AI)
            return;

        //  AI exits from the brake zone, call "ExitedBrakeZone" method in the AI script.
        carController.OtherAddonsManager.AI.ExitedBrakeZone();
    }
}