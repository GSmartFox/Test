using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Question01
{
    public class CubeMove : MonoBehaviour
    {
        [Header("开始位置")]
        public Vector3 m_StartPos = Vector3.zero;
        
        [Header("结束位置")]
        public Vector3 m_EndPos = Vector3.zero;
        
        [Header("缓动时间")]
        public float m_MoveTime = 1f;

        [Header("往复运动")]
        public bool m_Pingpong = false;

        [Header("缓动曲线")]
        public Ease m_Ease = Ease.Linear;
        private Tweener m_Tweener;// 存储缓动对象
        
        void Start()
        {
            Move(gameObject, m_StartPos, m_EndPos, m_MoveTime, m_Pingpong);
        }

        public void Move(GameObject obj, Vector3 begin, Vector3 end, float time, bool pingpong)
        {
            obj.transform.position = begin;
            if (pingpong)
            {
                m_Tweener = obj.transform.DOMove(end, time).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                m_Tweener = obj.transform.DOMove(end, time);
            }

            if (m_Tweener != null)
            {
                m_Tweener.SetEase(m_Ease);
            }
        }
    }
}

