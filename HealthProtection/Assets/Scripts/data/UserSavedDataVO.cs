
using System.Collections.Generic;
using System.Xml.Serialization;
/**
* All user saved information
* Unlocked rounds
* Unlocked acorns
* Best result in each rounds
* Money
* Buff items
* */
public class UserSavedDataVO
{
    //user id
    [XmlAttribute("id")]
    public int id = 0;

    //name of user who entered to game
    [XmlAttribute("userName")]
    public string userName = "";

    //lost unlock reound by sequenc
    [XmlAttribute("lostUnlockedRound")]
    public string lostUnlockedRound = "";

    //hove many empty slots user has
    [XmlAttribute("slotsCounter")]
    public int slotsCounter = 2;

    //user can get next antybodies
    [XmlAttribute("unlockedAntiBodies")]
    public string unlockedAntiBodies = "";
    private List<string> _unlockedAntiBodyList = new List<string>();
    public List<string> unlockedAntiBodyList
    {
        get
        {
            if (_unlockedAntiBodyList.Count == 0 && unlockedAntiBodies!= "")
            {
                string[] w = unlockedAntiBodies.Split(";"[0]);
                for (int i = 0; i < w.Length; i++)
                {
                    _unlockedAntiBodyList.Add(w[i]);
                }
            }
            return _unlockedAntiBodyList;
        }
    }
}
