﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NFDNode : MonoBehaviour
{
    [SerializeField]
    protected float minPropDelay;
    [SerializeField]
    protected float maxPropDelay;

    public abstract void OnMulticastInterest(Packet interest);
    public abstract void OnMulticastData(Packet data);
}
