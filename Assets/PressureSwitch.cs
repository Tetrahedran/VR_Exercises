using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PressureSwitch : MonoBehaviour
{
    public float speed = 1;

    public MoveWith[] attached;

    Coroutine moveC = null;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.tag == "Placeable")
        {
            movePlatte(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Placeable")
        {
            movePlatte(true);
        }
    }

    private void movePlatte(bool up)
    {
        Debug.Log("moving " + (up ? "up" : "down"));
        if (moveC == null)
        {
            moveC = StartCoroutine(move(up));
        }
    }

    private IEnumerator move(bool up)
    {
        float increase = 0.005f;
        float waitingTime = increase / speed;
        yield return new WaitForSeconds(0.1f);
        for(float i = 0; i < 1; i += increase)
        {
            foreach(MoveWith other in attached)
            {
                other.move(up, i);
            }
            yield return new WaitForSecondsRealtime(waitingTime);
        }
        moveC = null;
    }
}
