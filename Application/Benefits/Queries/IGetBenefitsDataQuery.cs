using CodingChallenge.Domain;

namespace CodingChallenge.Application.Benefits.Queries
{
    public interface IGetBenefitsDataQuery
    {
        BenefitsData Execute();
    }
}