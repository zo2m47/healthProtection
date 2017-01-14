public class UrlXmls
{
    /* Static data - where are all xml
     * */
    private const string XML_FOLDER = "xmls/";
    private const string STATIC_DATA = "staticData/";
    public static string staticData
    {
        get
        {
            return XML_FOLDER + STATIC_DATA;
        }
    }

    //user saved data // for testing in fut will save in shared object
    public static string userSavedData
    {
        get
        {
            return XML_FOLDER + XmlsNames.USER_SAVED_DATA;
        }
    }
}
