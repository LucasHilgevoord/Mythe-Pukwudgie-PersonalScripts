using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AreaInfo {

    public string areaName;

    [TextArea(3, 10)]
    public string areaDescription;

}