using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServantPage : StaticPage
{
    public GameObject serventTab;
    public GameObject rankTab;

    public void OpenServant()
    {
        serventTab.SetActive(true);
        rankTab.SetActive(false);
    }

    public void OpenRank()
    {
        serventTab.SetActive(false);
        rankTab.SetActive(true);
    }
}
