using UnityEngine;

public abstract class MovingCharacter : Character
{
    [SerializeField] private CharacterController controller;
    
    protected CharacterController Controller => controller;

}