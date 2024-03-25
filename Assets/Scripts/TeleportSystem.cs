using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField]Debugger logger;
    [Header("Portals")]
    [SerializeField]Transform portal1;
    [SerializeField]Transform portal2;
    private Vector3 currentPlayerPos;
    private Vector3 portal1Pos;
    private Vector3 portal2Pos;
    void Awake()
    {
        currentPlayerPos = PlayerController.playerPos;
        Debugger.DebuggerLoader(ref logger);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        portal1Pos = portal1.position;
        portal1Pos = portal2.position;
        currentPlayerPos = PlayerController.playerPos;
        Teleport(currentPlayerPos, portal1Pos, portal2Pos);
        logger.Log("Questa è la posizione corrente del player;" + " " + currentPlayerPos, this); 
    }

    void Teleport(Vector3 currentPlayerPos, Vector3 portal1Pos, Vector3 portal2Pos)
    {
        if (currentPlayerPos == portal1Pos)
        {
            currentPlayerPos = portal2Pos;
        }
        else if (currentPlayerPos == portal2Pos)
        {
            currentPlayerPos = portal1Pos;
        }
    }
}