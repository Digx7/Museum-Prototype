using UnityEngine;

public class Rotator : MonoBehaviour 
{
    public float rotationSpeed;
    public bool invertDirection = false;
    public bool hasBoarder = false;
    public float minAngle;
    public float maxAngle;
    public TransformAxis rotationAxis;

    private float desiredRotationDirection;
    public void setDesiredRotationDirection(float newDirection)
    {
        desiredRotationDirection = newDirection;
    }

    private void FixedUpdate()
    {
        Rotate();
    }
    
    private void Rotate()
    {
        Vector3 axis = Vector3.up;

        switch (rotationAxis)
        {
            case TransformAxis.X:
                axis = Vector3.right;
                break;
            case TransformAxis.Y:
                axis = Vector3.up;
                break;
            case TransformAxis.Z:
                axis = Vector3.forward;
                break;
            default:
                break;
        }

        float angle = desiredRotationDirection * rotationSpeed;
        if (invertDirection) angle *= -1;

        transform.Rotate(axis, angle);

        if (hasBoarder)
        {
            
        }
    
    }
}