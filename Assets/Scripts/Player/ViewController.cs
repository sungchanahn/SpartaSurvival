using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ViewType
{
    FirstPerson,
    ThirdPerson
    //TopView
}

public class ViewController : MonoBehaviour
{
    public Camera camera;
    public Transform thirdPersonView;
    public ViewType type;

    private void Awake()
    {
        camera = Camera.main;
        type = ViewType.FirstPerson;
    }

    public void OnSwitchingView(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            switch (type)
            {
                case ViewType.FirstPerson:
                    camera.transform.localPosition = thirdPersonView.localPosition;
                    type = ViewType.ThirdPerson;
                    break;
                case ViewType.ThirdPerson:
                    camera.transform.localPosition = Vector3.zero;
                    type= ViewType.FirstPerson;
                    break;
            }
        }
    }
}
