using UnityEngine;
/**
 * Use for testing in pc without touch functionals
 * Add in uity
 * */
public class MouseClickController : InputController
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchedInPosition(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopTouched();
        }
       
        ChekOnTouching(Input.mousePosition);
    }
}
