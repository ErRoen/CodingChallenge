using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Benefits.Queries
{
    public class GetBenefitsDataQuery : IGetBenefitsDataQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetBenefitsDataQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public BenefitsData Execute()
        {
            return _databaseService.BenefitsData.SingleOrDefault();
        }
    }
}