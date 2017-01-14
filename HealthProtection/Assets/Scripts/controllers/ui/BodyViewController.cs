using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/**
* Controller of body view in UI 
* */
public class BodyViewController : MonoBehaviour, IRecyle
{
    [SerializeField]
    private Transform _infestedAreaContainer;
    [SerializeField]
    private SpriteRenderer _spriteRender;

    private Dictionary<string, Vector3> _infestedAreaPlaces = new Dictionary<string, Vector3>();
    private BodyVO _bodyData;
    private List<InfestedAreaController> _infestedAreaControllerList = new List<InfestedAreaController>();

    public void Start()
    {
        if (_spriteRender == null)
        {
            _spriteRender = gameObject.GetComponent<SpriteRenderer>();
        }

        if (_infestedAreaContainer != null)
        {
            foreach (Transform child in _infestedAreaContainer.transform)
            {
                if (_infestedAreaPlaces.ContainsKey(child.name))
                {
                    LoggingManager.AddErrorToLog("Reepat _infestedAreaPlace name - " + child.name);
                } else
                {
                    _infestedAreaPlaces.Add(child.name, child.position);
                }
            }
        } else
        {
            LoggingManager.AddErrorToLog("_infestedAreaContainer doesnt exist in BodyViewController");
        }
        CheckOnInitialization();
    }

    public void SetData(BodyVO data)
    {
        if (_bodyData != null)
        {
            return;
        }    
        _bodyData = data;
        CheckOnInitialization();
    }

    public string bodyId
    {
        get
        {
            return _bodyData.id;
        }
    }

    private void CheckOnInitialization()
    {
        if (_bodyData != null && _infestedAreaPlaces.Count != 0)
        {
            InfestedAreaInit();
        }
    }

    //add infaction area
    private void InfestedAreaInit()
    {
        RoundVO roundData;
        _infestedAreaControllerList = new List<InfestedAreaController>();
        List<string> roundIds = StaticDataModel.Instance.GetAllRoundsInBody(_bodyData.id);

        for (int i = 0; i < roundIds.Count; i++)
        {
            roundData = StaticDataModel.Instance.GetRoundById(roundIds[i]);
            if (_infestedAreaPlaces.ContainsKey(roundData.infestedAreaPlace))
            {
                if (i == _infestedAreaControllerList.Count)
                {
                    _infestedAreaControllerList.Add(PrefabInfestedAreaCreator.CreatInfestedAreaPrefab(_infestedAreaPlaces[roundData.infestedAreaPlace]));
                }
                else
                {
                    _infestedAreaControllerList[i].gameObject.SetActive(true);
                }                

                _infestedAreaControllerList[i].InitViewData(roundData);
            }
            else
            {
                LoggingManager.AddErrorToLog("Didn't found " + roundData.infestedAreaPlace + " in next body " + _bodyData.id);
            }
        }

        if (_spriteRender.sprite == null)
        {
            _spriteRender.sprite = ImageLoader.LoadSprite(_bodyData.viewImageUrl);
        }
    }
    /*
     * IRecyle
     * */
    public void Restart()
    {
        CheckOnInitialization();
    }

    public void Shutdown()
    {
        for (int i = 0; i < _infestedAreaControllerList.Count; i++)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_infestedAreaControllerList[i].gameObject);
        }
    }
}
