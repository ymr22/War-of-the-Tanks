using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    //public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.
    //public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
    //public float m_MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
    public Transform[] m_Targets; // All the targets the camera needs to encompass.


    //private Camera m_Camera;                        // Used for referencing the camera.
    //private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
    //private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
    //private Vector3 m_DesiredPosition;              // The position the camera is moving towards.


    private Vector3 offset ;
    
    void Start () {
        offset = transform.position - m_Targets[0].position;
    }

    void Update ()
    {
        transform.position = m_Targets[0].position + offset;
        transform.rotation = m_Targets[0].rotation;
        
    }

    public void SetStartPositionAndSize ()
    {
      
        transform.position = m_Targets[0].position;

    }
}