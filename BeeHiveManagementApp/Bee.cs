﻿namespace BeeHiveManagementApp
{
    class Bee {
        public virtual float CostPerShift { get; }
        public string Job { get; private set; }
        public Bee(string job)
        {
            Job = job;
        }
        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift) == true)
            {
                DoJob();                
            }            
        }
        protected virtual void DoJob() { }       
    }
}
