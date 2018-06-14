using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRotation
{
    Vector3 rotationSpeed = new Vector3(0, 20, 0);

    public enum Direction
    {
        Right,
        Left
    }

    private Direction direction;
    private bool turnOverEnable;

    public Direction P_Direction
    {
        get { return direction; }
    }
    public bool P_TurnOverEnable
    {
        get { return turnOverEnable; }
    }

    public ChangeRotation()
    {
        direction = Direction.Right;
        turnOverEnable = false;
    }

    public void ResetRotation()
    {
        direction = Direction.Right;
    }

    public void ChangeDirection(float vec, GameObject obj)
    {
        if (direction == Direction.Right)
        {
            if (vec < 0)
                turnOverEnable = true;
        }
        if (direction == Direction.Left)
        {
            if (vec > 0)
                turnOverEnable = true;
        }

        //左へ回転
        if (turnOverEnable && direction == Direction.Right)
        {
            if (obj.transform.eulerAngles.y < 270)
                obj.transform.Rotate(rotationSpeed);
            else
            {
                direction = Direction.Left;
                turnOverEnable = false;
            }
        }
        //右へ回転
        if (turnOverEnable && direction == Direction.Left)
        {
            if (obj.transform.eulerAngles.y >= 270 || obj.transform.eulerAngles.y < 90)
                obj.transform.Rotate(rotationSpeed);
            else
            {
                direction = Direction.Right;
                turnOverEnable = false;
            }
        }
    }
}
