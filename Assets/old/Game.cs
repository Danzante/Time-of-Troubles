using System;
using UnityEngine;
using TrobleTimeNameSpace;

namespace TrobleTimeNameSpace
{
    public class Game : MonoBehaviour
    {
        GameObject[] objects;
        int obj_num, size;

        void Start()
        {
            size = 20;
            objects = new GameObject[size];
            obj_num = 0;
        }

        public void AddObj(GameObject ob)
        {
            if (obj_num == size)
            {
                size *= 2;
                GameObject[] newob = new GameObject[size];
            }
            objects[obj_num] = ob;
            obj_num++;
        }

        public GameObject FindTar(Vector2 pos)
        {
            for(int i = 0; i < obj_num; i++)
            {
                if(objects[i].transform.position.x == pos.x && objects[i].transform.position.y == pos.y)
                {
                    return objects[i];
                }
            }
            return null;
        }

        public void Kill(GameObject ob)
        {
            for(int i = 0; i < obj_num; i++)
            {
                if (objects[i].Equals(ob))
                {
                    for(int j = i + 1; j < obj_num; j++)
                    {
                        objects[j - 1] = objects[j];
                    }
                    obj_num--;
                    break;
                }
            }
            if ((obj_num + 5) * 4 < size)
            {
                int newsize = size / 4;
                GameObject[] newob = new GameObject[newsize];
                for (int i = 0; i < obj_num; i++)
                {
                    newob[i] = objects[i];
                }
                objects = newob;
            }
        }

        void Update()
        {
        }
    }
}