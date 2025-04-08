using UnityEngine;

[Icon("Assets/Realistic Car Controller Pro/Resources/Editor Icons/RCCP_EditorIcon_Manager.png")]
public class RCCP_PrototypeContent : ScriptableObject
{
    public int instanceId = 0;
    
    public RCCP_CarController[] vehicles;

    private static RCCP_PrototypeContent instance;

    public static RCCP_PrototypeContent Instance
    {
        get
        {
            if (instance == null) 
                instance = Resources.Load("RCCP_PrototypeContent") as RCCP_PrototypeContent;
            return instance;
        }
    }
}