using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace OcTree
{
    public class OcTreeNode
    {
        //空间内包含的物体
        public List<GameObject> areaObjects;
        //空间中心
        public Vector3 center;
        //空间尺寸
        public float size;

        public bool showed = false;
        public void ShowNodes()
        {
            if (areaObjects == null) return;
            if (showed) return;
            for (int i = 0; i < areaObjects.Count; i++)
            {
                areaObjects[i].SetActive(true);
            }

            showed = true;
        }
        
        public void HideNodes()
        {
            if (areaObjects == null) return;
            if (!showed) return;
            for (int i = 0; i < areaObjects.Count; i++)
            {
                areaObjects[i].SetActive(false);
            }

            showed = false;
        }
        public OcTreeNode top0
        {
            get
            {
                return kids[0];
            }
            set
            {
                kids[0] = value;
            }
        }

        public OcTreeNode top1
        {
            get
            {
                return kids[1];
            }
            set
            {
                kids[1] = value;
            }
        }

        public OcTreeNode top2
        {
            get
            {
                return kids[2];
            }
            set
            {
                kids[2] = value;
            }
        }

        public OcTreeNode top3
        {
            get
            {
                return kids[3];
            }
            set
            {
                kids[3] = value;
            }
        }

        public OcTreeNode bottom0
        {
            get
            {
                return kids[4];
            }
            set
            {
                kids[4] = value;
            }
        }

        public OcTreeNode bottom1
        {
            get
            {
                return kids[5];
            }
            set
            {
                kids[5] = value;
            }
        }

        public OcTreeNode bottom2
        {
            get
            {
                return kids[6];
            }
            set
            {
                kids[6] = value;
            }
        }

        public OcTreeNode bottom3
        {
            get
            {
                return kids[7];
            }
            set
            {
                kids[7] = value;
            }
        }
        
        private const int kidCount = 8;
        private OcTreeNode[] kids;
        public OcTreeNode(Vector3 center, float size)
        {
            kids = new OcTreeNode[kidCount];
            this.center = center;
            this.size = size;

            areaObjects = new List<GameObject>();
        }
        
        //获取当前空间内记录的物体数量
        public int objectCount => areaObjects.Count;

        //unity gizmos可视化代码
        public void DrawGizmos()
        {
            Gizmos.DrawWireCube(center, Vector3.one * size);
        }

        //判断空间是否包含某个点
        public bool Contains(Vector3 position)
        {
            var halfSize = size * 0.5f;
            return Mathf.Abs(position.x - center.x) <= halfSize &&
                   Mathf.Abs(position.y - center.y) <= halfSize &&
                   Mathf.Abs(position.z - center.z) <= halfSize;
        }

        //清理当前空间内物体
        public void ClearArea()
        {
            areaObjects.Clear();
        }

        //记录物体
        public void AddGameobject(GameObject obj)
        {
            areaObjects.Add(obj);
        }
    }
}

