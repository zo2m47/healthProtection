using System;
using System.Xml.Serialization;

public class VirusVO:DataVO
{
    [XmlAttribute("health")]
    public int health = 0;

    [XmlAttribute("attack")]
    public int attack = 0;

    [XmlAttribute("view")]
    public string view;

    [XmlAttribute("speed")]
    public float speed;


    public string viewImageUrl
    {
        get
        {
            return UrlImages.virus + view;
        }
    }

    public string viewPrefabUrl
    {
        get
        {
            return UrlPrefabs.virus + view;
        }
    }
}
