using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWith : MonoBehaviour
{
    public Vector3 offset;

    public bool invert;

    private Vector3 startPos;

    private Vector3 targetPos;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + offset;
    }

    public void move(bool toStartPos, float position)
    {
        if(toStartPos ^ invert)
        {
            moveTransform(targetPos, startPos, position);
        }
        else
        {
            moveTransform(startPos, targetPos, position);
        }
    }

    private void moveTransform(Vector3 Start, Vector3 End, float Position)
    {
        transform.position = Vector3.Slerp(Start, End, Position);
    }
}
