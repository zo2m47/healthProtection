using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
/**
 * static data od round 
 * */
public class RoundVO : DataVO {
    
    //view of background
    [XmlAttribute("bgView")]
    public string bgView;
    
    // id of core in this round
    [XmlAttribute("core")]
    public string core;
    
    //round prefab 
    [XmlAttribute("view")]
    public string view;

    //parallaxes settings 
    [XmlArray("parallaxes")]
    [XmlArrayItem("parallax")]
    public List<ParallaxVO> parallaxList = new List<ParallaxVO>();

    //name of game object in body for get position for prefab
    [XmlAttribute("infestedAreaPlace")]
    public string infestedAreaPlace;

    //id of body 
    [XmlAttribute("body")]
    public string body;

    //id of rounds what must be passed for open this round 
    [XmlAttribute("passedRounds")]
    public string passedRounds;
    private string[] _passedRoundsIds;
    public string[] passedRoundsIds
    {
        get
        {
            if (_passedRoundsIds == null && passedRounds!="")
            {
                _passedRoundsIds = passedRounds.Split(";"[0]);
            }
            return _passedRoundsIds;
        }
    }

    //name of image in manu 
    [XmlAttribute("infestedAreaView")]
    public string infestedAreaView;
    public string infestedAreaViewImageUrl { get { return UrlImages.infestedAreaView + infestedAreaView; } }

    //attack settings 
    [XmlArray("attacks")]
    [XmlArrayItem("attack")]
    public List<AttackVO> attackList = new List<AttackVO>();
    //list with unical id of viruses in current round
    private List<string> _attackVirusesList = new List<string>();
    public List<string> attackVirusesList
    {
        get
        {
            if (attackList.Count!= 0 && _attackVirusesList.Count == 0)
            {
                for (int i = 0; i < attackList.Count; i++)
                {
                    if (_attackVirusesList.IndexOf(attackList[i].virus)==-1)
                    {
                        _attackVirusesList.Add(attackList[i].virus);
                    }
                }
            }
            return _attackVirusesList;
        }
    }

    public string bgViewImageUrl { get { return UrlImages.backGrounds+bgView; } }
    public string bgViewPrefabUrl { get { return UrlPrefabs.round + view; } }
}
