namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IMaterialRepository
    {
        public Task Insert(Material material);

        public Task<Material?> Get(Guid id);

        public void Update(Material material);

        public Task Delete(Guid id);
    }
}
