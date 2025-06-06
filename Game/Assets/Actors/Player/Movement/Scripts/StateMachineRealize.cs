﻿using System;
using Actors.Player.Movement.Scripts;
using EventBusNamespace;
using PlayerNameSpace;
using StateMachin.States;
using UnityEngine;

public class StateMachineRealize : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerScrObj playerScrObj;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MovementOffsetScr movementOffsetScr;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    private FStateMachine stateMachine;

    private Action<MovementOffsetScr> _changeOffset;
    
    private bool _isInitialized;
    
    public void Initialize(ISubtractionStamina subtractionStamina)
    {
        _changeOffset = ChangeModel;
        
        if (_changeOffset != null) EventBus.Subscribe(_changeOffset);
        
        stateMachine = new FStateMachine();
        
        stateMachine.AddNewState(new IdleState(stateMachine, this));
        stateMachine.AddNewState(new MovementState(stateMachine, this, playerScrObj, rb2D, spriteRenderer, movementOffsetScr, capsuleCollider, animator));
        stateMachine.AddNewState(new SprintRun(stateMachine, this, playerScrObj, rb2D, subtractionStamina, spriteRenderer, movementOffsetScr, capsuleCollider, animator));
        
        stateMachine.ChangeState<IdleState>();
        
        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized)
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (_isInitialized)
        stateMachine.FixedUpdate();
    }

    private void ChangeModel(MovementOffsetScr offsetScr)
    {
        stateMachine.UpdateStateData<MovementState>(offsetScr);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(_changeOffset);
    }
}