using System.Xml.Serialization;
/**
 * Body static data
 * */
public class BodyVO : DataVO
{
    //view of body
    [XmlAttribute("view")]
    public string view;

    public string viewImageUrl
    {
        get
        {
            return UrlImages.body + view;
        }
    }

    public string viewPrefabUrl
    {
        get
        {
            return UrlPrefabs.body + view;
        }
    }
    //image in uinity bg
    [XmlAttribute("uiBg")]
    public string uiBg;

    public string uiBgImageUrl
    {
        get
        {
            return UrlImages.body + uiBg;
        }
    }

    //index for sortin in main menu
    [XmlAttribute("listSort")]
    public float listSort;
}
