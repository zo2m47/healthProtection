using System;
using System.Xml.Serialization;
/**
 * Base static data of acorns, weapons, bugs
 * */
public class DataVO:IVisualization
{
    [XmlAttribute("id")]
    public string id;

    //for view information in UI
    protected string _description = "";
    protected string _name = "";
    protected string _picturePreview = "";
    public virtual string description
    {
        get
        {
            if (_description == "")
            {
                _description = "Description " + id;
            }

            return _description;
        }
    }
    // return localization name by id
    public virtual string name
    {
        get
        {
            if (_name == "")
            {
                _name = id;
            }
            return _name;
        }
    }
    //return description by id
    public virtual string picturePreview
    {
        get
        {
            return _picturePreview;
        }
    }
}
                        