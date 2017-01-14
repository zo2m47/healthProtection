using System;
using System.Collections.Generic;
using System.Xml.Serialization;
/**
 * static data of parallax
 * */
public class ParallaxVO
{
    [XmlAttribute("view")]
    public string view;

    [XmlAttribute("index")]
    public int index;

    [XmlAttribute("deltaMove")]
    public float deltaMove;

    public string viewImageUrl
    {
        get
        {
            return UrlImages.parallax + view;
        }
    }

}
