using UnityEngine;

[Icon("Assets/Realistic Car Controller Pro/Resources/Editor Icons/RCCP_EditorIcon_Other.png")]
public class RCCP_UIComponent : MonoBehaviour
{
    public RCCP_Settings RCCPSettings
    {
        get
        {
            if (_RCCPSettings == null)
                _RCCPSettings = RCCP_Settings.Instance;

            return _RCCPSettings;
        }
    }

    private RCCP_Settings _RCCPSettings;
}