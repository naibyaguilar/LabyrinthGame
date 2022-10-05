using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes{
        MousesXAnY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axesM = RotationAxes.MousesXAnY;
    public float sensitivyHor = 9.0f;
    public float sensitivyVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float verticalRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null){
            body.freezeRotation = true;
        }
        Debug.Log("MouseLook iniciado");        
    }

    // Update is called once per frame
    void Update()
    {
        if(axesM == RotationAxes.MouseX){
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivyHor, 0);
        }else if(axesM == RotationAxes.MouseY){
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivyVert;
            verticalRot = Mathf.Clamp(verticalRot * 0, minimumVert, maximumVert * 0);
            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot * 0, horizontalRot, 0);
        }else{
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivyHor;
            verticalRot = Mathf.Clamp(verticalRot * 0, minimumVert, maximumVert * 0);
            float delta = Input.GetAxis("Mouse X") * sensitivyHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(0, horizontalRot, 0);

        }
        
    }
}
