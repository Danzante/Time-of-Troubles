using System.Collections;
using UnityEngine;
using TrobleTimeNameSpace;

namespace TrobleTimeNameSpace
{
    public class BattleCtrl : MonoBehaviour
    {

        GameObject active;
        GameObject[] chars;
        int c1, c2;

        Camera cam;
        public Vector2 tar;
        bool paused;
        GameObject target;
        Game game;

        // Use this for initialization
        void Start()
        {
            LoadAllInfo();
            active = null;
            chars = new GameObject[18];
            paused = false;
            game = GetComponent<Game>();
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        // загрузка всего необходимого 

        void LoadAllInfo()
        {

        }

        void SetChars(GameObject[] ch1, GameObject[] ch2, int n1, int n2)
        {
            c1 = n1;
            c2 = n2;
            for (int i = 0; i < n1; i++)
            {
                chars[i] = ch1[i];
            }
            for (int i = 0; i < n1; i++)
            {
                chars[i + c1] = ch2[i];
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Select();
            }
        }

        // проверки наличия чего-то управляемого

        bool CheckAlive(GameObject ob)
        {
            return ob.GetComponent<CharCtrl>().IsAlive();
        }

        bool CheckAllAlive()
        {
            for (int i = 0; i < c1 + c2; i++)
            {
                if (CheckAlive(chars[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetActive(GameObject ob)
        {
            active = ob;
        }

        public GameObject getActive()
        {
            return active;
        }

        // контроль кликов мышкой

        public Skill SelectedOpt;

        void ShowOptions()
        {

        }

        void Execute()
        {
            paused = true;
            ShowOptions();
        }

        Vector2 Round(Vector3 v)
        {
            int p1, p2;
            p1 = Mathf.RoundToInt(v.x / 4);
            p2 = Mathf.RoundToInt(v.y / 4);
            return new Vector2(p1 * 4, p2 * 4);
        }

        public bool act1 = false;
        public bool act2 = false;

        void Select()
        {
            act1 = true;
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit point;
            act2 = true;
            if (Physics.Raycast(r, out point))
            {
                tar = Round(point.point);
                target = game.FindTar(tar);
                Execute();
            }
        }
    }
}