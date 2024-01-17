using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAI : MonoBehaviour
{
   public bool IsInRange(Transform target,float range)
    {
        float distance = Vector2.Distance(transform.position, target.position);
        return distance < range;
    }
}
