using System;
using Core.UserInput.ScriptableObjects;
using Modules.UI.LevelItem.ScriptableObjects;
using UnityEngine;

namespace Core.UserInput
{
    public abstract class SwipeInputManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        protected bool isListeingEnable = false;
        private bool isMouseButtonDown = false;
        private bool isSwipeCompleted = false;
        private Vector2 mouseButtonDownPosition = new Vector2();
        [SerializeField] private SwipeDistance swipeDistance;
        
        const double Rad2Deg = 180.0 / Math.PI;
        const double Deg2Rad = Math.PI / 180.0;
        private void Update()
        {
            if (isListeingEnable)
            {
                if (isMouseButtonDown && isSwipeCompleted == false)
                {
                    Vector3 newMousePosition = Input.mousePosition;
                    newMousePosition.z = 15;
                    Vector2 newMouseButtonDownPosition = _camera.ScreenToWorldPoint(newMousePosition);
                    float swipeLenght = (mouseButtonDownPosition - newMouseButtonDownPosition).magnitude;
                    if (swipeLenght >= swipeDistance.swipeDistance)
                    {
                        double angle = Angle(mouseButtonDownPosition, newMouseButtonDownPosition);
                        Direction direction = Direction.None;
                        if ((0 < angle && angle < 45) || (315 < angle && angle < 360))
                        {
                            direction = Direction.Right;
                        }
                        else if (45 < angle && angle < 135)
                        {
                            direction = Direction.Up;
                        }
                        else if (135 < angle && angle < 215)
                        {
                            direction = Direction.Left;
                        }
                        else if (215 < angle && angle < 315)
                        {
                            direction = Direction.Down;
                        }


                        if (direction != Direction.None)
                        {
                            OnSwipe(direction);
                            isSwipeCompleted = true;
                        }
                    }
                    
                }
                
                if (isMouseButtonDown == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        var mousePos = Input.mousePosition;
                        mousePos.z = 15;
                        mouseButtonDownPosition = _camera.ScreenToWorldPoint(mousePos);
                        OnClicked(mouseButtonDownPosition);
                        isMouseButtonDown = true;
                    }
                }

                if (isMouseButtonDown)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        isMouseButtonDown = false;
                        isSwipeCompleted = false;
                        OnClickUp();
                    }
                }
            }
        }
        
        private double Angle(Vector2 start, Vector2 end)
        {
            double angle = Math.Atan2(end.y - start.y, end.x - start.x) * Rad2Deg;
            if (angle < 0)
                angle += 360;
            return angle;
        }

        protected abstract void OnSwipe(Direction direction);
        protected abstract void OnClicked(Vector2 position);

        protected abstract void OnClickUp();

    }
    
    
}