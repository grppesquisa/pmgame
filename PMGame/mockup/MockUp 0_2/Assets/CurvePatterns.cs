using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePatterns : MonoBehaviour
{
    public enum CurveTypes {
        Promoter_Executor,
        Motivator_Presenter,
        Planner_Inspector,
        Protector_Supporter,
        Explorer_Inventor,
        Discoverer_Advocate,
        Conceptualizer_Director,
        Foreseer_Developer,
        Implementor_Supervisor,
        Strategist_Mobilizer,
        Analyzer_Operator,
        Designer_Theorizer,
        Facilitator_Caretaker,
        Envisioner_Mentor,
        Composer_Producer,
        Harmonizer_Clarifier
    }

    public CurveSet Promoter_Executor;
    public CurveSet Motivator_Presenter;
    public CurveSet Planner_Inspector;
    public CurveSet Protector_Supporter;
    public CurveSet Explorer_Inventor;
    public CurveSet Discoverer_Advocate;
    public CurveSet Conceptualizer_Director;
    public CurveSet Foreseer_Developer;
    public CurveSet Implementor_Supervisor;
    public CurveSet Strategist_Mobilizer;
    public CurveSet Analyzer_Operator;
    public CurveSet Designer_Theorizer;
    public CurveSet Facilitator_Caretaker;
    public CurveSet Envisioner_Mentor;
    public CurveSet Composer_Producer;
    public CurveSet Harmonizer_Clarifier;

    public CurveSet GetCurveSet(CurveTypes MB_Type)
    {
        if (MB_Type == CurveTypes.Promoter_Executor)
        {
            return Promoter_Executor;
        }

        else if (MB_Type == CurveTypes.Motivator_Presenter)
        {
            return Motivator_Presenter;
        }

        else if (MB_Type == CurveTypes.Planner_Inspector)
        {
            return Planner_Inspector;
        }

        else if (MB_Type == CurveTypes.Protector_Supporter)
        {
            return Promoter_Executor;
        }

        else if (MB_Type == CurveTypes.Explorer_Inventor)
        {
            return Explorer_Inventor;
        }

        else if (MB_Type == CurveTypes.Discoverer_Advocate)
        {
            return Discoverer_Advocate;
        }

        else if (MB_Type == CurveTypes.Conceptualizer_Director)
        {
            return Conceptualizer_Director;
        }

        else if (MB_Type == CurveTypes.Foreseer_Developer)
        {
            return Foreseer_Developer;

        }

        else if (MB_Type == CurveTypes.Implementor_Supervisor)
        {
            return Implementor_Supervisor;

        }

        else if (MB_Type == CurveTypes.Strategist_Mobilizer)
        {
            return Strategist_Mobilizer;
        }

        else if (MB_Type == CurveTypes.Analyzer_Operator)
        {
            return Analyzer_Operator;
        }

        else if (MB_Type == CurveTypes.Designer_Theorizer)
        {
            return Designer_Theorizer;
        }

        else if (MB_Type == CurveTypes.Facilitator_Caretaker)
        {
            return Facilitator_Caretaker;
        }

        else if (MB_Type == CurveTypes.Envisioner_Mentor)
        {
            return Envisioner_Mentor;
        }

        else if (MB_Type == CurveTypes.Composer_Producer)
        {
            return Composer_Producer;
        }

        else if (MB_Type == CurveTypes.Harmonizer_Clarifier)
        {
            return Harmonizer_Clarifier;
        }

        else
        {
            return null;
        }
    }


}
    