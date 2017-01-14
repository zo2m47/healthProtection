public class UrlImages
{
    /*
     * image  
     * */
    private const string IMAGES = "images/";
    //background 
    private const string BACK_GROUND = "backGrounds/";
    public static string backGrounds
    {
        get
        {
            return IMAGES + BACK_GROUND;
        }
    }
    //parallax
    private const string PARALLAX = "parallax/";
    public static string parallax
    {
        get
        {
            return IMAGES + PARALLAX;
        }

    }
    //core
    private const string CORE = "cores/";
    public static string core
    {
        get
        {
            return IMAGES + core;
        }
    }
    //viruses
    private const string VIRUS = "viruses/";
    public static string virus
    {
       get
        {
            return IMAGES + VIRUS;
        }
    }
    //antiBodies
    private const string ANTIBODY = "antiBodies/";
    public static string antiBody
    {
        get
        {
            return IMAGES + ANTIBODY;
        }
    }
    //infestedAreaView
    private const string INFESTED_AREA_VIEW = "infestedArea/";
    public static string infestedAreaView
    {
        get
        {
            return IMAGES + INFESTED_AREA_VIEW;
        }
    }
    //bodies
    private const string BODY = "bodies/";
    public static string body
    {
        get
        {
            return IMAGES + BODY;
        }
    }
}
