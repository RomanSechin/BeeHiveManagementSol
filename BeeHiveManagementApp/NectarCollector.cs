namespace BeeHiveManagementApp
{
    class NectarCollector : Bee {
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift { get; } = 1.95f;
        public NectarCollector() : base("NectarCollector") { }
        protected override void DoJob() { 
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
