using UnityEngine;
using System.Collections;

public class ImageLoader : MonoBehaviour {

	public static Sprite LoadSprite(string url)
    {
        Sprite sp = Resources.Load<Sprite>(url);
        if (sp == null)
        {
            LoggingManager.AddErrorToLog("Didnt found image "+url);
        }
        return sp;
    }
}
