using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable_Objects/Directed Graph Container")]
[System.Serializable]
public class DGContainer : ScriptableObject
{
    public List<DGLinkData> DGLinkData = new List<DGLinkData>();
    public List<DGNodeData> DGNodeData = new List<DGNodeData>();
}
