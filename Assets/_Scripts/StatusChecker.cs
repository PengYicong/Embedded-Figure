using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

public class StatusChecker : MonoBehaviour
{
    public RawImage eyeTracker;
    public RawImage headTracker;
    public RawImage connectionTracker;
    public RawImage presenceTracker;
    public Texture red;
    public Texture yellow;
    public Texture green;
    
    // Start is called before the first frame update
    void Start()
    {
        eyeTracker.texture = yellow;
        headTracker.texture = yellow;
        connectionTracker.texture = yellow;
        presenceTracker.texture = yellow;
    }
    void ConnectionCheck()
    {
        if (TobiiAPI.IsConnected)
        {
            connectionTracker.texture = green;
        }
        else
        {
            connectionTracker.texture = red;
        }
    }

    void PresenceTrackerCheck()
    {
        UserPresence userP = TobiiAPI.GetUserPresence();
        if (userP.IsUserPresent())
        {
            presenceTracker.texture = green;
        }
        else
        {
            presenceTracker.texture = red;
        }
    }

    void EyeTrackerCheck()
    {
        GazePoint gazeP = TobiiAPI.GetGazePoint();
        if (gazeP.IsValid && gazeP.IsRecent(3))
        {
            eyeTracker.texture = green;
        }
        else
        {
            eyeTracker.texture = red;
        }
    }

    void HeadTrackerCheck()
    {
        HeadPose headP = TobiiAPI.GetHeadPose();
        if (headP.IsValid && headP.IsRecent(3))
        {
            headTracker.texture = green;
        }
        else
        {
            headTracker.texture = red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        EyeTrackerCheck();
        HeadTrackerCheck();
        PresenceTrackerCheck();
        ConnectionCheck();
    }

}
