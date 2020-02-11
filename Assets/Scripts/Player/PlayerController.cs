using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(PlayerInput),
                  typeof(CheerMeter_handler),
                  typeof(Speed_handler))]

public class PlayerController : MonoBehaviour
{
   /// <summary>
   /// Las posiciones de los rails
   /// </summary>
   [SerializeField] private Transform[] positions;
   /// <summary>
   /// La que el jugador esta actualmente
   /// </summary>
   private int currentPlayerRail = 1;

   /// <summary>
   /// Input del jugador
   /// </summary>
   private PlayerInput _playerInput;

   /// <summary>
   /// Motor que mueve de un lado a otro al jugador
   /// </summary>
   [SerializeField] private EntityMovement _entityMovement;

   private CheerMeter_handler _cheerMeterHandler;
   private Animation_handler _animationHandler;

   #region Init
   
   /// <summary>
   /// Configs de init
   /// </summary>
   private void Start()
   {
      ReferenceComponents();

      RegisterCommandActions();
      
   }

   private void ReferenceComponents()
   {
      _playerInput = GetComponent<PlayerInput>();
      _cheerMeterHandler = GetComponent<CheerMeter_handler>();
      _animationHandler = GetComponent<Animation_handler>();


   }
   
   /// <summary>
   /// Registro de los comandos
   /// </summary>
   private void RegisterCommandActions()
   {
      _playerInput.OnLeftCommand += MoveLeft;
      _playerInput.OnRightCommand += MoveRight;
      _playerInput.OnCheerCommand += Cheer;
      _playerInput.OnUpCommand += Jump;


      SwipeDetector.OnSwipe += TranslateSwipeInput;
      TapDetector.OnTap += Cheer;
      
      Obstacle.OnCollideWithObstacle += ObstacleOnCollideWithObstacle;
   }

   

   #endregion

   private void TranslateSwipeInput(SwipeData sData)
   {
      switch (sData.Direction)
      {
         case SwipeDirection.Up:
         {
            Jump();
            break;
         }
         case SwipeDirection.Down:
         {

            break;
         }
         case SwipeDirection.Left:
         {
            MoveLeft();
            break;
         }
         case SwipeDirection.Right:
         {
            MoveRight();
            break;
         }
      }
   }
   

   #region Player Commands

   /// <summary>
   /// Comandos para que el personaje actue por inputs del jugador
   /// </summary>
   private void MoveLeft()
   {
      if (currentPlayerRail == 0 || _entityMovement.IsMoving)
         return;

      currentPlayerRail--;
      _entityMovement.GoToPosition(positions[currentPlayerRail].position);
   }
   
   private void MoveRight()
   {
      if (currentPlayerRail == 2 || _entityMovement.IsMoving)
         return;

      currentPlayerRail++;
      _entityMovement.GoToPosition(positions[currentPlayerRail].position);
   }

   private void Cheer()
   {
      //Dar aliento
      _cheerMeterHandler.AddCheer();
   }
   
   private void Jump()
   {
      if (!_entityMovement.IsMoving)
      {
         _entityMovement.Jump();
         _animationHandler.JumpAnimationTrigger();
      }
   }

   private void Crouch()
   {
      //Agacharse
   }

   #endregion

   #region Obstacles

   private void ObstacleOnCollideWithObstacle(Obstacle obstacle)
   {
      _cheerMeterHandler.MinusCheer(obstacle.cheerDrop);
   }

   #endregion
}
