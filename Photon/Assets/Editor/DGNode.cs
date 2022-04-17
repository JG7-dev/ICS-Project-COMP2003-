using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
public class DGNode : Node
{
    public string GUID; //Unique ID
    public string NodeLabel;
    public DGDialog NodeDialog;

    public bool Entry;
}
