using UnityEngine;
using System.Collections;
using TrobleTimeNameSpace;

public class CharCtrl : MonoBehaviour {

    int hp;
    int bid;
    int type;
    public int x, y;

	// Use this for initialization
	void Start () {
	
	}
	
    public bool IsAlive()
    {
        return hp > 0;
    }

    public void GetHit(int dmg)
    {
        hp -= dmg;
    }

    public void GetStatus(Status st)
    {
    }

    public void Load()
    {

    }

    public int Dist(GameObject tarr)
    {
        int xd = tarr.GetComponent<CharCtrl>().x - x;
        int yd = tarr.GetComponent<CharCtrl>().y - y;
        xd = Mathf.Abs(xd);
        yd = Mathf.Abs(yd);
        int r = Mathf.Max(xd, yd);
        return r;
    }

    public bool CheckWay(GameObject tarr) {
        return true;
    }

    public void SetType(int t)
    {
        type = t;
    }

    public int Type()
    {
        return type;
    }

    public void SetBID(int id)
    {
        bid = id;
    }

    public int ID()
    {
        return bid;
    }
    
    public bool Equals(GameObject tarr)
    {
        return bid == tarr.GetComponent<CharCtrl>().ID();
    }

    public bool CheckAlly()
    {
        return true;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
