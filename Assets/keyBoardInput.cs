using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Keyboard Input")]
public class keyBoardInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -2.8f;

    public float downTime, upTime, pressTime = 0.0f;
    public float countDown = 2.0f;
    public bool ready = false;

    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
      charController = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {

      // if(Input.GetKeyDown (KeyCode.Space) && !ready){
      //         downTime = Time.time; pressTime = downTime + countDown; ready = true;
      // }
      //  if(Input.GetKeyUp (KeyCode.Space)){ 
      //         ready = false;
      //  }
      //  if(Time.time >= pressTime && ready){
      //         ready = false; 
      //  }

      float deltaX = Input.GetAxis("Horizontal") * speed;
      float deltaZ = Input.GetAxis("Vertical") * speed;
      Vector3 movement = new Vector3(deltaX, 0, deltaZ);
      movement = Vector3.ClampMagnitude(movement, speed);   

      movement.y = gravity;
      movement = transform.TransformDirection(movement);
      charController.Move(movement);   
    }
}
