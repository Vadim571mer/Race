using UnityEngine;

[Icon("Assets/Realistic Car Controller Pro/Resources/Editor Icons/RCCP_EditorIcon_Component.png")]
public class RCCP_TryGetComponentInChildren
{
    public static T Get<T>(Transform transform)
    {
        T comp;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent<T>(out comp))
                return comp;
        }

        return default;
    }
}