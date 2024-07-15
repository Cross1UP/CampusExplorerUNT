using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoves : MonoBehaviour
{
    public float XValueLeft, XValueRight;

    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool drag = false;


    private void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = Origin - Difference;
            Camera.main.transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, XValueLeft, XValueRight),
            Mathf.Clamp(Camera.main.transform.position.y, 0, 0), transform.position.z);
        }

        if (Input.GetMouseButtonDown(1))
            Camera.main.transform.position = ResetCamera;
    }

}
