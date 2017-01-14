using System;
using System.Xml.Serialization;
/**
 * static data of core
 * */
public class CoreVO:DataVO
{
    [XmlAttribute("view")]
    public string view;

    [XmlAttribute("health")]
    public int health;

    public string viewImageUrl
    {
        get
        {
            return UrlImages.core+view;
        }
    }

    public string viewPrefabUrl
    {
        get
        {
            return UrlPrefabs.core + view;
        }
    }
}