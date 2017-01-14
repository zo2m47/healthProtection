using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/**
* Logic with all static data in the game 
* */
public class StaticDataModel : ModelSingleTone<StaticDataModel>
{
    //static colactions
    private int _initializatedStaticData = 5;
    private CollectionOfData<RoundVO> _rounds;
    private CollectionOfData<CoreVO> _cores;
    private CollectionOfData<VirusVO> _viruses;
    private CollectionOfData<AntiBodyVO> _antiBodies;
    private CollectionOfData<BodyVO> _bodies;

    //list of rounds by body
    private Dictionary<string,List<string>> _roundsInBody;

    public override void StartInitialization()
    {
        base.StartInitialization();
        Debug.Log("Start initialization Static model");
        InitRounds();
        InitCores();
        InitVirues();
        InitAntiBody();
        InitBodies();
    }

    protected override IEnumerator CheckOnInitialized()
    {
        while (_initializatedStaticData != 0)
        {
            yield return null;
        }
        initializationStatus = InitializationStatus.initializated;
        yield break;
    }
    
    /* work with rounds
     * */
    private void InitRounds()
    {
        _rounds = new CollectionOfData<RoundVO>();
        _rounds.InitCollaction(XmlsNames.ROUNDS_STATIC_DATA);

        _roundsInBody = new Dictionary<string, List<string>>();
        foreach (RoundVO data in _rounds.collaction.Values)
        {
            if (!_roundsInBody.ContainsKey(data.body))
            {
                _roundsInBody.Add(data.body, new List<string>());
            }
            _roundsInBody[data.body].Add(data.id);
        }

        _initializatedStaticData--;
    }
    
    public RoundVO GetRoundById(string id)
    {
        return _rounds.GetDataById(id);
    }

    public Dictionary<string,RoundVO> rounds
    {
        get
        {
            return _rounds.collaction;
        }
    }

    public List<String> GetAllRoundsInBody(string bodyId)
    {
        if (!_roundsInBody.ContainsKey(bodyId))
        {
            LoggingManager.AddErrorToLog("Dint found rounds in body "+ bodyId);
            return new List<string>();
        }
        return _roundsInBody[bodyId];
    }

    /* work with cores
     * */
     private void InitCores()
    {
        _cores = new CollectionOfData<CoreVO>();
        _cores.InitCollaction(XmlsNames.CORES_STATIC_DATA);
        _initializatedStaticData--;
    }

    public CoreVO GetCoreById(string id)
    {
        return _cores.GetDataById(id);
    }

    /*Work with viruses
     * */
     private void InitVirues()
    {
        _viruses = new CollectionOfData<VirusVO>();
        _viruses.InitCollaction(XmlsNames.VIRUSES_STATIC_DATA);
        _initializatedStaticData--;
    }

    public VirusVO GetVirusById(string id)
    {
        return _viruses.GetDataById(id);
    }

    /* Work with antiBodies
     * */
    private void InitAntiBody()
    {
        _antiBodies= new CollectionOfData<AntiBodyVO>();
        _antiBodies.InitCollaction(XmlsNames.ANTIBODIES_STATIC_DATA);
        _initializatedStaticData--;
    }

    public AntiBodyVO GetAntiBodyById(string id)
    {
        return _antiBodies.GetDataById(id);
    }

    /* work with bodies
     * */
    private void InitBodies()
    {
        _bodies = new CollectionOfData<BodyVO>();
        _bodies.InitCollaction(XmlsNames.BODIES_STATIC_DATA);
        _initializatedStaticData--;
    }

    public BodyVO GetBodyById(string id)
    {
        return _bodies.GetDataById(id);
    }

    public List<BodyVO> bodiesList
    {
        get
        {
            return _bodies.list;
        }
    }
}