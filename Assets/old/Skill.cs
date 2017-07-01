using System;
using UnityEngine;
using TrobleTimeNameSpace;

namespace TrobleTimeNameSpace
{
    public class Skill
    {
        int cooldown;
        int duration;
        int dist;
        int radius;
        string dur_desc;
        string cd_desc;
        string dist_desc;
        string desc;
        int dmg;
        Status effect;
        int type;
        int curr_cd;

        public Skill()
        {
        }

        public void SetDesc(string d, string cdd, string distd, string durd)
        {
            desc = d;
            cd_desc = cdd;
            dist_desc = distd;
            dur_desc = durd;
        }

        public void SetCD(int cd)
        {
            cooldown = cd;
        }

        public void SetDist(int d)
        {
            dist = d;
        }

        public void StartCD()
        {
            curr_cd = cooldown;
        }

        public bool CheckOportunity(GameObject we, GameObject tarr)
        {
            if (curr_cd > 0)
                return false;
            if (type == 0)
            {
                if (tarr.GetComponent<CharCtrl>().Type() == 0)
                {
                    return false;
                }
            }
            else if (type == 1)
            {
                if (tarr.GetComponent<CharCtrl>().Type() == 1)
                {
                    if (we.GetComponent<CharCtrl>().CheckAlly())
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (type == 2)
            {
                if (tarr.GetComponent<CharCtrl>().Type() == 1)
                {
                    if (!we.GetComponent<CharCtrl>().CheckAlly())
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (type == 3)
            {
                if (!we.GetComponent<CharCtrl>().Equals(tarr))
                {
                    return false;
                }
            }
            if (dist != -1 && dist < we.GetComponent<CharCtrl>().Dist(tarr))
            {
                tarr.GetComponent<CharCtrl>().GetHit(dmg);
                tarr.GetComponent<CharCtrl>().GetStatus(effect);
                return false;
            }
            return true;
        }

        public void Recount_CD()
        {
            if (curr_cd > 0)
            {
                curr_cd--;
            }
        }

        public void Use(GameObject tarr)
        {

            StartCD();
        }
    }
}