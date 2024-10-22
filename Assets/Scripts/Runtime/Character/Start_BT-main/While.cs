﻿using UnityEngine;
using System;

namespace StartFramework.GamePlay.BehaviourTree
{
    public class While : Node
    {
        private Func<bool> processMethod;

		// Func: 返回值为 bool 的委托（这个委托有很多重载）
        public While(string name, Func<bool> processMethod)
        {
            this.name = name;
            this.processMethod = processMethod;
        }

        public override Status Process()
        {
            if (processMethod())
            {
                Status childStatus = children[currentChildren].Process();

                if (childStatus == Status.RUNNING)
                {
                    return Status.RUNNING;
                }
                if (childStatus == Status.FAILURE)
                {
                    return childStatus;
                }

                currentChildren++;

                if (currentChildren >= children.Count)
                {
                    currentChildren = 0;
                }

                return Status.RUNNING;
            }
            else
            {
                return Status.SUCCESS;
            }
        }
    }

}
