using System;
using System.Collections.Generic;
using System.Xml.Serialization;
/**
 * AntiBody
 * */
public class AntiBodyVO:DataVO
{
    //move speed 
    [XmlAttribute("speed")]
    public int speed;

    //attack power
    [XmlAttribute("attack")]
    public int attack;

    [XmlAttribute("view")]
    public string view;

    public string viewImageUrl
    {
        get
        {
            return UrlImages.antiBody + view;
        }
    }

    public string viewPrefabUrl
    {
        get
        {
            return UrlPrefabs.antiBody + view;
        }
    }
}
