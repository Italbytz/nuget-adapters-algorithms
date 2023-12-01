/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Agent;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Search.Agent
{
    public class SearchAgent<TPercept, TState, TAction> : SimpleAgent<TPercept, TAction>
    {
        private List<TAction> actionList;
        private IMetrics searchMetrics;
        //private List<TAction>.Enumerator actionEnumerator;
        public bool Done { get; } = false;

        public SearchAgent(IProblem<TState, TAction> problem, ISearchForActions<TState, TAction> search)
        {
            var actions = search.FindActions(problem);
            actionList = new List<TAction>();
            if (actions != null)
            {
                actionList.AddRange(actions);
            }
            if (actionList.Count == 0)
            {
                Done = true;
            }
            //actionEnumerator = actionList.GetEnumerator();
            searchMetrics = search.Metrics;
        }

        public override TAction? Act(TPercept? percept)
        {
            return default(TAction);
        }



    }
}

