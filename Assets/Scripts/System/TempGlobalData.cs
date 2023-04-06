using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public long funding;
    public long supplies;
    public long army;
}

public class TempGlobalData : MonoWeakSingleton<TempGlobalData>
{
    public UserInfo me = new UserInfo();
    public ServantInfo openedServantInfo;
}
