using System;
using System.Xml.Serialization;
/**
 * data of attack in round 
 * */
public class AttackVO
{
    //virus id
    [XmlAttribute("virus")]
    public string virus;
    //time (in seconds) when this attack can start 
    [XmlAttribute("start")]
    public int start;
    //time (in seconds) when this attack must end  
    [XmlAttribute("end")]
    public int end;
    //how many viruses must attack in current attack 
    [XmlAttribute("counter")]
    public int counter;
}
