using UnityEngine;
/**
 * Controller scale camers 
 * */
[ExecuteInEditMode]
public class ScaleWidthCamera : MonoBehaviour {

	public int targetWidth = 1920;
	public float pixelsToUnits = 10;

    [SerializeField]
    private Camera _mainCamera;
	void Update() {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
        float h = height / pixelsToUnits;

        Debug.Log("height " + h);
        if(_mainCamera == null)
        {
            _mainCamera = GetComponent<Camera>();
        }
        _mainCamera.orthographicSize = height / pixelsToUnits / 2;
	}
}
