﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFDConsumer : MonoBehaviour
{

    GameObject broadcastRoot;
    public float listenTime;
    public string name;
    [SerializeField]
    float suppressionTime;
    Queue<Packet> incMulticastInterests;

    void Awake()
    {
        //Set name of node
        if (name == "")
        {
            //Set to name of game object.
            name = gameObject.name;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        incMulticastInterests = new Queue<Packet>();
        broadcastRoot = gameObject.transform.parent.gameObject;

        Packet message = new Packet("/test/interest", 0.0f, this.gameObject, Packet.PacketType.Interest);

        if (name == "Con A") {
            broadcastRoot.BroadcastMessage("OnMulticastInterest", message, SendMessageOptions.DontRequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMulticastInterest(Packet interest)
    {
        if(interest.sender.name == gameObject.name)
        {
            return;
        }

        //Find the distance between sender and this node.  This is the propagation delay.
        float distance = Mathf.Abs(Vector3.Distance(interest.sender.transform.position, gameObject.transform.position));

        logMessage("Interest from " + interest.sender.name + " with name " + interest.name + " (distance " + distance + ")");
    }

    void OnMulticastData(Packet data)
    {
        if(data.sender.name == gameObject.name)
        {
            return;
        }

        //Find the distance between sender and this node.  This is the propagation delay.
        float distance = Mathf.Abs(Vector3.Distance(data.sender.transform.position, gameObject.transform.position));

        logMessage("Data from " + data.sender.name + " with name " + data.name + " (distance " + distance + ")");
    }

    void logMessage(string message) 
    {
        Debug.Log(name + ": " + message);
    }

}
