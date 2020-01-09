using UnityEngine;

public class Selection : MonoBehaviour
{
    #region Private & Protected Members

    private Vector3 _delta;
    private float _zCam;

    #endregion

    #region System

    void OnMouseDown()
    {
        _zCam = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        _delta = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = _zCam ;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()

    {
        transform.position = GetMouseAsWorldPoint() + _delta;
    }

    #endregion

}

