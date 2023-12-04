/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Agent;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Agent
{
    public class SearchAgent<TPercept, TState, TAction> : SimpleAgent<TPercept, TAction>
    {
        public List<TAction> Actions { get; }
        private IMetrics searchMetrics;
        //private List<TAction>.Enumerator actionEnumerator;
        public bool Done { get; } = false;

        public SearchAgent(IProblem<TState, TAction> problem, ISearchForActions<TState, TAction> search)
        {
            var actions = search.FindActions(problem);
            Actions = new List<TAction>();
            if (actions != null)
            {
                Actions.AddRange(actions);
            }
            if (Actions.Count == 0)
            {
                Done = true;
            }
            //actionEnumerator = Actions.GetEnumerator();
            searchMetrics = search.Metrics;
        }

        public override TAction? Act(TPercept? percept)
        {
            return default(TAction);
        }



    }
}

