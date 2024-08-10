using System;

namespace BeeHiveManagementApp
{
    class Queen : Bee {
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers = 9;
        
        public string StatusReport { get; private set; }
        public Queen() : base("Queen") {            
                AssignBee("EggCare");
                AssignBee("HoneyManufacturer");
                AssignBee("NectarCollector");            
        }
        public override float CostPerShift { get; } = 2.15f;        

        public void AssignBee(string job) {
            switch (job) {
                case "EggCare": AddWorker(new EggCare(this)); break;
                case "NectarCollector": AddWorker(new NectarCollector()); break;
                case "HoneyManufacturer": AddWorker(new HoneyManufacturer()); break;
            }
            UpdateStatusReport();            
        }
        private void UpdateStatusReport() { 
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n"+
             $"\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
            $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
            $"\n{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {workers.Length}";
        }

        private void AddWorker(Bee worker) {
            if (unassignedWorkers > 0f) {
                unassignedWorkers -= 1f;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }
        public void CareForEggs(float eggsToConvert) {
            if (eggs >= eggsToConvert) {
                eggs -= eggsToConvert;
                unassignedWorkers = (uint)((float)unassignedWorkers + eggsToConvert);
            }            
        }
        private string WorkerStatus(string job) {
            int count = 0;
            foreach (Bee worker in workers) {
                if (worker.Job == job) {
                    ++count;
                }                
            }
            return $"{Job} count: {count}";
        }

        protected override void DoJob()
        {            
            eggs += EGGS_PER_SHIFT;
            foreach (var worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * workers.Length);
            UpdateStatusReport();
        }
        
    }
}
