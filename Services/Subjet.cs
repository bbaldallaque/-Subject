using _Subject.Services.Interfaces;

namespace _Subject.Services
{
    public class Subjet : ISubjet
    {
        private readonly ILogger<Subjet> _logger;
        private readonly ISubjetContext _dbContext;

        public Subjet(ILogger<Subjet> logger, ISubjetContext dbcontext)
        {
            _logger = logger;
            _dbContext = dbcontext;
        }

        public bool CreateSubjet(Models.Subjet subjet)
        {
            bool result = false;
            try
            {
                subjet.Id = Guid.NewGuid();
                _dbContext.Subjets.Add(subjet);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error creando data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public bool DeleteSubjet(Guid id)
        {
            bool result = false;
            try
            {
                Models.Subjet teacher = FindSubjet(id);
                if (teacher != null)
                {
                    _dbContext.Subjets.Remove(teacher);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public Models.Subjet FindSubjet(Guid id)
        {
            return _dbContext.Subjets.Find(id);
        }

        public Models.Subjet GetSubjetByIdentification(int identification)
        {
            throw new NotImplementedException();
        }

        public List<Models.Subjet> GetSubjets()
        {
            throw new NotImplementedException();
        }
    }
}
