using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    InputAction MoveAction;
    InputAction SprintAction;
    InputAction LookAction;
    InputAction JumpAction;
    InputAction InteractAction;
  
    public bool fliplook;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        SprintAction = InputSystem.actions.FindAction("Sprint");
        LookAction = InputSystem.actions.FindAction("Look");
        InteractAction = InputSystem.actions.FindAction("Interact");
        
    }
    public Vector3 GetMoveDirection()
    {
        Vector2 dir = MoveAction.ReadValue<Vector2>();
        return new Vector3(dir.x, 0, dir.y);
    }
    public bool IsSprinting()
    {
        return SprintAction.IsPressed();
    }

    public bool IsInteracting()
    {
        return InteractAction.IsPressed();  
    }

    public Vector3 GetLookRotation()
    {
        Vector2 dir = LookAction.ReadValue<Vector2>();
        float flip = fliplook ? 1f : -1f;
        return new Vector3(dir.y * flip, dir.x, 0);
    }
    public float GetLookRotationAlt()
    {
        Vector2 dir = LookAction.ReadValue<Vector2>();
        return dir.x;
    }


}