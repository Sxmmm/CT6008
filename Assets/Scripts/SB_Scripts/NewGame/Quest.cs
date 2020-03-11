﻿//////////////////////////////////////////////////
/// File: Quest.cs
/// Author: Sam Baker
/// Date created: 11/03/20
/// Last edit: 11/03/20
/// Description: 
/// Comments: 
//////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName ="Sam/Quest")]
public class Quest : ScriptableObject
{
    //////////////////////////////////////////////////
    //// Variables
    [SerializeField] private QUEST_TYPE m_questType = QUEST_TYPE.QUEST_ACTION;
    [SerializeField] private string m_questName = "";
    [SerializeField] private string m_questDescription = "";
    [Tooltip("Can be left at 0 if ActionQuest")]
    [SerializeField] private int m_amount = 0;
    [SerializeField] private string[] m_actionKeys = new string[0];
    private bool[] m_actionCompleted = new bool [0];
    private bool m_isCompleted = false;

    //////////////////////////////////////////////////
    //// Functions
    public void Update()
    {
        CheckQuest();
    }

    public void Assign()
    {
        m_actionCompleted = new bool[m_actionKeys.Length];
        m_isCompleted = false;
    }

    private void CheckQuest()
    {
        switch (m_questType)
        {
            case QUEST_TYPE.QUEST_ACTION:
                ActionQuest();
                break;
            case QUEST_TYPE.QUEST_ATTACK:
                AttackQuest();
                break;
            case QUEST_TYPE.QUEST_COLLECT:
                CollectQuest();
                break;
            default:
                break;
        }
    }

    private void ActionQuest()
    {
        for (int i = 0; i < m_actionKeys.Length; i++)
        {
            if (Input.inputString == m_actionKeys[i])
            {
                m_actionCompleted[i] = true;
            }
        }
        int tempCount = 0;
        for (int i = 0; i < m_actionCompleted.Length; i++)
        {
            if(m_actionCompleted[i] == true)
            {
                tempCount++;
            }
        }
        if (tempCount == m_actionCompleted.Length)
        {
            //ActionQuestComplete
            SetCompleted(true);
        }
    }

    private void AttackQuest()
    {
        throw new NotImplementedException();
    }

    private void CollectQuest()
    {
        throw new NotImplementedException();
    }

    public void SetCompleted(bool a_true)
    {
        m_isCompleted = true;
    }
    public bool GetCompleted() => m_isCompleted;

    public string GetData(int a_ivalue)
    {
        if(a_ivalue == 0)
        {
            return m_questName;
        }
        if(a_ivalue == 1)
        {
            return m_questDescription;
        }
        if(a_ivalue == 2)
        {
            return m_amount.ToString();
        }
        return null;
    }

    private enum QUEST_TYPE
    {
        QUEST_ACTION,
        QUEST_ATTACK,
        QUEST_COLLECT
    }
}