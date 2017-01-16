/**
 * Class with folder names and url to prefabs and other files
 * */
public class UrlPrefabs
{
    /**
     * prefabs names 
     * */
    private const string PREFAB_NAME_INFESTED_AREA = "InfestedAreaView";
    /// <UI elements>
        private const string ANTI_BODY_PREVIEW_ITEM = "AntiBodyPreviewItem";
        private const string SELECTED_ANTI_BODY_ITEM = "SelectedAntiBodyItem";
        private const string VIRUS_PREVIEW_ITEM = "VirusPreviewItem";
        private const string GUI_SELECTED_ANI_BODY = "GuiSelectedAntiBody";
    /// </summary>
    private const string PREFAB_NAME_PARALLAX = "Parallax";


    /*
    prefabs folders
    */
    private const string PREFABS_FOLDER = "prefabs/";
    private const string PARALLAX = "parallax/";
    private const string CORE = "cores/";
    private const string VIRUS = "viruses/";
    private const string ROUND = "rounds/";
    private const string ANTIBODY = "antiBodies/";
    private const string BODY = "bodies/";
    private const string ELEMENTS = "elements/";

    //ui 
    public static string guiSelectedAntiBody
    {
        get
        {
            return PREFABS_FOLDER + ELEMENTS + GUI_SELECTED_ANI_BODY;
        }
    }
    public static string antiBodyPreviewItem
    {
        get
        {
            return PREFABS_FOLDER + ELEMENTS + ANTI_BODY_PREVIEW_ITEM;
        }
    }

    public static string selectedAntiBodyItem
    {
        get
        {
            return PREFABS_FOLDER + ELEMENTS + SELECTED_ANTI_BODY_ITEM;
        }
    }

    public static string virusPreviewItem
    {
        get
        {
            return PREFABS_FOLDER + ELEMENTS + VIRUS_PREVIEW_ITEM;
        }
    }
    //infestedArea
    public static string infestedArea
    {
        get
        {
            return PREFABS_FOLDER + ELEMENTS + PREFAB_NAME_INFESTED_AREA;
        }
    }


    //parallax
    public static string parallax
    {
        get
        {
            return PREFABS_FOLDER + PARALLAX + PREFAB_NAME_PARALLAX;
        }
    }

    //core
    public static string core
    {
        get
        {
            return PREFABS_FOLDER + CORE;
        }
    }
    //viruses
    public static string virus
    {
        get
        {
            return PREFABS_FOLDER + VIRUS;
        }
    }
    //rounds 
    public static string round
    {
        get
        {
            return PREFABS_FOLDER + ROUND;
        }
    }
    //antiBodies
    public static string antiBody
    {
        get
        {
            return PREFABS_FOLDER + ANTIBODY;
        }
    }
    //bodies
    public static string body
    {
        get
        {
            return PREFABS_FOLDER + BODY;
        }
    }
}
