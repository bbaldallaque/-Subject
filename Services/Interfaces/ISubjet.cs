namespace _Subject.Services.Interfaces
{
    public interface ISubjet
    {
        public List<Models.Subjet> GetSubjets();

        public Models.Subjet GetSubjetByIdentification(int identification);

        public bool CreateSubjet(Models.Subjet Subjet);

        public bool DeleteSubjet(Guid id);

        public Models.Subjet FindSubjet(Guid id);
    }
}
