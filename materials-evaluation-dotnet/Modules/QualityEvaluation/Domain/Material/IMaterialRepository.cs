namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IMaterialRepository
    {
        public List<Material> Seen { get; set; }

        public Task Insert(Material qualityVision);

        public Task<Material> Get(Guid id);

        public Task Update(Material qualityVision);

        public Task Delete(Guid id);
    }
}
