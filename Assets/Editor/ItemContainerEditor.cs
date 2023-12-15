using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
[CustomEditor(typeof(ItenContainer))]
public class ItemContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItenContainer container = target as ItenContainer;
        if(GUILayout.Button("Clear container"))
        {
            for(int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].item = null;
                container.slots[i].count = 0;
            }
        }
        DrawDefaultInspector();
    }
}
