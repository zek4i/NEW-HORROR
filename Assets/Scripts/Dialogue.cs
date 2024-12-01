using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //using this as an obj to pass in the dialog manager class
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences; 
}
