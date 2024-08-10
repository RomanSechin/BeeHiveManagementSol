namespace BeeHiveManagementApp
{
    class EggCare : Bee {
        private float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public  override float CostPerShift { get; } = 1.35f;
        private Queen queen;
        public EggCare(Queen queen) : base("EggCare") {
            this.queen = queen;
        }        
        protected override void DoJob() {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
