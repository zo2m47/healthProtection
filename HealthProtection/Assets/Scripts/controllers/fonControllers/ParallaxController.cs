using UnityEngine;
using System.Collections;
/*
 * Controller of parallax prefab 
 * */
public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _image;

    private ParallaxVO _parallaxData;

    private Vector2 _oldCameraPosition;
    public void Start()
    {
        if (_image == null)
        {
            _image = GetComponent<SpriteRenderer>() as SpriteRenderer;
        }
    }

    public void SetData(ParallaxVO parallax)
    {
        _parallaxData = parallax;
        _image.sortingOrder = -1 * parallax.index;
        _image.sprite = ImageLoader.LoadSprite(parallax.viewImageUrl);
        //set default position
        _oldCameraPosition = Vector2.zero;
    }

    public void Update()
    {
        if (_oldCameraPosition.x != CameraNavigationManager.Instance.cameraXPosition || _oldCameraPosition.y != CameraNavigationManager.Instance.cameraYPosition)
        {
            _oldCameraPosition.x = CameraNavigationManager.Instance.cameraXPosition;
            _oldCameraPosition.y = CameraNavigationManager.Instance.cameraYPosition;
            gameObject.transform.position = new Vector3(_oldCameraPosition.x/_parallaxData.deltaMove, _oldCameraPosition.y / _parallaxData.deltaMove, gameObject.transform.position.z);
        }
    }

    public void ResetParallax()
    {
        PrefabCreatorManager.Instance.DestroyPrefab(gameObject);
    }
}
