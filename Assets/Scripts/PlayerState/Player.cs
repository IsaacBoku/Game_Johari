using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : Entity
{

    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;
    //public float swordReturnImpact;
    private float defaultMoveSpeed;
    private float defaultJumpForce;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSliderState wallSlider {  get; private set; }
    public PlayerWallJumpState wallJump {  get; private set; }




    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        wallSlider = new PlayerWallSliderState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");


    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);

        defaultMoveSpeed = moveSpeed;
        defaultJumpForce = jumpForce;
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();

        moveSpeed = defaultMoveSpeed;
        jumpForce = defaultJumpForce;

    }
    public override void Die()
    {
        base.Die();
    }
}
