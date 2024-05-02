using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour, IDestructable
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
