using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
* Logic of the game
* */
public class GameModel : ModelSingleTone<GameModel>
{
    //data about all users 
    private Dictionary<int,UserSavedDataVO> _usersData;
    //current user 
    private int _currentUserId = 0;
    //lost unlocked round bysequenc
    private int _lostRoundSequenc = 1;
    public int lostRoundSequenc { get { return _lostRoundSequenc;  } }
    
    public override void StartInitialization()
    {
        base.StartInitialization();
        InitSavedUsersData();
    }
    //load saved user data 
    private void InitSavedUsersData()
    {
        StaticResourcesXmlLoader<UserSavedDataVO> container = StaticResourcesXmlLoader<UserSavedDataVO>.LoadContainer(UrlXmls.userSavedData);
        _usersData = new Dictionary<int, UserSavedDataVO>();

        foreach (UserSavedDataVO data in container.dataList)
        {
            _usersData.Add(data.id, data);
        }
        
        SetCurrentUser(1);
    }

    //initializate curren user 
    public void SetCurrentUser(int userId)
    {
        _currentUserId = userId;
        initializationStatus = InitializationStatus.initializated;
    }

    public UserSavedDataVO currentUserData
    {
        get
        {
            return _usersData[_currentUserId];
        }
    }
    //TODO need reali this method 
    public List<string> CheckOnPassed(string[] rounIds)
    {
        return new List<string>();
    }
}
