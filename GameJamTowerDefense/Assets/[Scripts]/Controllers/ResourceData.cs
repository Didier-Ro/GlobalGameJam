using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceData : MonoBehaviour
{

    [Serializable]
    public struct WeaponConfig
    {
        public string WeaponName;
        public int WeaponCost;
    }

    public WeaponConfig[] WeaponsCosts;
}
