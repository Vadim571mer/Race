//----------------------------------------------
//        Realistic Car Controller Pro
//
// Copyright � 2014 - 2024 BoneCracker Games
// https://www.bonecrackergames.com
// Ekrem Bugra Ozdoganlar
//
//----------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
#if UNITY_EDITOR
[InitializeOnLoad]
static class RCCP_HierarchyIcons {

    static UnityEngine.Object RCCP_SceneManagerTexture;
    static UnityEngine.Object RCCP_CameraTexture;
    static UnityEngine.Object RCCP_UIManagerTexture;
    static UnityEngine.Object RCCP_FixedCameraTexture;
    static UnityEngine.Object RCCP_CinematicCameraTexture;
    static UnityEngine.Object RCCP_SkidmarksManagerTexture;
    static UnityEngine.Object RCCP_AIWaypointsContainerTexture;
    static UnityEngine.Object RCCP_CarControllerTexture;
    static UnityEngine.Object IRCCP_ComponentTexture;

    static string RCCP_SceneManagerTexturePath;
    static string RCCP_CameraTexturePath;
    static string RCCP_UIManagerTexturePath;
    static string RCCP_FixedCameraTexturePath;
    static string RCCP_CinematicCameraTexturePath;
    static string RCCP_SkidmarksManagerTexturePath;
    static string RCCP_AIWaypointsContainerTexturePath;
    static string RCCP_CarControllerTexturePath;
    static string IRCCP_ComponentTexturePath;

    // add your components and the associated icons here
    static Dictionary<Type, GUIContent> typeIcons = new Dictionary<Type, GUIContent>() { };

    // cached game object information
    static Dictionary<int, GUIContent> labeledObjects = new Dictionary<int, GUIContent>();
    static HashSet<int> unlabeledObjects = new HashSet<int>();
    static GameObject[] previousSelection = null; // used to update state on deselect

    // set up all callbacks needed
    static RCCP_HierarchyIcons() {

        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;

        // callbacks for when we want to update the object GUI state:
        ObjectFactory.componentWasAdded += c => UpdateObject(c.gameObject.GetInstanceID());
        // there's no componentWasRemoved callback, but we can use selection as a proxy:
        Selection.selectionChanged += OnSelectionChanged;

    }

    static void OnHierarchyGUI(int id, Rect rect) {

        if (unlabeledObjects.Contains(id))
            return; // don't draw things with no component of interest

        if (ShouldDrawObject(id, out GUIContent icon)) {

            // GUI code here
            rect.xMin = rect.xMax - 20; // right-align the icon
            GUI.Label(rect, icon);

        }

    }

    static bool ShouldDrawObject(int id, out GUIContent icon) {

        if (labeledObjects.TryGetValue(id, out icon))
            return true;

        // object is unsorted, add it and get icon, if applicable
        return SortObject(id, out icon);

    }

    static bool SortObject(int id, out GUIContent icon) {

        RCCP_SceneManagerTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Manager");
        RCCP_CameraTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Manager");
        RCCP_UIManagerTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Manager");
        RCCP_FixedCameraTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Other");
        RCCP_CinematicCameraTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Other");
        RCCP_SkidmarksManagerTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Manager");
        RCCP_AIWaypointsContainerTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Other");
        RCCP_CarControllerTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Vehicle");
        IRCCP_ComponentTexture = Resources.Load("Editor Icons/RCCP_EditorIcon_Component");

        if (RCCP_SceneManagerTexture)
            RCCP_SceneManagerTexture.hideFlags = HideFlags.None;

        if (RCCP_AIWaypointsContainerTexture)
            RCCP_AIWaypointsContainerTexture.hideFlags = HideFlags.None;

        if (RCCP_CarControllerTexture)
            RCCP_CarControllerTexture.hideFlags = HideFlags.None;

        if (IRCCP_ComponentTexture)
            IRCCP_ComponentTexture.hideFlags = HideFlags.None;

        RCCP_SceneManagerTexturePath = RCCP_SceneManagerTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_SceneManagerTexture)) : "";
        RCCP_CameraTexturePath = RCCP_CameraTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_CameraTexture)) : "";
        RCCP_UIManagerTexturePath = RCCP_UIManagerTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_UIManagerTexture)) : "";
        RCCP_FixedCameraTexturePath = RCCP_FixedCameraTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_FixedCameraTexture)) : "";
        RCCP_CinematicCameraTexturePath = RCCP_CinematicCameraTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_CinematicCameraTexture)) : "";
        RCCP_SkidmarksManagerTexturePath = RCCP_SkidmarksManagerTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_SkidmarksManagerTexture)) : "";
        RCCP_AIWaypointsContainerTexturePath = RCCP_AIWaypointsContainerTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_AIWaypointsContainerTexture)) : "";
        RCCP_CarControllerTexturePath = RCCP_CarControllerTexture != null ? (RCCP_GetAssetPath.GetAssetPath(RCCP_CarControllerTexture)) : "";
        IRCCP_ComponentTexturePath = IRCCP_ComponentTexture != null ? (RCCP_GetAssetPath.GetAssetPath(IRCCP_ComponentTexture)) : "";

        typeIcons = new Dictionary<Type, GUIContent>() {

        { typeof(RCCP_SceneManager), EditorGUIUtility.IconContent( RCCP_SceneManagerTexturePath ) },
        { typeof(RCCP_Camera), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_CameraTexture) ) },
        { typeof(RCCP_UIManager), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_UIManagerTexture) ) },
        { typeof(RCCP_FixedCamera), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_FixedCameraTexture) ) },
        { typeof(RCCP_CinematicCamera), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_CinematicCameraTexture) ) },
        { typeof(RCCP_SkidmarksManager), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_SkidmarksManagerTexture) ) },
        { typeof(RCCP_AIWaypointsContainer), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_AIWaypointsContainerTexture) ) },
        { typeof(RCCP_CarController), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(RCCP_CarControllerTexture) ) },
        { typeof(IRCCP_Component), EditorGUIUtility.IconContent( AssetDatabase.GetAssetPath(IRCCP_ComponentTexture) ) },

    };

        GameObject go = EditorUtility.InstanceIDToObject(id) as GameObject;

        if (go != null) {

            foreach ((Type type, GUIContent typeIcon) in typeIcons) {

                if (go.GetComponent(type)) {

                    labeledObjects.Add(id, icon = typeIcon);
                    return true;

                }

            }

        }

        unlabeledObjects.Add(id);
        icon = default;
        return false;

    }

    static void UpdateObject(int id) {

        unlabeledObjects.Remove(id);
        labeledObjects.Remove(id);
        SortObject(id, out _);

    }

    const int MAX_SELECTION_UPDATE_COUNT = 3; // how many objects we want to allow to get updated on select/deselect

    static void OnSelectionChanged() {

        TryUpdateObjects(previousSelection); // update on deselect
        TryUpdateObjects(previousSelection = Selection.gameObjects); // update on select

    }

    static void TryUpdateObjects(GameObject[] objects) {

        if (objects != null && objects.Length > 0 && objects.Length <= MAX_SELECTION_UPDATE_COUNT) { // max of three to prevent performance hitches when selecting many objects

            foreach (GameObject go in objects) {
                UpdateObject(go.GetInstanceID());

            }

        }

    }

}
#endif