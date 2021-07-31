using UnityEngine;

public class RunnerCharacter : MovingCharacter
{

    [SerializeField] private float baseInterval = 3;
    [SerializeField] private float moveRadius = 5;
    
    private Vector3 targetPosition;
    private float lastDecision = float.MinValue;
    private float nextInterval = 0;
    
    protected override void OnIterate()
    {
        DecideTargetPosition();

        var moveVector = targetPosition - transform.position;
        moveVector.y = 0;
        var speedMoveVector = moveVector.normalized * 0.05f;

        Controller.Move(moveVector.magnitude > speedMoveVector.magnitude ? speedMoveVector : moveVector);
        
    }

    void DecideTargetPosition()
    {
        if (Time.time - lastDecision > nextInterval)
        {
            var randomVector2 = Random.insideUnitCircle * moveRadius;

            var randomVector3 = new Vector3(randomVector2.x, 0, randomVector2.y);

            targetPosition = transform.position + randomVector3;

            lastDecision = Time.time;

            nextInterval = baseInterval * Random.Range(0.9f, 1.1f);
        }
    }
}