using System;
using System.Xml.Serialization;
/**
* Class with all enums in project
* */
public enum InitializationStatus
{
    waiting,
    inProgress,
    initializated,
    initializationError
}

public enum UINamesEnum
{
    notIdentified,
    mainMenu,
    gui,
    popup
}

public enum PopUpNameEnum
{
    notIdentified,
    winning,
    gameOver
}

public enum SideEnum
{
    left = 1,
    top = 2,
    right = 3,
    bottom = 4
}