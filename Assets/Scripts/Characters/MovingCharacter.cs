using UnityEngine;

public abstract class MovingCharacter : Character
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 5;
    protected CharacterController Controller => controller;

    protected override void OnIterate()
    {
        var gravity = Vector3.down;
        
        Controller.Move(gravity);
        base.OnIterate();
    }

    protected void MoveTo(Vector3 targetPosition)
    {
        var moveVector = targetPosition - transform.position;
        moveVector.y = 0;
        var speedMoveVector = moveVector.normalized * (0.01f * moveSpeed);

        Controller.Move((moveVector.magnitude > speedMoveVector.magnitude ? speedMoveVector : moveVector));
    }
}