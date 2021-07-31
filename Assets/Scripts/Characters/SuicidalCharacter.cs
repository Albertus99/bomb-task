using UnityEngine;

public class SuicidalCharacter : MovingCharacter
{
    private Collider[] buffer = new Collider[10];
    protected override void OnIterate()
    {
        base.OnIterate();

        var count = Physics.OverlapSphereNonAlloc(transform.position, 20, buffer, 1 << 8);

        if (count > 0)
        {
            MoveTo(buffer[0].transform.position);
        }
    }
}