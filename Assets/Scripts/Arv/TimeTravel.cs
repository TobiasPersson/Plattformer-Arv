using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : PowerUpItem
{
    [SerializeField]
    List<Vector3> savedPos = new List<Vector3>();
    [SerializeField]
    int maxTime = 3;
    bool isRecording = true;
    public override void PowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RewindTime());
        }
        else if (isRecording)
        {
            RecordPos();
        }
    }
    
    IEnumerator RewindTime()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        isRecording = false;
        for (int i = savedPos.Count-1; i > 0; i--)
        {
            player.transform.position = savedPos[i];
            savedPos.RemoveAt(i);
            yield return new WaitForEndOfFrame();
        }
        rb.isKinematic = false;
        isRecording = true;
        yield return null;
    }

    public void RecordPos()
    {
        savedPos.Add(player.transform.position);
        if (savedPos.Count > maxTime * 60)
        {
            savedPos.RemoveAt(0);
        }
    }
}
